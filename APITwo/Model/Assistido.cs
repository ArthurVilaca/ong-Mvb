using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class Assistido
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Cpf")]
        public string Cpf { get; set; }

        [BsonElement("Senha")]
        public string Senha { get; set; }

        [BsonElement("Sexo")]
        public string Sexo { get; set; }

        [BsonElement("Nascimento")]
        public DateTime Nascimento { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("Ocupacao")]
        public string Ocupacao { get; set; }

        [BsonElement("Endereco")]
        public Endereco Endereco { get; set; }
    }
}
