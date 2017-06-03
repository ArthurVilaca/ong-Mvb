using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class Endereco
    {
        [BsonElement("Logradouro")]
        public string Logradouro { get; set; }
        [BsonElement("Numero")]
        public int Numero { get; set; }
        [BsonElement("Cep")]
        public string Cep { get; set; }
        [BsonElement("Bairro")]
        public string Bairro { get; set; }
        [BsonElement("Cidade")]
        public string Cidade { get; set; }
        [BsonElement("Uf")]
        public string Uf { get; set; }
        [BsonElement("Pais")]
        public string Pais { get; set; }
    }
}
