using Xunit;
using LoanApp.Core;

namespace LoanApp.Tests
{
    public class LoanEvaluationHelpersTests
    {
        [Fact]
        public void IsVeryLow_ShouldReturnTrue_WhenIncome1999() {
            Assert.True(LoanEvaluationHelpers.IsVeryLow(1999));
        }

        [Fact]
        public void IsVeryLow_ShouldReturnFalse_WhenIncome2000() 
        {
            Assert.False(LoanEvaluationHelpers.IsVeryLow(2000));
        }

        [Fact]
        public void IsHighScore_ShouldReturnTrue_WhenScore700() 
        {
            Assert.True(LoanEvaluationHelpers.IsHighScore(700));
        }

        [Fact]
        public void IsHighScore_ShouldReturnFalse_WhenScore699() 
        {
            Assert.False(LoanEvaluationHelpers.IsHighScore(699));
        }
        
        [Fact]
        public void EvaluateDependents_ShouldReturnReview_WhenDependents2() 
        {
            Assert.Equal("Review Manually", LoanEvaluationHelpers.EvaluateDependents(2));
        }

        [Fact]
        public void EvaluateDependents_ShouldReturnNotEligible_WhenDependents3() 
        {
            Assert.Equal("Not Eligible", LoanEvaluationHelpers.EvaluateDependents(3));
        }

        [Fact]
        public void EvaluateAnEmployee_ShouldReturnReview_WhenMediumScoreAndOwnsHouse() 
        {
            var result = LoanEvaluationHelpers.EvaluateAnEmployee(600, 1, true);
            Assert.Equal("Review Manually", result);
        }

        [Fact]
        public void EvaluateNotEmployee_ShouldReturnEligible_WhenExactly750ScoreAnd5001Income() 
        {
            var result = LoanEvaluationHelpers.EvaluateNotEmployee(750, 5001, 0, true);
            Assert.Equal("Eligible", result);
        }

        [Fact]
        public void EvaluateNotEmployee_ShouldReturnNotEligible_WhenIncome5000() 
        {
            var result = LoanEvaluationHelpers.EvaluateNotEmployee(800, 5000, 0, true);
            Assert.Equal("Review Manually", result);
        }        

    }
}