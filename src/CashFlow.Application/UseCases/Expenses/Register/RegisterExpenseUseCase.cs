using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase {
    public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request) {
        Validate(request);

        return new ResponseRegisteredExpenseJson();
    }

    private void Validate(RequestRegisterExpenseJson request) {
        var isTitleEmpty = string.IsNullOrWhiteSpace(request.Title);

        if (isTitleEmpty) {
            throw new ArgumentException("The title is required");
        }

        if (request.Amount <= 0) {
            throw new ArgumentException("The amount must be greater than zero");
        }

        var result = DateTime.Compare(request.Date, DateTime.UtcNow);

        var isDateInTheFuture = result > 0;

        if (isDateInTheFuture) {
            throw new ArgumentException("The date cannot be in the future");
        }

        var isPaymentTypeValid = Enum.IsDefined(request.PaymentType);

        if (!isPaymentTypeValid) {
            throw new ArgumentException("The payment type is invalid");
        }
    }
}