using eb4395u202312031.API.Shared.Domain.Model.Events;
using Cortex.Mediator.Notifications;

namespace eb4395u202312031.API.Shared.Application.Internal.EventHandlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
{
    
}