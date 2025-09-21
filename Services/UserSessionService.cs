namespace EventEase.Services;

public class UserSessionService
{
    public Guid SessionId { get; } = Guid.NewGuid();
    public DateTime StartedAt { get; } = DateTime.UtcNow;
    public Dictionary<string, object> Data { get; } = new();

    public T? Get<T>(string key) => Data.TryGetValue(key, out var v) ? (T?)v : default;
    public void Set<T>(string key, T value) => Data[key] = value!;
}
