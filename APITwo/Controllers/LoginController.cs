using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Net.Http;
using System.Net;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITwo
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        // GET api/values/5
        [HttpGet("{Cpf}/{Senha}/{Tipo}")]
        public async Task<JsonResult> Get(string Cpf,string Senha, string Tipo)
        {
            MongoDBContext dbContext = new MongoDBContext();
             if ( Tipo == "Assistido")
             {
                 var builder = Builders<Assistido>.Filter;
                 var filter = builder.Eq("Cpf", Cpf) & builder.Eq("Senha", Senha);
                 var result = dbContext.assistidos.Find(filter).ToList();
                 return Json(result);
             }
             else if (Tipo == "Associado")
             {
                 var builder = Builders<Associado>.Filter;
                 var filter = builder.Eq("Cpf", Cpf) & builder.Eq("Senha", Senha);
                 var result = dbContext.associados.Find(filter).ToList();
                 return Json(result);
             }
            else if (Tipo == "Gerente") { 
           
            var builder = Builders<Gerente>.Filter;            
            var filter = builder.Eq("Cpf", Cpf) & builder.Eq("Senha", Senha);
            var result = dbContext.gerente.Find(filter).ToList();
            return Json(result);
            }
            else
            {
               return Json(null);
            }
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
