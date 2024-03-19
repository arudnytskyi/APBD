namespace tut2;

public class Container
{
    private int mass;
    private int height;
    private int tareHeight;
    private int depth;
    private int number;
    private string type;

    public string SerialNumber => $"KON-{type}-{number}";
}