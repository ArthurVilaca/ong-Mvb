using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class Associado
    {
        /*       
         *  [BsonElement("Nome")]
         *  [BsonElement("Cpf")]
         *  [BsonElement("Senha")]
         *  [BsonElement("Funcao")]
         *  [BsonElement("Tipo")]
         */
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Cpf")]
        public string Cpf { get; set; }

        [BsonElement("Senha")]
        public string Senha { get; set; }

        [BsonElement("Funcao")]
        public string Funcao { get; set; }
    }
}
