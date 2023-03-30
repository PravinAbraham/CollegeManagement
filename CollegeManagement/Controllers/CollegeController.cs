using CollegeManagement.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeBusiness _collegeBusiness;
        public CollegeController(ICollegeBusiness collegeBusiness)
        {
            _collegeBusiness = collegeBusiness;
        }


        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<College>> GetAll()
        {
            return Ok(_collegeBusiness.GetAll());
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody] College college)
        {
            return Ok(_collegeBusiness.Create(college));
        }


        [HttpPut("Update")]
        public IActionResult Update(int Id, College college)
        {
            return Ok(_collegeBusiness.Update(Id, college));
        }


        [HttpPut("UpdateName")]
        public IActionResult UpdateName(int Id, College college)
        {
            return Ok(_collegeBusiness.UpdateName(Id,college));
        }


        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
                return Ok(_collegeBusiness.Delete(Id));
        }


        [HttpGet("GetById/{Id}")]
        public IActionResult GetById(int Id)
        {
                return Ok(_collegeBusiness.GetById(Id));
        }



        [HttpGet("Search")]
        public List<College> GetBySelectedRow(string Search)
        {
                return _collegeBusiness.GetBySelectedRow(Search);
        }

            
        [HttpGet("Offset")]
        public List<College> Offset(int limit, int offset)
        {
            return _collegeBusiness.Offset(limit, offset);
        }



        [HttpGet("Omit")]
        public List<College> Omit(int omit)
        {
            return _collegeBusiness.Omit(omit);
        }



        [HttpGet("Pagination")]
        public List<College> Pagination(int page, int pageSize)
        {
            return _collegeBusiness.Pagination(page, pageSize);
        }


        [HttpGet("Filter")]
        public List<College> Filter(string Search, int page, int pageSize)
        {
            return _collegeBusiness.Filter(Search, page, pageSize);
        }


        [HttpGet("Cursor")]
        public List<College> Cursor(int page, int pageSize)
        {
            return _collegeBusiness.Cursor(page, pageSize);
        }



        [HttpGet("Count")]
        public List<College> Info(int page, int pageSize)
        {
            return _collegeBusiness.Info(page, pageSize);
        }



        [HttpGet("Info")]
        public PageInfo pageInfos()
        {
            return _collegeBusiness.pageInfos();
        }
    }
}
