namespace CodeSnippetWebsite.Models
{
    public class CodeSnippetDatabaseSettings : ICodeSnippetDatabaseSettings
    {
        public string CodeSnippetsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ICodeSnippetDatabaseSettings
    {
        string CodeSnippetsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
