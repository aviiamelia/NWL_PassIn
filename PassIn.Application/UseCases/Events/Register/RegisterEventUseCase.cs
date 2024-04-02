using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using PassIn.Infrastructure;
using PassIn.Infrastructure.Entities;

namespace PassIn.Application.UseCases.Events.Register;
public class RegisterEventUseCase
{
    public ResponseRegisterEventJsoncs Execute(RequestEventJson request)
    {
       Validate(request);
        var dbContext = new PassInDbContext();
        var entity = new Event
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "_")
        };

        dbContext.Events.Add(entity);
        dbContext.SaveChanges();
        return new ResponseRegisterEventJsoncs
        {
            Id = entity.Id
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
