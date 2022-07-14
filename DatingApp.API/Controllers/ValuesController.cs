using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context ;

        public ValuesController(DataContext context)
        {
            _context = context;

        }

        // GET: api/Values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var values =await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET: api/Values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValues(int id)
        {
            var values = await _context.Values.FirstOrDefaultAsync(i =>i.Id == id);
            return Ok(values);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult PostValue([FromBody] Value newValue)
        {
            _context.Values.Add(newValue);
            _context.SaveChanges();
            return Ok(newValue);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
