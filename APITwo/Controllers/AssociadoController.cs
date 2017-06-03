using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITwo
{
    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            MongoDBContext dbContext = new MongoDBContext();
            // var associados = new List<Associado>();
            //List<Associado> a = new List<Associado>();
            //var cursor = dbContext.associados.Find(new BsonDocument());
            List<Associado> postList = dbContext.associados.Find(m => true).ToList();
            return Json(postList);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var entity =  dbContext.associados.Find(m => m.Cpf == cpf).ToList();
            return Json(entity);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Associado associado)
        {
            MongoDBContext dbContext = new MongoDBContext();

            // entity.Id = Guid.NewGuid();

             dbContext.associados.InsertOne(associado);        
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody]Associado associado)
        {
            MongoDBContext dbContext = new MongoDBContext();
            //cpf = associado.Cpf;
            //you can use the UpdateOne to get higher performance if you need. 
            dbContext.associados.ReplaceOne(m => m.Cpf == associado.Cpf, associado);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();

            dbContext.associados.DeleteOne(m => m.Cpf == cpf);
        }
    }
}
