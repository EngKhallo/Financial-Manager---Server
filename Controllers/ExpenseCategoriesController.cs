using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Response<List<ExpenseCategoryViewModel>>> GetAll()
    {
        var _category =await _context.ExpenseCategory
        .Select(x => new ExpenseCategoryViewModel { Id = x.Id, Type = x.Type })
        .OrderByDescending(c => c.Id).ToListAsync();

        return new Response<List<ExpenseCategoryViewModel>>(_category);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ExpenseCategory category)
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

        return Ok("Updated Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _context.ExpenseCategory.Find(id);

        if (category is null)
        {
            return BadRequest();    
        }

        _context.ExpenseCategory.Remove(category);
        _context.SaveChanges();

        return Ok("Deleted");
    }
}