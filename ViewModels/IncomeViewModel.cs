using Income_Expense_Manager.Models;

namespace Income_Expense_Manager.ViewModels;
public class IncomeViewModel
{
    public int Id { get; set; }
    public string IncomeName { get; set; } = "";
    public int IncomeCategoryId { get; set; }
    public string IncomeCategoryName { get; set; } = string.Empty;
    public int AccountId { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Description { get; set; }
}
