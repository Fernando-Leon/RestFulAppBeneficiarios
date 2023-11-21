using ApPBeneficiarios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApPBeneficiarios.Infraestructure
{
    public interface IServicesGeneros
    {
        bool Insert(generos genero);
        bool Delete(int id);
        List<generos> Get();
        generos GetById(int id);

        bool Update(generos genero);
    }
}
