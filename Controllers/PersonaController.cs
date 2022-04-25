using Aplication_Programming_Interface_01.Context;
using Aplication_Programming_Interface_01.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aplication_Programming_Interface_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PersonaController(AppDbContext context) {
            _context = context;             
        }
        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Personas> Get()
        {
            return _context.Personas.ToList();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public Personas Get(int id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.PersonaId == id);
            return persona;
        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult Post([FromBody] Personas value)
        {
            try
            {
                _context.Personas.Add(value);
                _context.SaveChanges();
                return Ok(value);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Personas value)
        {
            if(value.PersonaId == id)
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

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = _context.Personas.FirstOrDefault(p => p.PersonaId == id);
            if(value != null)
            {
                _context.Personas.Remove(value);
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
