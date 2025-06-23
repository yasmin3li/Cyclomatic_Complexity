
using Xunit;
using LoanApp.Core;

namespace LoanApp.Tests
{
    public class LoanEvaluatorTests
    {
        private  LoanEvaluator evaluator = new LoanEvaluator();

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_IncomeBelow2000()
        {
            var result = evaluator.GetLoanEligibility(1500, true, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_IncomeExactly1999()
        {
            var result = evaluator.GetLoanEligibility(1999, true, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnEligible_When_IncomeExactly2000()
        {
            var result = evaluator.GetLoanEligibility(2000, true, 700, 0, false);
            Assert.Equal("Eligible", result);
        }        

        [Fact]
        public void GetLoanEligibility_Should_ReturnEligible_When_NotEmployeeWithCreditExactly750()
        {
            var result = evaluator.GetLoanEligibility(5001, false, 750, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnEligible_When_EmployeeWithHighScoreAndNoDependents()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 700, 0, false);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnReviewManually_When_EmployeeWithHighScoreAnd2Dependents()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 700, 2, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_EmployeeWithHighScoreAndManyDependents()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 700, 3, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnReviewManually_When_EmployeeWithMediumScoreAndOwnsHouse()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 650, 0, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_EmployeeWithMediumScoreAndNoHouse()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 650, 0, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_EmployeeWithLowScore()
        {
            var result = evaluator.GetLoanEligibility(2500, true, 500, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnEligible_When_NotEmployeeWithExcellentScoreAndHighIncomeAndHouse()
        {
            var result = evaluator.GetLoanEligibility(6000, false, 800, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnReviewManually_When_NotEmployeeWithGoodScoreAndNoDependents()
        {
            var result = evaluator.GetLoanEligibility(3000, false, 700, 0, false);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_NotEmployeeWithGoodScoreAndDependents()
        {
            var result = evaluator.GetLoanEligibility(3000, false, 700, 1, false);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_NotEmployeeWithLowScore()
        {
            var result = evaluator.GetLoanEligibility(3000, false, 500, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_NotEmployeeWithExcellentScoreButLowIncome()
        {
            var result = evaluator.GetLoanEligibility(4000, false, 800, 0, true);
            Assert.Equal("Not Eligible", result);
        }

        [Fact]
        public void GetLoanEligibility_Should_ReturnNotEligible_When_NotEmployeeWithExcellentScoreButNoHouse()
        {
            var result = evaluator.GetLoanEligibility(6000, false, 800, 0, false);
            Assert.Equal("Not Eligible", result);
        }
    }
}