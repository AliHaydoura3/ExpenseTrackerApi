namespace ExpenseTrackerApi.DTOs
{
    public class GetExpenseDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
