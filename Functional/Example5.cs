namespace Example5s;

public class Example5
{
    public void Parse(string filePath)
    {
        var text = File.ReadAllText(filePath)
          .Split(Environment.NewLine)
          .Select(x => x.Split(",").ToArray())
          .Select(x => new Story
          {
              SeasonNumber = int.Parse(x[0]),
              StoryName = x[1],
              Writer = x[2],
              Director = x[3],
              NumberOfEspisodes = int.Parse(x[4]),
              NumberOfMissingEspisodes = int.Parse(x[5])
          })
          .GroupBy(x => x.SeasonNumber)
          .Select(x => x.Aggregate(
                (S: x.Key, NumEps: 0, NumMisEsp: 0),
                (acc, val) => (acc.S, acc.NumEps + val.NumberOfEspisodes, acc.NumMisEsp + val.NumberOfMissingEspisodes)))
          .Select(x => new ReportLine
          {
              SeasonNumber = x.S,
              NumberOfEspisodes = x.NumEps,
              NumberOfMissingEspisodes = x.NumMisEsp,
              PercentageMissing = (x.NumMisEsp / x.NumEps) * 100
          });
    }
}

internal class ReportLine
{
    public int SeasonNumber { get; set; }
    public int NumberOfEspisodes { get; set; }
    public int NumberOfMissingEspisodes { get; set; }
    public int PercentageMissing { get; set; }
}

internal class Story
{
    public int SeasonNumber { get; set; }
    public string StoryName { get; set; }
    public string Writer { get; set; }
    public string Director { get; set; }
    public int NumberOfEspisodes { get; set; }
    public int NumberOfMissingEspisodes { get; set; }
}
