using SupportPageApi.Models;
using SupportPageApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace SupportPageApi.Controllers;

[ApiController]
[Route("api/[controller]")]


public class SupportController : ControllerBase
{
    private readonly SupportService _supportService;

    public SupportController(SupportService supportService) =>
        _supportService = supportService;

    [HttpGet]
    public async Task<List<ResourcesPage>> Get() =>
        await _supportService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ResourcesPage>> Get(string id)
    {
        var resource = await _supportService.GetAsync(id);

        if (resource is null)
        {
            return NotFound();
        }

        return resource;
    }

    /*[HttpPost]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _supportService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
    */
}

