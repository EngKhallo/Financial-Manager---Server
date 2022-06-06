using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Income_Expense_Manager.Controllers;
[Route("api/v1/[controller]")]
public class ExpenseCategoriesController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public ExpenseCategoriesController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public Response<List<ExpenseCategoryViewModel>> GetAll()
    {
        var _category = _context.ExpenseCategory
        .Select(x => new ExpenseCategoryViewModel { Id = x.Id, Type = x.Type })
        .OrderByDescending(c => c.Id).ToList();

        return new Response<List<ExpenseCategoryViewModel>>(_category);
    }

    [HttpPost]
    public IActionResult Add([FromBody] ExpenseCategory category)
    {
        _context.ExpenseCategory.Add(category);
        _context.SaveChanges();

        return Created("", category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] ExpenseCategory category)
    {
        var targetCategory = _context.ExpenseCategory.Find(id);
        if (targetCategory is null)
        {
            return BadRequest();
        }
         targetCategory.Type = category.Type;

         _context.ExpenseCategory.Update(targetCategory);
         _context.SaveChanges();

         return Ok("Updates Successfully");
    }
}