using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
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

    [HttpPost]
    public IActionResult Add([FromBody] Account account)
    {

        _context.Account.Add(account);
        _context.SaveChanges();

        return Created("", account);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Account account)
    {
        var targetAccount = _context.Account.Find(id);
        if (targetAccount is null)
        {
            return BadRequest();
        }

        targetAccount.Name = account.Name;

        _context.Account.Update(targetAccount);
        _context.SaveChanges();

        return NoContent();
    }
}