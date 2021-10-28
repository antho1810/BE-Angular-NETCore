using BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AplicationDBContext _contex;

        public ComentarioController(AplicationDBContext context)
        {
            _contex = context;

        }
        // GET: api/<ComentarioController>
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            try {
                var listComentarios = await _contex.Comentario.ToListAsync();
                return Ok(listComentarios);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ComentarioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try {
                var comentario = await _contex.Comentario.FindAsync(id);
                
                if(comentario == null)
                {
                    return NotFound();
                }
                return Ok(comentario);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ComentarioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Comentario comentario)
        {
            try
            {
                _contex.Add(comentario);
                await _contex.SaveChangesAsync();

                return Ok(comentario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ComentarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Comentario comentario)
        {
            try
            {
                if(id != comentario.id)
                {
                    return BadRequest();
                }

                _contex.Update(comentario);
                await _contex.SaveChangesAsync();

                return Ok(new { message = "Comentario actualizado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ComentarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var comentario = await _contex.Comentario.FindAsync(id);

                if(comentario == null)
                {
                    return NotFound();
                }

                _contex.Comentario.Remove(comentario);
                await _contex.SaveChangesAsync();

                return Ok(new { message = "Comentario eliminado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
