namespace Income_Expense_Manager.ViewModels;
public class ExpenseViewModel
{
    public int Id { get; set; }
    public string ExpenseName { get; set; } = "";
    public int ExpenseCategoryId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Description { get; set; }
}