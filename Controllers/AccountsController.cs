using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Income_Expense_Manager.Controllers;

[Route("api/v1/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IncomesDbContext _context;
    public AccountsController(IncomesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public Response<List<AccountsViewModel>> GetAll()
    {
        var account = _context.Account
        .Select(x => new AccountsViewModel { Id = x.Id, Name = x.Name})
        .OrderByDescending(u => u.Id).ToList();

        return new Response<List<AccountsViewModel>>(account);
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

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var account = _context.Account.Find(id);

        if (account is null)
        {
            return BadRequest();
        }

        _context.Account.Remove(account);
        _context.SaveChanges();

        return NoContent();
    }
}