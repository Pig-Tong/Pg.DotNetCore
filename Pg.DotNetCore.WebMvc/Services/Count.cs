using Pg.DotNetCore.WebMvc.Services;

public class Count : ICount
{
    private int _count;

    public int MyCount()
    {
        return _count++;
    }
}