namespace MatchesHistory
{
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.HistoryServices;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            IPastGamesService read = new PastGamesService();

            var task1 = Task.Factory.StartNew(() => read.ConvertJSON());
            var task2 = Task.Factory.StartNew(() => read.LastPlayedGames());

            Task.WaitAll(task1, task2);
        }
    }
}
