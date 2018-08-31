namespace MatchesHistory.Models.Interfacecs
{
    using MatchesHistory.Data.Entities;

    interface ICalculatePerformanceService
    {
        void UpdatePlayerInfo(long accountId, Result result);
    }
}
