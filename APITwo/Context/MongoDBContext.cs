using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITwo
{
    public class MongoDBContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDBContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }
        public IMongoCollection<Associado> associados
        {
            get
            {
                return _database.GetCollection<Associado>("associado");
            }
        }
        public IMongoCollection<Assistido> assistidos {
            get
            {
                return _database.GetCollection<Assistido>("assistido");                   
            }
        }
        public IMongoCollection<Servico> servico
        {
            get
            {
                return _database.GetCollection<Servico>("servico");
            }
        }
        public IMongoCollection<Gerente> gerente
        {
            get
            {
                return _database.GetCollection<Gerente>("gerente");
            }
        }        
    }
}
