using Okane.Application.Auth;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesHandler
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUserSession _userSession;

    public RetrieveExpensesHandler(IExpensesRepository expensesRepository, IUserSession userSession)
    {
        _expensesRepository = expensesRepository;
        _userSession = userSession;
    }

    public IEnumerable<ExpenseResponse> Handle() =>
        _expensesRepository
            .All()
            .Where(e => e.UserId == _userSession.GetCurrentUserId())
            .Select(expense => expense.ToExpenseResponse());
}