using ExpenseTrackerApi.Data;
using ExpenseTrackerApi.DTOs;
using ExpenseTrackerApi.Mappper;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ApplicationDbContext _context;

        public ExpenseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetExpenseDTO>> GetAllExpensesAsync(string userId)
        {
            var expenses = await _context.Expenses.Where(e => e.UserId == userId).ToListAsync();

            return expenses.Select(ExpenseMapper.ToDto).ToList();
        }

        public async Task<GetExpenseDTO> GetExpenseByIdAsync(string userId, int expenseId)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e =>
                e.UserId == userId && e.Id == expenseId
            );

            return expense == null ? null : ExpenseMapper.ToDto(expense);
        }

        public async Task<GetExpenseDTO> AddExpenseAsync(string userId, AddExpenseDTO dto)
        {
            var expense = ExpenseMapper.FromDto(userId, dto);

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return ExpenseMapper.ToDto(expense);
        }

        public async Task<bool> UpdateExpenseAsync(string userId, int expenseId, AddExpenseDTO dto)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId);
            if (expense == null)
                return false;

            expense.Category = dto.Category;
            expense.Amount = dto.Amount;
            expense.Description = dto.Description;
            expense.ExpenseDate = dto.ExpenseDate;

            _context.Expenses.Update(expense);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteExpenseAsync(string userId, int expenseId)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId);
            if (expense == null)
                return false;

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
