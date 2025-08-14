namespace ExpenseTrackerApi.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime ExpenseDate { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
