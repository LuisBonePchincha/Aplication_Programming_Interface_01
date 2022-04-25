using Aplication_Programming_Interface_01.Context;
using Aplication_Programming_Interface_01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aplication_Programming_Interface_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MovimientoController(AppDbContext context) {
            _context = context;             
        }
        // GET: api/<MovimientoController>
        [HttpGet]
        public IEnumerable<Movimientos> Get()
        {
            return _context.Movimientos.ToList();
        }

        // GET api/<MovimientoController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var Movimiento = _context.Movimientos.FirstOrDefault(p => p.MovimientoId == id);
                var Cuenta = _context.Cuentas.FirstOrDefault(p => p.CuentaId == Movimiento.CuentaId);
                if (Cuenta != null)
                {
                    Movimiento.Cuenta = Cuenta;
                }
                return Ok(Movimiento);
            }
            catch(Exception ex)
            {
                return BadRequest("No hay información con ese ID");
            }
            
        }

        // POST api/<MovimientoController>
        [HttpPost]
        public ActionResult Post([FromBody] Movimientos value)
        {
            try
            {
                _context.Movimientos.Add(value);
                _context.SaveChanges();
                return Ok(value);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<MovimientoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Movimientos value)
        {
            if(value.MovimientoId == id)
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

        // DELETE api/<MovimientoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = _context.Movimientos.FirstOrDefault(p => p.MovimientoId == id);
            if(value != null)
            {
                _context.Movimientos.Remove(value);
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
