using System.Collections.Generic;
using CodeSnippetWebsite.Models;
using CodeSnippetWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeSnippetWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CodeSnippetService codeSnippetService;

        public CodeSnippet CodeSnippet { get; set; }

        public IndexModel(CodeSnippetService codeSnippetService)
        {
            this.codeSnippetService = codeSnippetService;    
        }

        public ActionResult<List<CodeSnippet>> CodeSnippets()
        {
            return codeSnippetService.Get();
        }

        public void AddCodeSnippet(CodeSnippet codeSnippet)
        {
            codeSnippetService.Create(codeSnippet);
        }
    }
}
