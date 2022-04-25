using Aplication_Programming_Interface_01.Context;
using Aplication_Programming_Interface_01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aplication_Programming_Interface_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CuentaController(AppDbContext context) {
            _context = context;             
        }
        // GET: api/<CuentaController>
        [HttpGet]
        public IEnumerable<Cuentas> Get()
        {
            return _context.Cuentas.ToList();
        }

        // GET api/<CuentaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var Cuenta = _context.Cuentas.FirstOrDefault(p => p.CuentaId == id);
                var Cliente = _context.Clientes.FirstOrDefault(p => p.ClienteId == Cuenta.ClienteId);
                if (Cliente != null)
                {
                    Cuenta.Cliente = Cliente;
                }
                return Ok(Cuenta);
            }
            catch(Exception ex)
            {
                return BadRequest("No hay información con ese ID");
            }
            
        }

        // POST api/<CuentaController>
        [HttpPost]
        public ActionResult Post([FromBody] Cuentas value)
        {
            try
            {
                _context.Cuentas.Add(value);
                _context.SaveChanges();
                return Ok(value);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<CuentaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cuentas value)
        {
            if(value.CuentaId == id)
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

        // DELETE api/<CuentaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = _context.Cuentas.FirstOrDefault(p => p.CuentaId == id);
            if(value != null)
            {
                _context.Cuentas.Remove(value);
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
