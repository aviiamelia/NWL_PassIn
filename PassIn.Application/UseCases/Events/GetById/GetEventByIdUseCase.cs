using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure.Contracts;

namespace PassIn.Application.UseCases.Events.GetById;
public class GetEventByIdUseCase
{
    private readonly IEventRepository _repository;
    public GetEventByIdUseCase (IEventRepository repository) => _repository = repository;
    public ResponseEventJson Execute(Guid id)
    {
 
        var entity = _repository.GetById(id);
        if (entity is null)
        {
            throw new PassInException("Event not found");
        }
        return new ResponseEventJson 
        {
            Id = entity.Id,
            MaximumAttendees = entity.Maximum_Attendees,
            Title = entity.Title,
            Details = entity.Details,
            AttendeesAmount = -1
        };

    }
}
