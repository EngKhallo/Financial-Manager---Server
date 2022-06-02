namespace Income_Expense_Manager.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; } = "";
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory? ExpenseCategory { get; set; }
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}