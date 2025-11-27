namespace Kaloom.Users.Application.Services.Abstractions
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, string routingKey);
    }
}
