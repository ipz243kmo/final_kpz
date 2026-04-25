public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    void Add(Recipe recipe);
    void Update(Recipe recipe);
    void Delete(Guid id);
}