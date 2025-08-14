using Microsoft.AspNetCore.Identity;

namespace ExpenseTrackerApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Expense> Expenses = new List<Expense>();
    }
}
