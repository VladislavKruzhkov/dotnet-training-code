using System;
using System.Collections.Generic;

namespace Subscriptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var channel = new Channel("GreatBlogger");
            var subscribers = InitSubsForChannel(channel);

            channel.SubscribeAll(subscribers);

            channel.SendNotification($"Privet ot {channel.Name}", 2000);
            channel.SendNotification($"Put likes and good bie", 3000);

            channel.UnSubscribeAll(subscribers);
        }

        #region PrivateMethods

        private static List<Subscriber> InitSubsForChannel(Channel channel)
        {
            var subscribers = new List<Subscriber>();
            Console.WriteLine($"Enter number of subscribers for {channel.Name}");
            try
            {
                var numberOfSubscribers = Convert.ToInt32(Console.ReadLine());

                for (var subs = 0; subs < numberOfSubscribers; subs++)
                {
                    Console.WriteLine("Enter subscriber's name");
                    var subName = Console.ReadLine();

                    subscribers.Add(new Subscriber(subName));
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return subscribers;
        }
        #endregion
    }
}
