using Moq;
using NUnit.Framework;
using Subscriptions;

namespace UnitTestsM07
{
    [TestFixture]
    public class SubscriptionsTest
    {
        [Test]
        public static void SubscriptionsTest1()
        {
            var mockSub = new Mock<ISubscriber>();

            mockSub.Setup(x => x.DisplayNotification(It.IsAny<string>()));

            var channel = new Channel("Ch");

            var message = "TheMessage";

            channel.AddSubscriber(mockSub.Object);

            channel.SendNotification(message, 0);

            mockSub.Verify(x => x.DisplayNotification(It.IsAny<string>()), Times.Once);
        }
    }
}
