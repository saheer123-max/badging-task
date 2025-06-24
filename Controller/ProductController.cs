using Microsoft.AspNetCore.Mvc;
using LastProject.Model;
using LastProject.Data;
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }
    [HttpGet("Product")]
    public IActionResult GetAll()
    {
        var products = _context.ExecuteProductSp("GETALL"); 
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _context.ExecuteProductSp("GETBYID", id).FirstOrDefault(); // ✅ Method name and variable fixed
        if (product == null) return NotFound();
        return Ok(product);
    }


    [HttpPost]
    public IActionResult Create(Product product)
    {
        _context.ExecuteNonQuerySp("CREATE", null, product.Name, product.Price);
        return Ok("Created");
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product product)
    {
        _context.ExecuteNonQuerySp("UPDATE", id, product.Name, product.Price);
        return Ok("Updated");
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _context.ExecuteNonQuerySp("DELETE", id);
        return Ok("Deleted");
    }
}
