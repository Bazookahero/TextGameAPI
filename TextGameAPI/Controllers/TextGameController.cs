using Microsoft.AspNetCore.Mvc;
using TextGameAPI.Models.ViewModels;
using TextGameAPI.Models;
using TextGameAPI.Data;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TextGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextGameController : ControllerBase
    {
        private readonly TextGameDbContext _db;

        public TextGameController(TextGameDbContext db)
        {
            _db = db;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        [EnableCors("AllowAll")]
        public async Task Post(CharacterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                PlayerCharacter newChar = new PlayerCharacter()
                {
                    CharName = viewModel.CharName,
                    CharRace = viewModel.CharRace,
                    CharGender = viewModel.CharGender
                };
                _db.Characters.Add(newChar);
                await _db.SaveChangesAsync();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
