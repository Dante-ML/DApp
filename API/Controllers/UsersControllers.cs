
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<AppUser>> GetUsers()
    {
        //Se determina en tiempo de ejecución
        var users = _context.Users.ToList();

        return users;
    }

    [HttpGet("{id}")] //api/v1/users/2
    //IEnumerable es un interfaz sobre la cual ppodemos tener iteraciones
    public ActionResult<AppUser> GetUserById(int id)
    {
        //Se determina en tiempo de ejecución
        var user = _context.Users.Find(id);

        if (user == null) return NotFound();
    
        return user;
    }
}
