using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;
using Watermeter.Project.API.Data.Repositories.Interfaces;
using Watermeter.Project.API.Entities;
using Watermeter.Project.API.Models.History;
using Watermeter.Project.API.Services.Interfaces;
using IHistoryRepository = Watermeter.Project.API.Data.Repositories.Interfaces.IHistoryRepository;

namespace Watermeter.Project.API.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository repository;

        public HistoryService(IHistoryRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<History>> GetHistoriesAsync(int idOwner)
        {
            try
            {
                return await repository.GetHistories(idOwner);
            }
            catch
            {
                throw;
            }
        }
        public async Task<HistoryCalcs> GetCalculationsAsync(int idOwner)
        {
            try
            {
                var histories = await repository.GetHistories(idOwner);
                var historiesOfMonth = histories.Where(c => c.Date.Month.Equals(DateTime.Now.Month));
                var historiesOfWeek = histories.Where(c => (c.Date.Day.CompareTo(DateTime.Now.Day) <= 7) && (c.Date.Day.CompareTo(DateTime.Now.Day) >= 0));
                var m3PerMonth = Convert.ToDouble(historiesOfMonth.Sum(c => c.Waterflow)) / 1000;
                var cost = 0.0;

                if (m3PerMonth >= 1 && m3PerMonth <= 10)
                    cost = m3PerMonth * 1.96;
                else if (m3PerMonth >= 11 && m3PerMonth <= 25)
                    cost = m3PerMonth * 9.11;
                else if (m3PerMonth >= 26 && m3PerMonth <= 50)
                    cost = m3PerMonth * 12.18;
                else if (m3PerMonth > 50)
                    cost = m3PerMonth * 15.32;
                else
                    cost = 0.0;

                HistoryCalcs calcs = new()
                {
                    AverageConsumeByDay = Convert.ToDouble(histories.Sum(c => c.Waterflow)) / histories.Count(),
                    AverageConsumeByMonth = Convert.ToDouble(historiesOfMonth.Sum(c => c.Waterflow)) / historiesOfMonth.Count(),
                    AverageConsumeByWeek = Convert.ToDouble(historiesOfWeek.Sum(c => c.Waterflow)) / historiesOfWeek.Count(),
                    AverageCostPerMonth = cost
                };

                return calcs;
            }
            catch
            {
                throw;
            }
        }
    }
}
