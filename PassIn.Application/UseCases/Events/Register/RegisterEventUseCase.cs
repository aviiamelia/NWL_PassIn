using PassIn.Communication.Requests;

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
            throw new ArgumentException("The Maximum attends is invalid");
        }
        if (string.IsNullOrWhiteSpace(request.Title)) {
            throw new ArgumentException("Title is invalid");
        }
        if (string.IsNullOrWhiteSpace(request.Details))
        {
            throw new ArgumentException("Details is invalid");
        }

    }
}
