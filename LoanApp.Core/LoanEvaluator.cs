// namespace LoanApp.Core;

// public class LoanEvaluator
// {
//     public string GetLoanEligibility(int income,
//      bool hasJob, int creditScore, int dependents, bool ownsHouse)
//     {
//         if (income < 2000)
//             return "Not Eligible";
        
//         if (hasJob)
//         {
//             if (creditScore >= 700)
//             {
//                 if (dependents == 0)
//                     return "Eligible";
//                 else if (dependents <= 2)
//                     return "Review Manually";
//                 else
//                     return "Not Eligible";
//             }
//             else if (creditScore >= 600)
//             {
//                 if (ownsHouse)
//                     return "Review Manually";
//                 else
//                     return "Not Eligible";
//             }
//             else
//             {
//                 return "Not Eligible";
//             }
//         }
//         else
//         {
//             if (creditScore >= 750 && income > 5000 && ownsHouse)
//                 return "Eligible";
//             else if (creditScore >= 650 && dependents == 0)
//                 return "Review Manually";
//             else
//                 return "Not Eligible";
//         }
//     }
// }
// //===========================================================================

namespace LoanApp.Core;

public class LoanEvaluator
{
    public string GetLoanEligibility(int income, bool hasJob, int creditScore, int dependents, bool ownsHouse)
    {
        if (IsVeryLow(income))
            return "Not Eligible";
        
        return hasJob ? EvaluateAnEmployee(creditScore, dependents, ownsHouse) : EvaluateNotEmployee(creditScore, income, dependents, ownsHouse);
    }
   
    private bool IsVeryLow(int income) => income < 2000;
    
    private string EvaluateAnEmployee(int creditScore, int dependents, bool ownsHouse)
    {
        if (IsHighScore(creditScore))
            return EvaluateDependents(dependents);
        
        else if (IsMediumScore(creditScore))
            return ownsHouse ? "Review Manually" : "Not Eligible";
        
        else
            return "Not Eligible";
    }
    
    private bool IsHighScore(int creditScore) => creditScore >= 700;
    private bool IsMediumScore(int creditScore) => creditScore >= 600;
    
    private string EvaluateDependents(int dependents)
    {
            if (dependents == 0)
                return "Eligible";
            else if (dependents <= 2)
                return "Review Manually";
            else
                return "Not Eligible";  
    }
    
    private string EvaluateNotEmployee(int creditScore, int income, int dependents, bool ownsHouse)
    {
        if (IsExcellentScore(creditScore) && income > 5000 && ownsHouse)
            return "Eligible";
        
        if (IsGoodScore(creditScore) && dependents == 0)
            return "Review Manually";
        
        return "Not Eligible";
    }
    
    private bool IsExcellentScore(int creditScore) => creditScore >= 750;
    private bool IsGoodScore(int creditScore) => creditScore >= 650;
}