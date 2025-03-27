namespace cw2;

public interface IHazardNotifier
{
    void NotifyHazard(string message);
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}
