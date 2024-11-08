using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private static List<Cliente> Clientes = new List<Cliente>();

    [HttpGet]
    public ActionResult<List<Cliente>> GetAll()
    {
        return Clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in Clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        return clienteEncontrado;
    }

    [HttpPost]
    public ActionResult Post(Cliente cliente)
    {
        Clientes.Add(cliente);
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente clienteAtualizado)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in Clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        clienteEncontrado.Nome = clienteAtualizado.Nome;
        clienteEncontrado.Email = clienteAtualizado.Email;
        clienteEncontrado.Telefone = clienteAtualizado.Telefone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Cliente clienteEncontrado = null;
        foreach(var cliente in Clientes)
        {
            if(cliente.Id == id)
            {
                clienteEncontrado = cliente;
                break;
            }
        }
        if(clienteEncontrado == null)
        {
            return NotFound();
        }
        Clientes.Remove(clienteEncontrado);

        return NoContent();
    }
}