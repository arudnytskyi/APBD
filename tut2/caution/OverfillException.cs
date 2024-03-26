namespace tut2.caution;

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message)
    {
    }
}