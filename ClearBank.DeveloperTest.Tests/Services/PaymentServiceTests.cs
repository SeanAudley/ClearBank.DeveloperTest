using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;


namespace ClearBank.DeveloperTest.Services.Tests
{
    [TestClass()]
    public class PaymentServiceTests
    {
        private readonly Mock<IConfigService> _mockConfigService;
        private readonly Mock<IAccountsData> _mockDataStore;
        private readonly Mock<IAccountFactory> _mockDataStoreFactory;

        public PaymentServiceTests()
        {
            _mockConfigService = new Mock<IConfigService>();
            _mockDataStore = new Mock<IAccountsData>();
            _mockDataStoreFactory = new Mock<IAccountFactory>();
        }


        // TEST Invalid account

        [TestMethod()]
        public void InvalidAccount()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "1",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = (decimal)100.00,
                Status = AccountStatus.Live
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);


            DateTime transDate = DateTime.Today.Date;

            var paymentService = new PaymentService(_mockDataStore.Object);
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.Bacs,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(false, !result.Success);

        }


        // TEST Faster payments

        [TestMethod()]
        public void MakeFasterPayment()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "123456",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = (decimal)100.00,
                Status = AccountStatus.Live
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);


            DateTime transDate = DateTime.Today.Date;

            var paymentService = new PaymentService(_mockDataStore.Object);
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.FasterPayments,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(true, result.Success);

        }



        // TEST Bacs payments

        [TestMethod()]
        public void MakeBacsPayment()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "123456",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = (decimal)100.00,
                Status = AccountStatus.Live
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);

            var paymentService = new PaymentService(_mockDataStore.Object);

            DateTime transDate = DateTime.Today.Date;
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.Bacs,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(true, result.Success);

        }

        
        // TEST Chaps Payment

        [TestMethod()]
        public void MakeChapsPayment()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "123456",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Balance = (decimal)100.00,
                Status = AccountStatus.Live
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);


            DateTime transDate = DateTime.Today.Date;

            var paymentService = new PaymentService(_mockDataStore.Object);
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.Chaps,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(true, result.Success);

        }


        // TEST VALID account but disabled!

        [TestMethod()]
        public void ValidAccount_NotLive()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "123456",
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
                Balance = (decimal)100.00,
                Status = AccountStatus.Disabled
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);


            DateTime transDate = DateTime.Today.Date;

            var paymentService = new PaymentService(_mockDataStore.Object);
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.Bacs,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(false, result.Success);

        }


        // TEST Faster payments

        [TestMethod()]
        public void InsufficientBalance()
        {
            // Arrange
            _mockConfigService.Setup(x => x.DataStoreType());
            _mockDataStoreFactory.Setup(x => x.Start(It.IsAny<IConfigService>())).Returns(_mockDataStore.Object);

            var acc = new Account()
            {
                AccountNumber = "123456",
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = (decimal)0.00,
                Status = AccountStatus.Live
            };

            _mockDataStore.Setup(ads => ads.GetAccount(It.IsAny<string>())).Returns(acc);


            DateTime transDate = DateTime.Today.Date;

            var paymentService = new PaymentService(_mockDataStore.Object);
            var request = new MakePaymentRequest()
            {
                Amount = (Decimal)10.00,
                CreditorAccountNumber = "123456",
                DebtorAccountNumber = "654321",
                PaymentScheme = PaymentScheme.FasterPayments,
                PaymentDate = transDate
            };

            // Act
            var result = paymentService.MakePayment(request);

            // Assert
            Assert.AreEqual(false, result.Success);

        }


    }
}