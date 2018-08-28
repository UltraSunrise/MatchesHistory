
namespace MatchesHistory.Services.HistoryServices
{
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading;

    public class PastGamesService : IPastGamesService
    {
        IDatabaseService dbService = new DatabaseService();
        private AutoResetEvent waitForConnection = new AutoResetEvent(false);

        public void ReadXMLAsync()
        {
            int count = 0;
            long tempId = dbService.GetLastAddedMatch() - 1;

            HashSet<Result> results = new HashSet<Result>();

            while (true)
            {
                WebResponse response;
                WebRequest request = WebRequest.Create(string.Format(@"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id={0}&key=771F6AEA67F1913B60DB7A66FFB3DE3C", tempId.ToString()));
                try
                {
                     response = request.GetResponse();
                }
                catch (WebException)
                {
                    continue;
                }

                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                Result result = JsonConvert.DeserializeObject<RootObject>(responseData).Result;
                tempId--;

                if (result.StartTime < 1503359935 && result.StartTime > 1500000000)
                    break;

                if (result.Duration < 360 || result.LobbyType != 7)
                    continue;

                results.Add(result);
                count++;

                if (count > 350)
                {
                    count = 0;
                    dbService.AddRangeJSONToDatabase(results);
                    results.Clear();
                }
            }
        }
    }
}
