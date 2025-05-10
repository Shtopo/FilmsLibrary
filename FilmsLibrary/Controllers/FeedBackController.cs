using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibrary.Controllers
{
    [ApiController]
    [Route("FeedBack")]
    [Authorize]
    public class FeedBackController : ControllerBase
    {
        private readonly FilmsContext _context;
        private readonly IFeedBackService _feedBackService;

        public FeedBackController(FilmsContext context, IFeedBackService feedBackService)
        {
            _context = context;
            _feedBackService = feedBackService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFeedBack([FromBody] FeedBackRequest request)
        {
           var feedback = await _feedBackService.AddFeedBackAsync(request);

            return Ok(feedback);
        }

        [HttpGet("feedbacks")]
        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            var feedbacks = await _feedBackService.GetAllFeedbacksAsync();

            return feedbacks;
        }

        [HttpPost("changeFeedBack")]
        public async Task<IActionResult> ChangeFeedBack([FromQuery] int feedBackId, [FromQuery] string feedBackDescription)
        {
            var feedback = await _feedBackService.ChangeFeedBackAsync(feedBackId, feedBackDescription);

            return Ok(feedback);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeedBack([FromQuery] int feedbackId)
        {
            var feedBack = await _feedBackService.DeleteFeedBackAsync(feedbackId);

            if (feedBack == null)
            {
                return NotFound("Feedback not found");
            }

            return Ok(feedBack);
        }
    }
}
