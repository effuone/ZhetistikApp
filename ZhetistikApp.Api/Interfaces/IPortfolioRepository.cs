using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<Portfolio> GetPortfolioAsync(int id);
        public Task<IEnumerable<Portfolio>> GetPortfoliosAsync();
        public Task<int> CreatePortfolioAsync(Portfolio portfolio);
        public Task DeletePortfolioAsync(int id);
        public Task UpdatePortfolioAsync(int id, Portfolio portfolio);
    }
}
