using System.Threading;

namespace Subscriptions
{
    public class Channel
    {
        public delegate void Notifier(string message);

        private event Notifier? Notify;

        public Channel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void AddSubscriber(ISubscriber subscriber)
        {
            Notify += subscriber.DisplayNotification;
        }

        public void RemoveSubscriber(ISubscriber subscriber)
        {
            Notify -= subscriber.DisplayNotification;
        }

        public void SendNotification(string message, int delay)
        {
            Thread.Sleep(delay);
            Notify?.Invoke(message);
        }
    }
}
