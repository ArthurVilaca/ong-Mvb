using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class Servico
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("CpfAssistido")]
        public string CpfAssistido{ get; set; }

        [BsonElement("Denuncia")]
        public Denuncia Denuncia { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }
    }
}
