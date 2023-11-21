using ApPBeneficiarios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApPBeneficiarios.Infraestructure
{
    public interface IBeneficiarioServices
    {
        bool Insert(beneficiarios  beneficiario);
        List<beneficiarios> GetAll();
    }
}
