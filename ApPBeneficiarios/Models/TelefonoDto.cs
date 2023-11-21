using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApPBeneficiarios.Models
{
    public class TelefonoDto
    {
        public int Id { get; set; }

        public string StrNumeroCelular { get; set; }
        public string StrNumeroCasa { get; set; }
        public string StrNumeroTrabajo { get; set; }

    }
}