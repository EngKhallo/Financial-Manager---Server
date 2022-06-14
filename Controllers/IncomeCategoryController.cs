using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Income_Expense_Manager.Controllers;

[Route("api/v1/[controller]")]
public class IncomeCategoryController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public IncomeCategoryController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var category =await _context.IncomeCategory
        .Select(x => new IncomeCategoryViewModel { Id = x.Id, Type = x.Type })
        .OrderByDescending(c => c.Id).ToListAsync();

        return Ok(category);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var category =await _context.IncomeCategory.FindAsync(id);
        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] IncomeCategory category)
    {
        await _context.IncomeCategory.AddAsync(category);
        await _context.SaveChangesAsync();
        
        return Created("", category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] IncomeCategory category)
    {
        var targetCategory =await _context.IncomeCategory.FindAsync(id);
        if (targetCategory is null)
        {
            return BadRequest();
        }

        targetCategory.Type = category.Type;

        _context.IncomeCategory.Update(targetCategory);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category =await _context.IncomeCategory.FindAsync(id);

        if (category is null)
        {
            return BadRequest();
        }

        _context.IncomeCategory.Remove(category);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}