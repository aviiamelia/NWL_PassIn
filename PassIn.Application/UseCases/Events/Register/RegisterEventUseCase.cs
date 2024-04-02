using PassIn.Communication.Requests;
using PassIn.Exceptions;

namespace PassIn.Application.UseCases.Events.Register;
public class RegisterEventUseCase
{
    public void Execute(RequestEventJson request)
    {
       Validate(request);
    }

    private void Validate(RequestEventJson request) 
    {
        
        if(request.MaximumAttendees <= 0)
        {
            throw new PassInException("The Maximum attends is invalid");
        }
        if (string.IsNullOrWhiteSpace(request.Title)) {
            throw new PassInException("Title is invalid");
        }
        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new PassInException("Details is invalid");
        }

    }
}
