using ApPBeneficiarios.Data;
using ApPBeneficiarios.Infraestructure;
using ApPBeneficiarios.Models;
using ApPBeneficiarios.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ApPBeneficiarios.Controllers
{
    public class GenerosController : ApiController
    {
        
        //Get: api/Generos
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IServicesGeneros services = new ServicesGeneros();
                List<generos> lista = services.Get();
                List<GeneroDto> generosDto = new List<GeneroDto>();
                foreach (generos g in lista)
                {
                    generosDto.Add(new GeneroDto { Id = g.id, StrValor = g.StrValor });
                }

                return Ok(generosDto);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return BadRequest();
            }
            

        }
        [HttpPost]
        public IHttpActionResult Create(generos genero)
        {
            try
            {
                IServicesGeneros services = new ServicesGeneros();
                return Ok(services.Insert(genero));

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return BadRequest("Esta solicitud no se pudo procesar de forma adecuada.!");
                
            }
        }
        //Delete: api/Generos
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                IServicesGeneros services = new ServicesGeneros();
                return Ok(services.Delete(id));
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult Update(GeneroDto genero)
        {
            try
            {
                IServicesGeneros services = new ServicesGeneros();
                var entidad = new generos { id=genero.Id, StrValor = genero.StrValor};
                return Ok(services.Update(entidad));
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return BadRequest();
            }
        }

    }
}
