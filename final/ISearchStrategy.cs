public interface ISearchStrategy
{
    IEnumerable<Recipe> Filter(IEnumerable<Recipe> source, string query);
}