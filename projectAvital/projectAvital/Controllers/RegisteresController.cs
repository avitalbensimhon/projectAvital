using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project.core.Servies;
using System;
using Project.core.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteresController : ControllerBase
    {
        IRegisteresServies _registeresServies;
        // GET: api/<RegisteresController>
        public RegisteresController(IRegisteresServies  registeresServies)
        {
           _registeresServies = registeresServies;
        }
        [HttpGet]
        public IEnumerable<Registeres> Get()
        {
            return _registeresServies.GetRegister();
        }

        // GET api/<RegisteresController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Registeres registeres = _registeresServies.GetRegisteres(id);
            if (registeres == null)
            {
                return Ok(registeres);
            }
            return NotFound(registeres);
        }

        // POST api/<RegisteresController>
        [HttpPost]
        public Registeres Post([FromBody] Registeres newRegisteres)
        {
            return _registeresServies.AddRegisteres(newRegisteres);
        }

        // PUT api/<RegisteresController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Registeres newRegisteres)
        {
           _registeresServies.Updateregisteres(id,newRegisteres);
        }

        // DELETE api/<RegisteresController>/5
        [HttpDelete("{id}")]
        public ActionResult ChangeStatus(string id)
        {
            if (_registeresServies.ChangeRegisteresStatus(id))
                return Ok(id);
            return NotFound();
        }
    }
}
