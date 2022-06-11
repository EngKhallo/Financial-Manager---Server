namespace Income_Expense_Manager.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string IncomeName { get; set; }="";
        public int IncomeCategoryId { get; set; }
        public IncomeCategory IncomeCategory { get; set; } = null!;
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
    }
}