namespace BandTracker.Core.Bands;

public class Show
{
    public Guid ShowId { get; init; }
    public DateTime Date { get; init; }
    public string Location { get; init; } = null!;

    public override string ToString()
    {
        return $"{Location} - {Date}";
    }
}
