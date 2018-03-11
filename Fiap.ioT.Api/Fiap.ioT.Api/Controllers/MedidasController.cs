using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Fiap.ioT.Api.Models;

namespace Fiap.ioT.Api.Controllers
{
    public class MedidasController : ApiController
    {
        private ApiContext db = new ApiContext();

        // GET: api/Medidas
        public IQueryable<Medida> GetMedidas()
        {
            try
            {
                return db.Medidas.OrderByDescending(o => o.Id).Take(10);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        // GET: api/Medidas/5
        [ResponseType(typeof(Medida))]
        public IHttpActionResult GetMedida(int id)
        {
            var medida = db.Medidas.Find(id);
            if (medida == null)
            {
                return NotFound();
            }

            return Ok(medida);
        }

        // POST: api/Medidas
        [HttpPost]
        public IHttpActionResult PostMedida(string valor)
        {
            var medida = new Medida();

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                medida.Valor = valor;
                db.Medidas.Add(medida);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }           
            return CreatedAtRoute("DefaultApi", new { id = medida.Id }, medida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedidaExists(int id)
        {
            return db.Medidas.Count(e => e.Id == id) > 0;
        }
    }
}