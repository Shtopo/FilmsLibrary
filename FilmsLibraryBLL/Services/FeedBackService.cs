using FilmsLibraryBLL.Abstractions.Services;
using FilmsLibraryData.DBContext;
using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmsLibraryBLL.Services
{
    public class FeedBackService : IFeedBackService

    {
        private readonly FilmsContext _context;
        public FeedBackService(FilmsContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddFeedBackAsync(FeedBackRequest request)
        {
            Feedback feedback = new()
            {
                Rating = request.Rating,
                Description = request.Description,
                FilmId = request.FilmId,
                AuthorId = request.AuthorId
            };

            var filmExists = await _context.Films.AnyAsync(f => f.Id == feedback.FilmId);

            var authorExists = await _context.Users.AnyAsync(u => u.Id == feedback.AuthorId);

            if (!filmExists || !authorExists)
            {
                throw new Exception("No folm or author found");
            }
            _context.FeedBacks.Add(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        public async Task<List<Feedback>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _context.FeedBacks.ToListAsync();

            return feedbacks;
        }

        public async Task<Feedback> ChangeFeedBackAsync(int feedBackId, string feedBackDescription)
        {
            var feedback = await _context.FeedBacks.FirstOrDefaultAsync(g => g.Id == feedBackId);
            if (feedback == null)
            {
                throw new Exception("FeedBack not found");
            }

            feedback.Description = feedBackDescription;
            _context.FeedBacks.Update(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> DeleteFeedBackAsync(int feedbackId)
        {
            var feedBack = await _context.FeedBacks.FirstOrDefaultAsync(f => f.Id == feedbackId);

            if (feedBack != null)
            {
                _context.FeedBacks.Remove(feedBack);
                await _context.SaveChangesAsync();
            }
            return feedBack;
        }
    }
}
