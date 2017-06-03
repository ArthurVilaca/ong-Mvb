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
    public class AssistidoController : Controller
    {
        // GET: api/values
        [HttpGet]
       public async Task<JsonResult> Get()
        {
            MongoDBContext dbContext = new MongoDBContext();
            // var associados = new List<Associado>();
            //List<Associado> a = new List<Associado>();
            //var cursor = dbContext.associados.Find(new BsonDocument());
            List<Assistido> postList = dbContext.assistidos.Find(m => true).ToList();
            return Json(postList);
        }

        // GET api/values/5
        [HttpGet("{cpf}")]
        public async Task<JsonResult> Get(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Assistido>.Filter.Eq("Cpf", cpf);
            var result = await dbContext.assistidos.Find(filter).ToListAsync();

            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]Assistido assistido)
        {
            MongoDBContext dbContext = new MongoDBContext();

            // entity.Id = Guid.NewGuid();

            await dbContext.assistidos.InsertOneAsync(assistido);
        }

        // PUT api/values/5
        [HttpPut("{assistido}")]
        public void Put([FromBody]Assistido assistido)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Assistido>.Filter.Eq("Cpf", assistido.Cpf);
            var update = Builders<Assistido>.Update.Set("Nome", assistido.Nome)
                .Set("Senha", assistido.Senha)
                .Set("Sexo", assistido.Sexo)
                .Set("Nascimento", assistido.Nascimento)
                .Set("Email", assistido.Email)
                .Set("Ocupacao", assistido.Ocupacao)
                .Set("Endereco", assistido.Endereco);
            var result = dbContext.assistidos.UpdateOne(filter, update);
        }

        // DELETE api/values/5
        [HttpDelete("{cpf}")]
        public void Delete(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Assistido>.Filter.Eq("Cpf", cpf);
            var result = dbContext.assistidos.DeleteMany(filter);
        }
    }
}

