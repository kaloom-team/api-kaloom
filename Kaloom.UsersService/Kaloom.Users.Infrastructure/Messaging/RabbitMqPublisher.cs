using Kaloom.Users.Application.Services.Abstractions;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kaloom.Users.Infrastructure.Messaging
{
    public sealed class RabbitMqPublisher : IEventPublisher, IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "user.exchange"; 

        public RabbitMqPublisher(string connectionString)
        {
            var factory = new ConnectionFactory { Uri = new Uri(connectionString) };
            this._connection = factory.CreateConnection();
            this._channel = this._connection.CreateModel();

            this._channel.ExchangeDeclare(ExchangeName, ExchangeType.Topic, durable: true);
        }

        public Task PublishAsync<T>(T @event, string routingKey)
        {
            var json = JsonSerializer.Serialize(@event);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = this._channel.CreateBasicProperties();
            properties.Persistent = true;

            this._channel.BasicPublish(
                exchange: ExchangeName,
                routingKey: routingKey,
                basicProperties: properties,
                body: body
            );

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            this._channel?.Dispose();
            this._connection?.Dispose();
        }
    }
}
