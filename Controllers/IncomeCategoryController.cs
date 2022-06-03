using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Income_Expense_Manager.Controllers;

[Route("controller")]
public class IncomeCategoryController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public IncomeCategoryController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var category = _context.IncomeCategory.OrderByDescending(c => c.Id).ToList();

        return Ok(category);
    }

    [HttpGet("{id}")]
    public IActionResult GetSingle(int id)
    {
        var category = _context.IncomeCategory.Find(id);
        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public IActionResult Add([FromBody] IncomeCategory category)
    {
        _context.IncomeCategory.Add(category);
        _context.SaveChanges();

        return Created("", category);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] IncomeCategory category)
    {
        var targetCategory = _context.IncomeCategory.Find(id);
        if (targetCategory is null)
        {
            return BadRequest();
        }

        targetCategory.Type = category.Type;

        _context.IncomeCategory.Update(targetCategory);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = _context.IncomeCategory.Find(id);

        if (category is null)
        {
            return BadRequest();
        }

        _context.IncomeCategory.Remove(category);
        _context.SaveChanges();

        return NoContent();
    }
}