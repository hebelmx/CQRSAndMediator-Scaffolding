using MediatR;

namespace Application.Mediator
{
    public class NotificationMessage : INotification
    {
        public string NotifyText { get; set; }
    }
}