using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;

namespace PassIn.Application.UseCases.Events.GetById;
public class GetEventByIdUseCase
{
    public ResponseEventJson Execute(Guid id)
    {
        var dbContext = new PassInDbContext();
        var entity = dbContext.Events.Find(id);
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
