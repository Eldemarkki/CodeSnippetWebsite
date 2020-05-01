using CodeSnippetWebsite.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CodeSnippetWebsite.Services
{
    public class CodeSnippetService
    {
        private readonly IMongoCollection<CodeSnippet> codeSnippets;

        public CodeSnippetService(ICodeSnippetDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            codeSnippets = database.GetCollection<CodeSnippet>(settings.CodeSnippetsCollectionName);
        }

        public List<CodeSnippet> Get()
        {
            List<CodeSnippet> codeSnippetList = codeSnippets.Find(codeSnippet => true).ToList();
            codeSnippetList?.Reverse();
            return codeSnippetList;
        }

        public void Edit(string id, CodeSnippet codeSnippet)
        {
            var filter = Builders<CodeSnippet>.Filter.Eq(cs => cs.Id, id);
            var update = Builders<CodeSnippet>.Update.Set(cs => cs.Name, codeSnippet.Name).Set(cs => cs.Code, codeSnippet.Code);
            codeSnippets.UpdateOne(filter, update);
        }

        public CodeSnippet Get(string id)
        {
            return codeSnippets.Find(codeSnippet => codeSnippet.Id == id).FirstOrDefault();
        }

        public CodeSnippet Create(CodeSnippet codeSnippet)
        {
            codeSnippets.InsertOne(codeSnippet);
            return codeSnippet;
        }

        public void Delete(string codeSnippetId)
        {
            codeSnippets.DeleteOne(codeSnippet => codeSnippet.Id == codeSnippetId);
        }
    }
}
