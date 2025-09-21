using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private readonly List<Event> _events;

    public EventService()
    {
        _events = Seed();
    }

    public Task<List<Event>> GetAllAsync() => Task.FromResult(_events.OrderBy(e => e.Date).ToList());

    public Task<Event?> GetByIdAsync(int id) => Task.FromResult(_events.FirstOrDefault(e => e.Id == id));

    public Task RegisterAsync(int eventId, int tickets)
    {
        var ev = _events.First(e => e.Id == eventId);
        ev.RegisteredCount = Math.Min(ev.RegisteredCount + tickets, ev.Capacity);
        return Task.CompletedTask;
    }

    private static List<Event> Seed()
    {
        var start = DateTime.Today.AddDays(1);
        return Enumerable.Range(1, 200).Select(i => new Event
        {
            Id = i,
            Name = $"Sample Event #{i}",
            Date = start.AddDays(i),
            Location = i % 2 == 0 ? "New York, NY" : "San Francisco, CA",
            Description = "A demo event used to showcase the EventEase app.",
            Capacity = 100 + (i % 5) * 50
        }).ToList();
    }
}
