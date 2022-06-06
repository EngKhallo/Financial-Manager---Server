using Income_Expense_Manager.Data;
using Income_Expense_Manager.ViewModels;
using Income_Expense_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Income_Expense_Manager.Controllers;

[Route("api/v1/[controller]")]

public class IncomesController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public IncomesController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var income = _context.Income.Include(d => d.IncomeCategory).ToList();
        return Ok(income);
    }

    [HttpPost]
    public IActionResult Add([FromBody] IncomeViewModel viewModel)
    {
        var income = new Income
        {
            IncomeName = viewModel.IncomeName,
            IncomeCategoryId = viewModel.IncomeCategoryId,
            AccountId = viewModel.AccountId,
            Amount = viewModel.Amount,
            CreatedAt = DateTime.UtcNow,
            Description = viewModel.Description
        };
        _context.Income.Add(income);
        _context.SaveChanges();

        return Created("", income);
    }
}