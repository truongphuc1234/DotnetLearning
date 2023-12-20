namespace ExampleTuple;

public class ExampleTuple1
{
    public void Method()
    {
        var filmIds = new[] { 4664, 6718, 1 };
        var filmWithCast = filmIds.Select(x => (film: GetFilm(), castFilm: GetCastFilm()));
        var renderedFilmDetails = filmWithCast.Select(
            x =>
                $"Title {x.film.Title} Director: {x.film.Director} Cast : {string.Join(",", x.castFilm)}"
        );
    }

    private string[] GetCastFilm()
    {
        return new string[] { "1", "2" };
    }

    private Film GetFilm()
    {
        throw new NotImplementedException();
    }
}

internal class Film
{
    public string? Title;
    public string? Director;
}
