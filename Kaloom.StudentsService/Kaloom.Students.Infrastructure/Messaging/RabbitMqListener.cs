using Kaloom.SharedContracts.Events;
using Kaloom.Students.Application.Consumers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Kaloom.Students.Infrastructure.Messaging
{
    public class RabbitMqListener : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private IConnection _connection = null!;
        private IModel _channel = null!;
        private const string QueueName = "student.user.created.queue";
        private const string ExchangeName = "user.exchange";

        public RabbitMqListener(IServiceProvider serviceProvider, string connectionString)
        {
            this._serviceProvider = serviceProvider;

            var factory = new ConnectionFactory { Uri = new Uri(connectionString) };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.QueueDeclare(QueueName, durable: true, exclusive: false, autoDelete: false);
            _channel.QueueBind(QueueName, ExchangeName, routingKey: "user.created");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                try
                {
                    var userEvent = JsonSerializer.Deserialize<UserCreatedEvent>(content);

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var consumerService = scope.ServiceProvider.GetRequiredService<UserCreatedConsumer>();
                        await consumerService.ConsumeAsync(userEvent!);
                    }

                    _channel.BasicAck(ea.DeliveryTag, false);
                }
                catch (Exception ex)
                {
                    _channel.BasicNack(ea.DeliveryTag, false, true);
                }
            };

            _channel.BasicConsume(QueueName, autoAck: false, consumer);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
            base.Dispose();
        }
    }
}
