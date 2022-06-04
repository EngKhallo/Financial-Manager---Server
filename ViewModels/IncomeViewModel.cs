using Income_Expense_Manager.Models;

namespace Income_Expense_Manager.ViewModels;
public class IncomeViewModel
{
    public string IncomeName { get; set; } = "";
    public IncomeCategory? IncomeCategory { get; set; }
    public Account? Account { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Description { get; set; }
}