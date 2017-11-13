using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


namespace TodoApp.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly HttpClient _httpClient;

        public TodoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        //GET /api/Todo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<KeyValuePair<string, int>> todos = new List<KeyValuePair<string, int>>();
            todos.Add(new KeyValuePair<string, int>("Eat", 3));
            todos.Add(new KeyValuePair<string, int>("Sleep", 5));
            return Json(todos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
