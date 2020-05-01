using System.Collections.Generic;
using CodeSnippetWebsite.Models;
using CodeSnippetWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippetWebsite.Pages.api
{
    [Route("api/snippets")]
    [ApiController]
    public class CodeSnippetController : ControllerBase
    {
        private readonly CodeSnippetService codeSnippetService;

        public CodeSnippetController(CodeSnippetService codeSnippetService)
        {
            this.codeSnippetService = codeSnippetService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CodeSnippet>> Get()
        {
            return codeSnippetService.Get();
        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CodeSnippet> Get(string id)
        {
            return codeSnippetService.Get(id);
        }

        [HttpPost("create")]
        public ActionResult CreateSnippet([FromForm] CodeSnippet codeSnippet)
        {
            codeSnippetService.Create(codeSnippet);
            return Redirect("/");
        }

        [HttpPost("delete")]
        public ActionResult DeleteCodeSnippet([FromQuery] string id)
        {
            codeSnippetService.Delete(id);
            return Redirect("/");
        }

        [HttpPost("EditCodeSnippet")]
        public ActionResult EditCodeSnippet([FromForm] CodeSnippet codeSnippet)
        {
            codeSnippetService.Edit(codeSnippet.Id, codeSnippet);
            
            return Redirect("/Index");
        }
    }
}
