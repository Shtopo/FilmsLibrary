using FilmsLibraryData.DTOs;
using FilmsLibraryData.Entities;

namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface IFeedBackService
    {
        Task<Feedback> AddFeedBackAsync(FeedBackRequest request);
        Task<List<Feedback>> GetAllFeedbacksAsync();
        Task<Feedback> ChangeFeedBackAsync(int feedBackId, string feedBackDescription);
        Task<Feedback> DeleteFeedBackAsync(int feedbackId);
    }
}
