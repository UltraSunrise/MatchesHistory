
namespace MatchesHistory.Services.HistoryServices
{
    using MatchesHistory.Data.Entities;
    using MatchesHistory.Models.Interfacecs;
    using MatchesHistory.Services.DatabaseServices;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading;

    public class PastGamesService : IPastGamesService
    {
        private static IDatabaseService dbService = new DatabaseService();
        private AutoResetEvent waitForConnection = new AutoResetEvent(false);

        private readonly string ERROR_MESSAGE = "{\n\"result\":{\n\"error\":\"Match ID not found\"\n}\n}";
        private readonly string STEAM_KEY = "771F6AEA67F1913B60DB7A66FFB3DE3C";
        private readonly string EXACT_MATCH_URL = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?match_id={0}&key={1}";
        private readonly string LAST_MATCHES_URL = @"https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/V001/?matches_requested=100&key={0}";
        private static List<long> allMatchesIds = dbService.GetAllMatchesIds() ?? new List<long>();

        public void ConvertJSON(long tempId)
        {
            while (true)
            {
                WebResponse response;
                WebRequest request = WebRequest.Create(string.Format(EXACT_MATCH_URL, tempId, STEAM_KEY));
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

                if (responseData == ERROR_MESSAGE)
                {
                    tempId+=10;
                    continue;
                }

                Result result = JsonConvert.DeserializeObject<RootObject>(responseData).Result;
                tempId+=10;

                if (result.Duration < 360 || result.LobbyType != 7)
                    continue;

                if (allMatchesIds.Contains(result.MatchId))
                    continue;
                
                allMatchesIds.Add(result.MatchId);
              
                dbService.AddJSONToDatabase(result);
            }
        }
    }
}
