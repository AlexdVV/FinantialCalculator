namespace FinantialCalculator.Testing.Tests.AmortizationSchedule
{
    using FinantialCalculator.Domain.Common.Dtos.Request;
    using FinantialCalculator.Domain.Common.Enums;
    using FinantialCalculator.Domain.Implementations;
    using FinantialCalculator.Domain.Common.Dtos.Entities;
    using NUnit.Framework;
    using FinantialCalculator.Domain.Contracts.ServiceContracts;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Net;
    using NuGet.Frameworks;

    public class AmortizationScheduleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAllAmortizationScheduleAsync()
        {
            #region Arrange
            var request = new AmortizationScheduleRequestDto
            {
                AmortizationSchedule = new AmortizationScheduleEntiti()
                {
                    LoanAmount = (decimal)41990.00,
                    AnnualInterest = (decimal)8.25,
                    NumberPayments = 24,
                    Method = MethodTypeEnum.French
                }
            };

            var dependenceInjection = new Mock<IAmortizationScheduleService>();
            dependenceInjection.Setup(method => method.GetAmortizationScheduleAsync(1)).ReturnsAsync( new AmortizationScheduleEntiti() );

            #endregion Arrange

            #region Act
            var response = new AmortizationScheduleDomain(dependenceInjection.Object, request.AmortizationSchedule.Method).GetAmortizationSchedule(request);
            #endregion Act

            #region Assert

            Assert.IsNotNull(response.AmortizationSchedule);
            Assert.IsTrue(response.AmortizationSchedule.PeriodsList.Count == request.AmortizationSchedule.NumberPayments);
            //Assert.IsTrue(response.TotalAmount == (decimal)100032.343);
            #endregion Assert
        }

        [Test]
        public void AnnualInteresLessThan10()
        {
            #region Arrange
            var request = new AmortizationScheduleRequestDto
            {
                AmortizationSchedule = new AmortizationScheduleEntiti()
                {
                    LoanAmount = (decimal)1000000.00,
                    AnnualInterest = (decimal)9.99,
                    NumberPayments = 12,
                    Method = MethodTypeEnum.Germany
                }
            };
            #endregion Arrange

            var dependenceInjection = new Mock<IAmortizationScheduleService>();
            dependenceInjection.Setup(method => method.GetAmortizationScheduleAsync(1)).ReturnsAsync(new AmortizationScheduleEntiti());

            #region Act
            var response = new AmortizationScheduleDomain(dependenceInjection.Object, request.AmortizationSchedule.Method).GetAmortizationSchedule(request);
            #endregion Act

            #region Assert
            Assert.Less(request.AmortizationSchedule.AnnualInterest, 10);
            Assert.IsNull(response.AmortizationSchedule);
            #endregion Assert
        }

        [Test]
        public void CalculateGermanyWithOneMillionLoanAmountOK() 
        {
            #region Arrange
            var request = new AmortizationScheduleRequestDto
            {
                AmortizationSchedule = new AmortizationScheduleEntiti()
                {
                    LoanAmount = (decimal)1000000.00,
                    AnnualInterest = (decimal)12,
                    NumberPayments = 24,
                    Method = MethodTypeEnum.Germany
                }
            };
            #endregion Arrange

            var dependenceInjection = new Mock<IAmortizationScheduleService>();
            dependenceInjection.Setup(method => method.GetAmortizationScheduleAsync(1)).ReturnsAsync(new AmortizationScheduleEntiti());

            #region Act
            var response = new AmortizationScheduleDomain(dependenceInjection.Object, request.AmortizationSchedule.Method).GetAmortizationSchedule(request);
            #endregion Act

            #region Assert
            Assert.IsNotNull(response.AmortizationSchedule);
            #endregion Assert
        }

        [Test]
        public void CalculateGermanyWithNegativeInteresFail()
        {
            #region Arrange
            var request = new AmortizationScheduleRequestDto
            {
                AmortizationSchedule = new AmortizationScheduleEntiti()
                {
                    LoanAmount = (decimal)25000.00,
                    AnnualInterest = (decimal)-8.25,
                    NumberPayments = 12,
                    Method = MethodTypeEnum.Germany
                }
            };
            #endregion Arrange

            #region Act
            var response = new AmortizationScheduleDomain(null, request.AmortizationSchedule.Method).GetAmortizationSchedule(request);
            #endregion Act

            #region Assert
            Assert.IsNull(response.AmortizationSchedule);
            #endregion Assert
        }
    }
}
