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
    public class ServicoController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            MongoDBContext dbContext = new MongoDBContext();
            List<Servico> postList = dbContext.servico.Find(m => true).ToList();
            return Json(postList);
        }

        // GET api/values/5
        [HttpGet("{cpf}")]
        public async Task<JsonResult> Get(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Servico>.Filter.Eq("CpfAssistido", cpf);
            var result = await dbContext.servico.Find(filter).ToListAsync();
            return Json(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Servico servico)
        {
            MongoDBContext dbContext = new MongoDBContext();

             dbContext.servico.InsertOne(servico);
        }

        // PUT api/values/5
        [HttpPut("{servico}")]
        public void Put([FromBody]Servico servico)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Servico>.Filter.Eq("CpfAssistido", servico.CpfAssistido);
            var update = Builders<Servico>.Update.Set("Denuncia", servico.Denuncia)
                .Set("Status",servico.Status);
            var result = dbContext.servico.UpdateOne(filter, update);
        }

        // DELETE api/values/5
        [HttpDelete("{cpf}")]
        public void Delete(string cpf)
        {
            MongoDBContext dbContext = new MongoDBContext();
            var filter = Builders<Servico>.Filter.Eq("CpfAssistido", cpf);
            var result = dbContext.servico.DeleteMany(filter);
        }
    }
}
