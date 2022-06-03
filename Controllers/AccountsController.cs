using Income_Expense_Manager.Data;
using Microsoft.AspNetCore.Mvc;

namespace Income_Expense_Manager.Controllers;

[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public AccountsController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var account = _context.Account.OrderByDescending(u => u.Id).ToList();
        return Ok(account);
    }

    [HttpGet("{id}")]
    public IActionResult GetSingle(int id)
    {
        var account = _context.Account.Find(id);
        if (account is null)
        {
            return NotFound();
        }

        return Ok(account);
    }
}