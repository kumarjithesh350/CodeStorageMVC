using CodeStorageMVC.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeStorageMVC.Services
{
    public class CodeService
    {
        private readonly IMongoCollection<CodeEntry> _codeCollection;

        public CodeService(IConfiguration config)
        {
        const string connectionUri = "mongodb+srv://kumarjithesh350:qwvXy49TcG9R7lql@cluster0.im02ivu.mongodb.net/?retryWrites=true&w=majority";

            // automatically when you first write data.
            var dbName = "test_table";
            var collectionName = "java_code";  


            var client = new MongoClient(connectionUri);
            var database = client.GetDatabase(dbName);
            _codeCollection = database.GetCollection<CodeEntry>(collectionName);
        }

        public async Task<CodeEntry> GetByKeyAsync(string key) =>
            await _codeCollection.Find(c => c.Key == key).FirstOrDefaultAsync();

        public async Task AddCodeAsync(CodeEntry newCode) =>
            await _codeCollection.InsertOneAsync(newCode);
    }
}
