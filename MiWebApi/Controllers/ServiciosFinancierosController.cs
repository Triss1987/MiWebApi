using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MiWebApi.Data;
using MiWebApi.Entities;

namespace MiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosFinancierosController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public ServiciosFinancierosController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiciosFinancieros>>> GetData()
        {
           var sf = await _dataContext.ServiciosFinancieros.ToListAsync();

            return Ok(sf);
        }

        [HttpPost]
        public async Task<ActionResult<List<ServiciosFinancieros>>> AddSF(ServiciosFinancieros sf)
        {
            _dataContext.ServiciosFinancieros.Add(sf);
            await _dataContext.SaveChangesAsync();
            return Ok(await GetData());
        }

        [HttpPut]
        public async Task<ActionResult<List<ServiciosFinancieros>>> UpdateHero(ServiciosFinancieros updatedSF)
        {
            var dbSF = await _dataContext.ServiciosFinancieros.FindAsync(updatedSF.Id);
            if (dbSF is null)
            {
                return NotFound("Servicio Financiero no actualizado");
            }
            dbSF.Nombre = updatedSF.Nombre;
            dbSF.Tipo = updatedSF.Tipo;
            dbSF.Tasa = updatedSF.Tasa;

            await _dataContext.SaveChangesAsync();

            try
            {
                return Ok(await _dataContext.ServiciosFinancieros.ToListAsync());
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]

        public async Task<ActionResult<List<ServiciosFinancieros>>> DeleteSF(int id)
        {
            var dbSF = await _dataContext.ServiciosFinancieros.FindAsync(id);
            if (dbSF is null)
            {
                return NotFound("SF no localizado");
            }

            _dataContext.ServiciosFinancieros.Remove(dbSF);
            await _dataContext.SaveChangesAsync();

            return Ok("byee!");

        }
    }
}
