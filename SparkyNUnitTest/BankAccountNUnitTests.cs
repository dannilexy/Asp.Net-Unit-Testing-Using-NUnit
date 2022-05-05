using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class BankAccountNUnitTests
    {
        private BankAccount bankAccount;
        [SetUp]
        public void SetUp()
        {
           
        }


        //[Test]
        //public void BankDepositLogFakker_Add100_ReturnsTrue()
        //{
        //    //3 A
        //    //Arrange
        //    BankAccount bank = new BankAccount(new LogFakker());

        //    //Act
        //    var result =  bank.Deposit(100);
        //    //Assert

        //    Assert.True(result);
        //    Assert.AreEqual(bank.balance,100);
        //}

        [Test]
        public void BankDeposit_Add100_ReturnsTrue()
        {
            //3 A
            var mock = new Mock<ILogBook>();
            mock.Setup(x => x.Message("Deposit Invoked"));
            //Arrange
            BankAccount bank = new BankAccount(mock.Object);

            //Act
            var result = bank.Deposit(100);
            //Assert

            Assert.True(result);
            Assert.AreEqual(bank.balance, 100);
        }

        [Test]
        [TestCase(300,200)]
        public void BankWithDraw_Withdraw100Balance200_ReturnsTrue(int balance, int withdrawal)
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.Is<int>(x=>x>0))).Returns(true);

            BankAccount bank = new BankAccount(logMock.Object);
            //Act

            bank.Deposit(balance);
            var result = bank.WithDrawal(withdrawal);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        public void BankWithDraw_Withdraw300Balance200_ReturnsFalse(int balance, int withdrawal)
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(x => x.LogBalanceAfterWithdraw(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bank = new BankAccount(logMock.Object);
            //Act

            bank.Deposit(balance);
            var result = bank.WithDrawal(withdrawal);

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            string desiredOutPut = "hello";
            logMock.Setup(x => x.messageWithReturnStr(It.IsAny<string>())).Returns((string Str) => Str.ToLower() );

            Assert.That(logMock.Object.messageWithReturnStr("HELLo"), Is.EqualTo(desiredOutPut));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutPutStr_ReturnsTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            string desiredOutPut = "hello";
            logMock.Setup(x => x.LogWithOutPutResult(It.IsAny<string>(), out desiredOutPut)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutPutResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutPut));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>(); 
           Customer customer = new Customer();
           Customer customerNotUsed = new Customer();
            logMock.Setup(x => x.LogWithRefObj(ref customer)).Returns(true);
            
            Assert.IsTrue(logMock.Object.LogWithRefObj(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObj(ref customerNotUsed));
        }

        [Test]
        public void BankLogDummy_GetAndSetSeverityMockAndLogType_MockTest()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();

            logMock.SetupAllProperties();
            logMock.Setup(x => x.LogType).Returns("Warning");
            logMock.Setup(x => x.LogSeverity).Returns(10);
            //logMock.SetupAllProperties();
            

            logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

            //Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(s => s.LogToDb(It.IsAny<string>())).Returns(true)
                .Callback((string str) => logTemp += str);
            logMock.Object.LogToDb("Dan");

            Assert.That(logTemp, Is.EqualTo("Hello, Dan"));


            //Callbacks
            int counter = 5;
            logMock.Setup(s => s.LogToDb(It.IsAny<string>())).Returns(true)
                .Callback(() => counter++);
            logMock.Object.LogToDb("Dan");
            logMock.Object.LogToDb("Dan");

            Assert.That(counter, Is.EqualTo(7));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //Verification
            logMock.Verify(i=>i.Message(It.IsAny<string>()),Times.Exactly(2));
            logMock.Verify(i=>i.Message("Test"),Times.AtLeastOnce());
            logMock.VerifySet(i=>i.LogSeverity = 101, Times.Once());
        }
    }
}
