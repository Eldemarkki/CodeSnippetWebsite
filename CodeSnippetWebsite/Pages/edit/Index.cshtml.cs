using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippetWebsite.Models;
using CodeSnippetWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeSnippetWebsite
{
    public class IndexModel : PageModel
    {
        private readonly CodeSnippetService codeSnippetService;

        [FromRoute]
        public string Id { get; set; }
        
        public CodeSnippet CodeSnippet { get; set; }

        public IndexModel(CodeSnippetService codeSnippetService)
        {
            this.codeSnippetService = codeSnippetService;
        }

        public ActionResult OnGet(string id)
        {
            CodeSnippet = codeSnippetService.Get(id);
            if(CodeSnippet == null)
            {
                return Redirect("/Error");
            }

            return Page();
        }
    }
}