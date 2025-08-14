using ExpenseTrackerApi.DTOs;
using ExpenseTrackerApi.Models;

namespace ExpenseTrackerApi.Mappper
{
    public static class ExpenseMapper
    {
        public static GetExpenseDTO ToDto(Expense expense)
        {
            return new GetExpenseDTO
            {
                Id = expense.Id,
                Amount = expense.Amount,
                Description = expense.Description,
                Category = expense.Category,
                ExpenseDate = expense.ExpenseDate,
            };
        }

        public static Expense FromDto(string userId, AddExpenseDTO dto)
        {
            return new Expense
            {
                UserId = userId,
                Amount = dto.Amount,
                Description = dto.Description,
                Category = dto.Category,
                ExpenseDate = dto.ExpenseDate,
            };
        }
    }
}
