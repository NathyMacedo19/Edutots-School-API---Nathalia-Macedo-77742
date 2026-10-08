namespace Edutots_School_API____Nathalia_Macedo_77742.Services;

// Remembers which schools are favourites
public class FavouritesService
{
    private readonly HashSet<int> _ids = new();

    public int Count => _ids.Count;

    public bool IsFavourite(int schoolId)
    {
        return _ids.Contains(schoolId);
    }

    // Add the school if it isn't a favourite, remove it if it is
    public void Toggle(int schoolId)
    {
        if (!_ids.Add(schoolId))
        {
            _ids.Remove(schoolId);
        }
    }
} 