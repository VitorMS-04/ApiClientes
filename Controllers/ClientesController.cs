using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Cliente>> GetAll()
    {
        return _context.Clientes.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        var clienteEncontrado = _context.Clientes.Find(id);

        if(clienteEncontrado == null)
            return NotFound();

        return clienteEncontrado;
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        var clienteEncontrado = _context.Clientes.Find(id);
        
        if(clienteEncontrado == null)
            return NotFound();
        
        clienteEncontrado.Nome = clienteAtualizado.Nome;
        clienteEncontrado.Email = clienteAtualizado.Email;
        clienteEncontrado.Telefone = clienteAtualizado.Telefone;

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var clienteEncontrado = _context.Clientes.Find(id);
        
        if(clienteEncontrado == null)
            return NotFound();

        _context.Clientes.Remove(clienteEncontrado);
        _context.SaveChanges();
        return NoContent();
    }
}