using System.Threading.Tasks;
using DatabaseTraining.Data.Abstractions;
using DatabaseTraining.Data.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseTraining.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<PostOffice> _postOfficeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IRepository<PostOffice> postOfficeRepository, IUnitOfWork unitOfWork)
        {
            _postOfficeRepository = postOfficeRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("postOffices")]
        public async Task<IActionResult> GetPostOffices()
        {
            var postOffices = await _postOfficeRepository.FindAsync(x => true);

            return Ok(postOffices);
        }

        [HttpPost("postOffices")]
        public async Task<IActionResult> AddPostOffice([FromBody] PostOffice postOffice)
        {
            _postOfficeRepository.Add(postOffice);

            await _unitOfWork.SaveAsync();

            return Created(HttpContext.Request.GetDisplayUrl(), postOffice);
        }
    }
}