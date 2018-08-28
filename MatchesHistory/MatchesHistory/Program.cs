namespace MatchesHistory
{
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.HistoryServices;

    public class Program
    {
        static void Main(string[] args)
        {
            IPastGamesService read = new PastGamesService();

            read.ReadXMLAsync();
        }
    }
}
