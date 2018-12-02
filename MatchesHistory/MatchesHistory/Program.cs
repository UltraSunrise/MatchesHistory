namespace MatchesHistory
{
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using MatchesHistory.Services.HistoryServices;
    using System.Threading.Tasks;

    public class Program
    {
        static void Main(string[] args)
        {
            IDatabaseService dbService = new DatabaseService();
            long tempId = dbService.GetLastAddedMatch();
            IPastGamesService read = new PastGamesService();

            var task1 = Task.Factory.StartNew(() => read.ConvertJSON(tempId));
            var task2 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+1));
            var task3 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+2));
            var task4 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+3));
            var task5 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+4));
            var task6 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+5));
            var task7 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+6));
            var task8 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+7));
            var task9 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+8));
            var task10 = Task.Factory.StartNew(() => read.ConvertJSON(tempId+9));

            Task.WaitAll(task1,task2, task3, task4,task5,task6,task7,task8,task9,task10);
        }
    }
}
