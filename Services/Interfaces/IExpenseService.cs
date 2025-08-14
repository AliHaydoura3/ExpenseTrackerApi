using ExpenseTrackerApi.DTOs;

namespace ExpenseTrackerApi.Services
{
    public interface IExpenseService
    {
        public Task<IEnumerable<GetExpenseDTO>> GetAllExpensesAsync(string userId);
        public Task<GetExpenseDTO> GetExpenseByIdAsync(string userId, int expenseId);
        public Task<GetExpenseDTO> AddExpenseAsync(string userId, AddExpenseDTO dto);
        public Task<bool> UpdateExpenseAsync(string userId, int expenseId, AddExpenseDTO dto);
        public Task<bool> DeleteExpenseAsync(string userId, int expenseId);
    }
}
