using Microsoft.AspNetCore.Mvc;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.Data;
using Income_Expense_Manager.ViewModels;

namespace Income_Expense_Manager.Controllers;

[Route("api/v1/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public ExpensesController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public Response<List<ExpenseViewModel>> GetAll()
    {
        var expenses = _context.Expense
        .Select(e => new ExpenseViewModel { Id = e.Id, ExpenseName = e.ExpenseName, ExpenseCategoryId = e.ExpenseCategoryId, AccountId = e.AccountId, Amount = e.Amount, Description = e.Description })
        .OrderByDescending(c => c.Id)
        .ToList();
        return new Response<List<ExpenseViewModel>>(expenses);
    }

    [HttpPost]
    public IActionResult Add([FromBody] ExpenseViewModel ViewModel)
    {
        var expense = new Expense
        {
            ExpenseName = ViewModel.ExpenseName,
            ExpenseCategoryId = ViewModel.ExpenseCategoryId,
            AccountId = ViewModel.AccountId,
            Amount = ViewModel.Amount,
            CreatedAt = DateTime.UtcNow,
            Description = ViewModel.Description,
        };

        _context.Expense.Add(expense);
        _context.SaveChanges();

        return Created("", expense);
    }
}