namespace FilmsLibraryBLL.Abstractions.Services
{
    public interface ITokenProvider
    {
        string GenerateToken(int userId);
    }
}
