using EFDataAnnotations.Communications.Requests;
using EFDataAnnotations.Db;
using EFDataAnnotations.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDataAnnotations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly DataAnnotationDB _context;
    public OrderController(DataAnnotationDB context)
    {
        _context = context;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Order>), 200)]
    public IActionResult Index()
    {
        var data = _context.Orders.AsNoTracking().Include(x=>x.User).ToList();
        return Ok(data);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Order),  201)]
    public IActionResult Create([FromBody] CreateOrder body)
    {
        var order = new Order(productName:body.ProductName, quantity:body.Quantity, price:body.Price, userId:body.UserId);
        _context.Orders.Add(order);
        _context.SaveChanges();
        return Created("", order);
    }
}