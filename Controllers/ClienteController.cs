using Aplication_Programming_Interface_01.Context;
using Aplication_Programming_Interface_01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aplication_Programming_Interface_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClienteController(AppDbContext context) {
            _context = context;             
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Clientes> Get()
        {
            return _context.Clientes.ToList();
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var Cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);
                var Persona = _context.Personas.FirstOrDefault(p => p.PersonaId == Cliente.PersonaId);
                if (Persona != null)
                {
                    Cliente.Persona = Persona;
                }
                return Ok(Cliente);
            }
            catch (Exception ex)
            {
                return BadRequest("No hay información con ese ID");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public ActionResult Post([FromBody] Clientes value)
        {
            try
            {
                _context.Clientes.Add(value);
                _context.SaveChanges();
                return Ok(value);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Clientes value)
        {
            if(value.ClienteId == id)
            {
                _context.Entry(value).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(value);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = _context.Clientes.FirstOrDefault(p => p.ClienteId == id);
            if(value != null)
            {
                _context.Clientes.Remove(value);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
