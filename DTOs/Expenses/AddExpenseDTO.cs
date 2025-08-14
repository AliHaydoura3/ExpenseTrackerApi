using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerApi.DTOs
{
    public class AddExpenseDTO
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Category { get; set; }

        [Required]
        public DateTime ExpenseDate { get; set; }
    }
}
