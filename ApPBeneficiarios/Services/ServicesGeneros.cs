using ApPBeneficiarios.Data;
using ApPBeneficiarios.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApPBeneficiarios.Services
{
    public class ServicesGeneros : IServicesGeneros
    {
        private bdbeneficiariosEntities4 gestion;

        public ServicesGeneros()
        {

        }

        public bool Insert(generos genero)
        {
            bool respuesta = false;
            try
            {
                using (gestion = new bdbeneficiariosEntities4())
                {
                    gestion.generos.Add(genero);
                    gestion.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Delete(int id)
        {
            bool respuesta = false;
            try
            {
                using (gestion = new bdbeneficiariosEntities4())
                {
                    var genero = gestion.generos.Where(p => p.id == id).FirstOrDefault();
                    gestion.generos.Remove(genero);
                    gestion.SaveChanges();
                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;

            }
            return respuesta;

        }

        public List<generos> Get()
        {
            var generos = new List<generos>();
            try
            {
                using (gestion = new bdbeneficiariosEntities4())
                {
                    return gestion.generos.ToList();
                }
                    
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return generos;
                
            }
            
        }

        public generos GetById(int id)
        {
            generos genero = new generos();
            try
            {
                using (gestion = new bdbeneficiariosEntities4())
                {
                    return gestion.generos.Where(p => p.id == id).FirstOrDefault();
                }
                    
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return genero;
            }
        }

        public bool Update(generos genero)
        {
            bool respuesta = false;
            try
            {
                using (gestion = new bdbeneficiariosEntities4())
                {
                    var entitie = gestion.generos.Where(p => p.id == genero.id).FirstOrDefault();
                    entitie.StrValor = genero.StrValor;
                    gestion.SaveChanges();
                    respuesta = true;
                }

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
               
            }
            return respuesta;

        }


    }
}