using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class Denuncia
    {        
        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("NumeroProcesso")]
        public string NumeroProcesso { get; set; }

        [BsonElement("Data")]
        public DateTime Data => DateTime.Now.Date;

    }
}
