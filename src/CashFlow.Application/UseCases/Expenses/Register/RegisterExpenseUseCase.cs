using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase {
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request) {
        // TODO: Implement validations
        return new ResponseRegisteredExpenseJson();
    }
}