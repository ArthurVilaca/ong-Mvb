using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APITwo.Controllers
{
    [Route("api/[controller]")]
    public class GerenteController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            MongoDBContext dbContext = new MongoDBContext();
            // var associados = new List<Associado>();
            //List<Associado> a = new List<Associado>();
            //var cursor = dbContext.associados.Find(new BsonDocument());
            List<Gerente> postList = dbContext.gerente.Find(m => true).ToList();
            return Json(postList);

        }

        // GET api/values/5
        [HttpGet("{cpf}")]
        public async Task<JsonResult> Get(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Gerente>.Filter.Eq("Cpf", cpf);
            var result = await dbContext.gerente.Find(filter).ToListAsync();
            
            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Gerente gerente)
        {
            MongoDBContext dbContext = new MongoDBContext();
            dbContext.gerente.InsertOne(gerente);
        }

        // PUT api/values/5
        [HttpPut("{gerente}")]
        public void Put([FromBody]Gerente gerente)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Gerente>.Filter.Eq("Cpf", gerente.Cpf);
            var update = Builders<Gerente>.Update.Set("Nome", gerente.Nome)
                .Set("Senha", gerente.Senha);
            var result =  dbContext.gerente.UpdateOne(filter, update);
        }

        // DELETE api/values/5
        [HttpDelete("{cpf}")]
        public void Delete(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Gerente>.Filter.Eq("Cpf", cpf);
            var result =  dbContext.gerente.DeleteMany(filter);
        }
    }
}
