using Income_Expense_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Income_Expense_Manager.Data;
public class IncomesDbContext : DbContext
{
    public IncomesDbContext(DbContextOptions<IncomesDbContext> options) : base(options)
    {
        
    }

    public DbSet<IncomeCategory> IncomeCategory { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategory { get; set; }
    public DbSet<Income> Income { get; set; }
    public DbSet<Expense> Expense { get; set; }
    public DbSet<Account> Account { get; set; }
    
}