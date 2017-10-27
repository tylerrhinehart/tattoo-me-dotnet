using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tattoo_me_dotnet.Models;

namespace tattoo_me_dotnet.Controllers
{
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        public TattooContext _db { get; private set; }
        public TagsController(TattooContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Tag> Get()
        {
            return _db.Tags;
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
