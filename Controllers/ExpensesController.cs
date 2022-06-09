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
        .Select(x => new Expense { Id = x.Id, ExpenseName = x.ExpenseName, Amount = x.Amount, ExpenseCategoryId = x.ExpenseCategoryId, Description = x.Description, AccountId = x.AccountId, })
        .OrderByDescending(c => c.Id).ToList();

        return new Response<List<ExpenseViewModel>>(expenses);
    }
}