namespace LoanApp.Core
{
    public static class LoanEvaluationHelpers
    {
        public static bool IsVeryLow(int income) => income < 2000;
        
        public static bool IsHighScore(int creditScore) => creditScore >= 700;
        public static bool IsMediumScore(int creditScore) => creditScore >= 600;
        public static bool IsExcellentScore(int creditScore) => creditScore >= 750;
        public static bool IsGoodScore(int creditScore) => creditScore >= 650;
        
        public static string EvaluateDependents(int dependents)
        {
            if (dependents == 0)
                return "Eligible";
            else if (dependents <= 2)
                return "Review Manually";
            else
                return "Not Eligible";  
        }
        
        public static string EvaluateAnEmployee(int creditScore, int dependents, bool ownsHouse)
        {
            if (IsHighScore(creditScore))
                return EvaluateDependents(dependents);
            
            else if (IsMediumScore(creditScore))
                return ownsHouse ? "Review Manually" : "Not Eligible";
            
            else
                return "Not Eligible";
        }
        
        public static string EvaluateNotEmployee(int creditScore, int income, int dependents, bool ownsHouse)
        {
            if (IsExcellentScore(creditScore) && income > 5000 && ownsHouse)
                return "Eligible";
            
            if (IsGoodScore(creditScore) && dependents == 0)
                return "Review Manually";
            
            return "Not Eligible";
        }
    }
}