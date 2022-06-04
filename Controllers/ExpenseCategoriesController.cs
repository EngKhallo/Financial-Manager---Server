using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Income_Expense_Manager.Controllers;
[Route("[controller]")]
public class ExpenseCategoriesController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public ExpenseCategoriesController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var category = _context.ExpenseCategory.ToList();
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Add([FromBody] ExpenseCategory category)
    {
        _context.ExpenseCategory.Add(category);
        _context.SaveChanges();

        return Created("", category);
    }
}