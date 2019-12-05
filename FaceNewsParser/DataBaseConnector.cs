using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NewsParser
{
    class DataBaseConnector
    {
        IMongoCollection<BsonDocument> newsCollection;
        public DataBaseConnector(string collection)
        {
            var connectionString = "mongodb+srv://writer:writer-pass-123@cluster0-kgt9l.azure.mongodb.net/test?retryWrites=true&w=majority";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("News");
            newsCollection = database.GetCollection<BsonDocument>(collection);
        }

        public async Task InsertRecordAsync(NewsStructure news)
        {
            var document = new BsonDocument
            {
                {"_id", Guid.NewGuid() },
                {"Title", news.Title },
                { "Text", news.Text },
                { "Tags", new BsonArray(news.Tags.ToArray())},
                { "SourceUrl", news.SourceUrl},
                { "TimeSourcePublished", new BsonDateTime(news.TimeSourcePublished) }
            };
            await newsCollection.InsertOneAsync(document);
        }
    }
}
