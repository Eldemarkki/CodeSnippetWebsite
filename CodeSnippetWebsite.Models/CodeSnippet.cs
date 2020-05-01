using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CodeSnippetWebsite.Models
{
    public class CodeSnippet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public CodeSnippet() { }

        public CodeSnippet(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
