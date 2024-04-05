using PassIn.Communication.Requests;
using PassIn.Infrastructure.Entities;

namespace PassIn.Infrastructure.Contracts;
public interface IEventRepository
{
    public Event? GetById(Guid id);
    public Guid Add(RequestEventJson request);
}
