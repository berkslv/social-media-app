namespace Core.Utilities.Query
{
    public interface IFilterParameters
    {
        string OrderBy { get; set; }
        string Filter { get; set; }
    }
}