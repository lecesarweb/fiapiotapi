using System;
using System.Collections.Generic;
using Fiap.ioT.Api.Models;
using System.Web.Http;

namespace Fiap.ioT.Api.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            var Medida = new Medida();
            try
            {
                Medida.Valor = value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
