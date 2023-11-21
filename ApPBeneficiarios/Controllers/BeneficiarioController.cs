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

namespace ApPBeneficiarios.Controllers
{
    public class BeneficiarioController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Create(BeneficiarioDto beneficiarioDto)
        {
            try
            {
                IBeneficiarioServices services = new BeneficiarioServices();
                beneficiarios beneficiario = new beneficiarios();
                
                beneficiario.nombre = beneficiarioDto.Nombre.ToLower();
                beneficiario.apellido_paterno = beneficiarioDto.ApellidoPaterno.ToLower();
                beneficiario.apellido_materno = beneficiarioDto.ApellidoMaterno.ToLower();
                beneficiario.curp = beneficiarioDto.Curp.ToLower();
                beneficiario.fecha_nacimiento = beneficiarioDto.FechaNacimiento;
                beneficiario.id_sexo = beneficiarioDto.IdGenero;

                telefonos telefono = new telefonos();
                telefono.strNumeroCasa = beneficiarioDto.TelefonoDto.StrNumeroCasa;
                telefono.strNumeroCelular = beneficiarioDto.TelefonoDto.StrNumeroCelular;
                telefono.strNumeroTrabajo = beneficiarioDto.TelefonoDto.StrNumeroTrabajo;
                beneficiario.telefonos = telefono;

                direcciones direccion = new direcciones();
                direccion.StrCalle = beneficiarioDto.DireccionDto.StrCalle.ToLower();
                direccion.StrNumeroInterior = beneficiarioDto.DireccionDto.StrNumeroInterior;
                direccion.StrNumeroExterior = beneficiarioDto.DireccionDto.StrNumeroExterior;
                beneficiario.direcciones = direccion;

                if (services.Insert(beneficiario))
                {
                    return Ok();
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
                
            }
        }

       
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IBeneficiarioServices services = new BeneficiarioServices();
                var beneficiarios = services.GetAll();
                List<BeneficiarioDto> beneficiariosDto = new List<BeneficiarioDto>();
                if (beneficiarios != null)
                {
                    foreach (var b in beneficiarios)
                    {
                        BeneficiarioDto beneficiario = new BeneficiarioDto();
                        beneficiario.Nombre = b.nombre;
                        beneficiario.ApellidoPaterno = b.apellido_paterno;
                        beneficiario.ApellidoMaterno = b.apellido_materno;
                        beneficiario.Curp = b.curp;
                        //agrego el sexo
                        beneficiario.Sexo = b.generos.StrValor;
                        DireccionDto direccion = new DireccionDto();
                        direccion.StrCalle = b.direcciones.StrCalle;
                        direccion.StrNumeroInterior = b.direcciones.StrNumeroInterior;
                        direccion.StrNumeroExterior = b.direcciones.StrNumeroExterior;
                        beneficiario.DireccionDto = direccion;
                        TelefonoDto telefono = new TelefonoDto();
                        telefono.StrNumeroCasa = b.telefonos.strNumeroCasa;
                        telefono.StrNumeroCelular = b.telefonos.strNumeroCelular;
                        telefono.StrNumeroTrabajo = b.telefonos.strNumeroTrabajo;
                        beneficiario.TelefonoDto = telefono;

                        beneficiariosDto.Add(beneficiario);
                    }
                }
                
                return Ok(beneficiariosDto);
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return BadRequest();
            }
        }


    }
}
