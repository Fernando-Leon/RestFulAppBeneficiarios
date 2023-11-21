using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApPBeneficiarios.Models
{
    public class BeneficiarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Curp { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdGenero { get; set; }
        public TelefonoDto TelefonoDto { get; set; }
        public DireccionDto DireccionDto { get; set; }
        public string Sexo { get; set; }
    }
}