using EFDataAnnotations.Communications.Requests;
using EFDataAnnotations.Db;
using EFDataAnnotations.Entity;
using EFDataAnnotations.Validate;
using Microsoft.AspNetCore.Mvc;

namespace EFDataAnnotations.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly DataAnnotationDB _context;
    public UserController(DataAnnotationDB context)
    {
        _context = context;
    }
    [HttpGet]
    [ProducesResponseType(typeof(List<User>), 200)]
    public IActionResult Index()
    {
        var data = _context.Users.ToList();
        
        return Ok(data);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(User), 201)]
    public IActionResult Create([FromBody] CreateUser body)
    {

        var validate = new UserValidate();
        var result = validate.Validate(body);
        
        if(!result.IsValid)
        {
            return BadRequest(result.Errors.Select(error => error.ErrorMessage).ToList());
        }
        
        
        var user = new User(name:body.Name, email:body.Email, password:body.Password);
        
        _context.Users.Add(user);
        _context.SaveChanges();
        
        return Created(string.Empty, user);
    }
}