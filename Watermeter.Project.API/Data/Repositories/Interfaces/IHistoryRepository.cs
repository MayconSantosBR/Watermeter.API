namespace Watermeter.Project.API.Data.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task Save(History history);
        Task<List<History>> GetHistories(int idOwner);
        Task<bool> DeleteAll(int idOwner);
    }
}