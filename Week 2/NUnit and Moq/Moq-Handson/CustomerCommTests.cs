using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        [SetUp]
        public void SetUp()
        {
            _mockMailSender = new Mock<IMailSender>();

            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailSenderReturnsTrue()
        {
            bool result = _customerComm.SendMailToCustomer();
            Assert.That(result, Is.True);
            _mockMailSender.Verify(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldCallSendMail_WithCorrectParameters()
        {
            _customerComm.SendMailToCustomer();

            _mockMailSender.Verify(x => x.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
