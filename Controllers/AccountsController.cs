using Income_Expense_Manager.Data;
using Income_Expense_Manager.Models;
using Income_Expense_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Response<List<AccountsViewModel>>> GetAll()
    {
        var account =await _context.Account
        .Select(x => new AccountsViewModel { Id = x.Id, Name = x.Name})
        .OrderByDescending(u => u.Id).ToListAsync();

        return new Response<List<AccountsViewModel>>(account);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        var account =await _context.Account.FindAsync(id);
        if (account is null)
        {
            return NotFound();
        }

        return Ok(account);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Account account)
    {

        await _context.Account.AddAsync(account);
        await _context.SaveChangesAsync();

        return Created("", account);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Account account)
    {
        var targetAccount =await _context.Account.FindAsync(id);
        if (targetAccount is null)
        {
            return BadRequest();
        }

        targetAccount.Name = account.Name;

        _context.Account.Update(targetAccount);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var account =await _context.Account.FindAsync(id);

        if (account is null)
        {
            return BadRequest();
        }

        _context.Account.Remove(account);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}