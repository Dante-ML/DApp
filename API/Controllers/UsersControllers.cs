
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class UsersControllers : ControllerBase
{
    private readonly DataContext _context;

    public UsersControllers(DataContext context){
        _context = context;
    }

    [HttpGet]
    //IEnumerable es un interfaz sobre la cual ppodemos tener iteraciones
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync()
    {
        //Se determina en tiempo de ejecución
        var users = await _context.Users.ToListAsync();

        return users;
    }

    [HttpGet("{id:int}")] //api/v1/users/2
    //IEnumerable es un interfaz sobre la cual ppodemos tener iteraciones
    public async Task<ActionResult<AppUser>> GetUserByIdAsync(int id)
    {
        //Se determina en tiempo de ejecución
        var user = await _context.Users.FindAsync(id);

        if (user == null) return NotFound();
    
        return user;
    }

    [HttpGet("{name}")] //api/v1/users/2
    //IEnumerable es un interfaz sobre la cual ppodemos tener iteraciones
    public  ActionResult<string> Ready(string name)
    {
        return $"Hi {name}";
    }
}
