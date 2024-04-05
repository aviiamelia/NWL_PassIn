using Microsoft.EntityFrameworkCore;
using PassIn.Communication.Requests;
using PassIn.Infrastructure.Contracts;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure.Repositories;
public class EventRepository : IEventRepository
{
    private readonly PassInDbContext _dbContext;

    public EventRepository(PassInDbContext dbContext) => _dbContext = dbContext;

    public Guid Add(RequestEventJson request)
    {
        var entity = new Event
        {
            Title = request.Title,
            Details = request.Details,
            Maximum_Attendees = request.MaximumAttendees,
            Slug = request.Title.ToLower().Replace(" ", "_")
        };

        _dbContext.Events.Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;

    }

    public Event? GetById(Guid id)
    {
        var entity = _dbContext.Events.Find(id);
        return entity;
    }
}
