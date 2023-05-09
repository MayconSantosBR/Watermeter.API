using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.History;

namespace Watermeter.Project.API.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<History>> GetHistoriesAsync(int idOwner);
        Task<HistoryCalcs> GetCalculationsAsync(int idOwner);
    }
}