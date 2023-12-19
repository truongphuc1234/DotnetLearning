
namespace Functional;

public class Film
{

    public string? Genre;
}

public class DataStore
{
    public IEnumerable<Film> GetFilmsByGenre(string genre)
    {
        var allFilms = GetAllFirms();
        var chosenFilms = new List<Film>();
        foreach (var f in allFilms)
        {
            if (f.Genre == genre)
            {
                chosenFilms.Add(f);
            }
        }
        return chosenFilms;
    }

    public IEnumerable<Film> GetFilmsByGenre2(IEnumerable<Film> source, string genre) => source.Where(x => x.Genre == genre);

    private List<Film> GetAllFirms()
    {
        throw new NotImplementedException();
    }
}
