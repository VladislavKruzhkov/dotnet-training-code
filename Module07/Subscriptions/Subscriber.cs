using System;

namespace Subscriptions
{
    public class Subscriber : ISubscriber
    {
        public Subscriber(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void DisplayNotification(string message)
        {
            Console.WriteLine($"{Name} got notification: {message}");
        }
    }

    public interface ISubscriber
    {
        void DisplayNotification(string message);
    }
}
