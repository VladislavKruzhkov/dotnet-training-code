using System.Collections.Generic;

namespace Subscriptions
{
    public static class ChannelExtensions
    {
        public static void SubscribeAll(this Channel channel, List<Subscriber> subscribers)
        {
            foreach (var sub in subscribers)
            {
                channel.AddSubscriber(sub);
            }
        }

        public static void UnSubscribeAll(this Channel channel, List<Subscriber> subscribers)
        {
            foreach (var sub in subscribers)
            {
                channel.RemoveSubscriber(sub);
            }
        }
    }
}
