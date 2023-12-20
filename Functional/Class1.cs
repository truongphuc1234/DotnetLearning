
namespace Functional;

public class Film
{

    public string? Genre;

    public int BoxOfficeRevenue { get; internal set; }
    public string? Title { get; internal set; }
    public int Budget { get; internal set; }
    public int Revenue { get; internal set; }
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

    public IEnumerable<Film> GetFilmByDirectorDescending()
    {
        var film = GetAllFilmsForDirector("Jean-Piere").OrderByDescending(x => x.BoxOfficeRevenue);
        foreach (var f in film)
        {

        }
        var formattedFilms = film.Select((x, i) => $"{i} {x.Title}");
        return film;

    }

    public int GetRevenue()
    {
        var films = GetAllFilmsForDirector("Nolan");
        var (totalBuget, totalRevenue) = films.Aggregate(
                (Budget: 0, Revenue: 0),
                (acc, cur) => (acc.Budget + cur.Budget, acc.Revenue + cur.Revenue)
                );
    }


    private IEnumerable<Film> GetAllFilmsForDirector(string str)
    {
        throw new NotImplementedException();
    }

    private List<Film> GetAllFirms()
    {
        throw new NotImplementedException();
    }

}


public class Example4
{

    public void DoSomething()
    {
        var a = Enumerable.Range(8, 5);
        var s = string.Join(", ", a);
        var coords = Enumerable.Range(0, 5)
            .SelectMany(x => Enumerable.Range(0, 5)
                    .Select(y => (X: x, Y: y)));
        var backwardCoords = Enumerable.Repeat(5, 5)
            .Select((x, i) => x - i)
            .SelectMany(x => Enumerable.Repeat(5, 5).Select((y, i) => (x, y - 1)));
    }
}

