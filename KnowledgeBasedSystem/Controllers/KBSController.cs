using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBasedSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KBSController : ControllerBase
    {
        private readonly IKBSRepository _kbsRepository;
        private readonly ITreatmentService _treatmentService;
        private readonly IKBSService _kBSService;
        public KBSController(IKBSRepository kbsRepository, ITreatmentService treatmentService, IKBSService kBSService)
        {
            _kbsRepository = kbsRepository;
            _treatmentService = treatmentService;
            _kBSService = kBSService;   
        }
        [HttpGet("getKBS")]
        public async Task<IActionResult> GetKnowledgeBase()
        {
            var kbs = await _kbsRepository.GetAsync();
            return Ok(kbs);
        }
        [HttpPost("getAdvisory")]
        public async Task<IActionResult> GetById(KBSModel kBS)
        {
            var res = await _treatmentService.GetAnswer(kBS);
            return Ok(res);
        }
        [HttpPost("getInfo")]
        public async Task<IActionResult> GetInfo(string status)
        {
            var res = await _kBSService.GetInfoFromStatus(status);
            return Ok(res);
        }
    }
}
