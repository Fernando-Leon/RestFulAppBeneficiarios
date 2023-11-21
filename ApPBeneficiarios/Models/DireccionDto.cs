using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApPBeneficiarios.Models
{
    public class DireccionDto
    {
        public int Id { get; set; }
        public string StrCalle { get; set; }
        public string StrNumeroInterior { get; set; }
        public string StrNumeroExterior { get; set; }
    }
}