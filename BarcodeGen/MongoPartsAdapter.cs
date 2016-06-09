using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeGen
{
    class MongoPartsAdapter : IPartDataAdapter
    {
        public IMongoDatabase db { get; private set; }

        public MongoPartsAdapter(IMongoDatabase db)
        {
            this.db = db;
        }

        public List<Part> GetPartsData()
        {
            IMongoCollection<Part> partsCollection = db.GetCollection<Part>("parts");
            var documents = partsCollection.FindSync(_ => true).ToList();
            return documents;
        }
    }
}
