using ApPBeneficiarios.Data;
using ApPBeneficiarios.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApPBeneficiarios.Services
{
    public class BeneficiarioServices : IBeneficiarioServices
    {
        private bdbeneficiariosEntities4 db;

        public bool Insert(beneficiarios beneficiario)
        {
            bool respuesta = false;
            try
            {
                using (db = new bdbeneficiariosEntities4())
                {
                    
                    db.beneficiarios.Add(beneficiario);
                    db.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {

                string mensaje = ex.Message;
            }
            return respuesta;
        }


        public List<beneficiarios> GetAll()
        {
            List<beneficiarios> benefiariosList = new List<beneficiarios>();
            try
            {
                using (db = new bdbeneficiariosEntities4())
                {
                   benefiariosList=  db.beneficiarios.Include("direcciones").Include("telefonos").Include("generos").ToList<beneficiarios>();
                }
                return benefiariosList;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return null;    
            }

        }

    }
}