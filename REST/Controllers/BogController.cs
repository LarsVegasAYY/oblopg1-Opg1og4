using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Opg1;
namespace REST.Controllers
{
    [Route("api/bog/")]
    [ApiController]
    public class BogController : ControllerBase
    {

        private static readonly List<Bog> books = new List<Bog>()
        {
            new Bog("Mit harem og mig!", "Lars den store", 222, "1234567890123"),
            new Bog("Hvordan grapefrugt ændrede mit liv!", "Lars den store", 222, "1234567890124"),
            new Bog("Wife mass exodus", "Lars den store", 222, "1234567890125"),
            new Bog("NO THIS IS PATRICK", "Lars den store", 222, "1234567890126"),
            new Bog("Hvis bare jeg var Tom", "Lars den store", 222, "1234567890127")
        };
        

        // GET: api/Bog
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return books;
        }

        // GET: api/Bog/5
        [HttpGet("{isbn13}", Name = "Get")]
        public Bog Get(string isbn13)
        {
            return books.Find(x=>x.Isbn13==isbn13);
        }

        // POST: api/Bog
        [HttpPost]
        public void Post([FromBody] Bog bog)
        {
            books.Add(bog);
        }

        // PUT: api/Bog/5
        [HttpPut("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog updateBog)
        {
            Bog bog = Get(isbn13);
            if (bog != null)
            {
                bog.Titel = updateBog.Titel;
                bog.Forfatter = updateBog.Forfatter;
                bog.Sidetal = updateBog.Sidetal;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            books.Remove(Get(isbn13));
        }
    }
}
