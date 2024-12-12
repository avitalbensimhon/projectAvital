using Microsoft.AspNetCore.Mvc;
using Project.core.model;
using Project.core.Servies;
using projectAvital.Controllers;

using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private IGuideServies _guideServies;
        // GET: api/<GuideController>
        public GuideController(IGuideServies  guideServies)
        {
            _guideServies = guideServies;
        }
        [HttpGet]
        public IEnumerable<Guide> Get()
        {
            return _guideServies.GetGuides();
        }

        // GET api/<GuideController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
           Guide guide = _guideServies.GetGuide(id);
            if (guide == null)
            {
                return NotFound();
            }
            return Ok(guide);
        }

        // POST api/<GuideController>
        [HttpPost]
        public Guide Post([FromBody] Guide newGuide)
        {
           _guideServies.AddGuide(newGuide);
            return newGuide;
        }

        // PUT api/<GuideController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Guide guide) 
        {
            _guideServies.UpdateGuide(id, guide);
        }

        // DELETE api/<GuideController>/5
        [HttpDelete("{id}")]
        public ActionResult ChangeStatus(string id)
        {
            if (_guideServies.ChangeGuideStatus(id))
                return Ok(id);
            return NotFound();
        }
    }
}
