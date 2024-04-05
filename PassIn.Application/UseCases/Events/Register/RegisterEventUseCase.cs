using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure.Contracts;

namespace PassIn.Application.UseCases.Events.Register;
public class RegisterEventUseCase
{
    private readonly IEventRepository _repository;
    public RegisterEventUseCase(IEventRepository repository) => _repository = repository;
    public ResponseRegisterEventJsoncs Execute(RequestEventJson request)
    {
       Validate(request);     

        var id = _repository.Add(request);
        return new ResponseRegisterEventJsoncs
        {
            Id = id
        };
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
