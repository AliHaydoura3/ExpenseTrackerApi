using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi.Services
{
    public interface ITokenService
    {
        string GenerateToken(ApplicationUser user);
    }
}
