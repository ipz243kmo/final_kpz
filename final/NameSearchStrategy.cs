public class NameSearchStrategy : ISearchStrategy
{
    public IEnumerable<Recipe> Filter(IEnumerable<Recipe> source, string query) =>
        source.Where(r => r.Title.Contains(query, StringComparison.OrdinalIgnoreCase));
}