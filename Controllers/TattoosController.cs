using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tattoo_me_dotnet.Models;

namespace tattoo_me_dotnet.Controllers
{
    [Route("api/[controller]")]
    public class TattoosController : Controller
    {
        public TattooContext _db { get; private set; }
        public TattoosController(TattooContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Tattoo> Get()
        {
            return _db.Tattoos;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Tattoo Get(string id)
        {
            return _db.Tattoos.Find(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Tattoo tattoo)
        {
            if (TryValidateModel(tattoo))
            {
                tattoo.Id = Guid.NewGuid().ToString();
                _db.Tattoos.Add(tattoo);
                _db.SaveChanges();
                return tattoo.Id;
            }
            else
            {
                return "Could Not Create Tattoo";
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public Tattoo Put(string id, [FromBody]Dictionary<string, string> tags)
        {
            // System.Console.WriteLine(tags);
            // tags = new List<string>();
            // List<string> test = new List<string>();
            // test.Add("test1");
            // test.Add("test2");
            // test.Add("test3");
            Tattoo tattoo = _db.Tattoos.Find(id);

            List<string> tagList = new List<string>();
            foreach (KeyValuePair<string, string> item in tags)
            {
                tagList.Add(item.Value);
            }

            // System.Console.WriteLine(tags);
            foreach(string t in tagList)
            {
                Tag tag = _db.Tags.Find(t);
                if (tag != null)
                {
                    tattoo.Tags.Add(_db.TagNames.Find(t));
                    tag.Tattoos.Add(tattoo);
                    _db.SaveChanges();
                }
                else
                {
                    Tag newTag = new Tag();
                    newTag.Name = t;
                    _db.Tags.Add(newTag);
                    TagName newTagName = new TagName();
                    newTagName.Name = t;
                    _db.TagNames.Add(newTagName);
                    System.Console.WriteLine(newTagName);
                    // tattoo.Tags.Add(newTagName);
                    // newTag.Tattoos.Add(tattoo);
                    _db.SaveChanges();
                    System.Console.WriteLine(newTag);
                    System.Console.WriteLine(newTagName);
                }
            };
            return tattoo;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
