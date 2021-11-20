using ZhetistikApp.Api.Models;

namespace ZhetistikApp.Api.Interfaces
{
    public interface IPortfolioRepository
    {
        //GET portfolio by id
        //GET portfolio by name and surname
        //GET portfolio only published portfolios
        //GET portfolio by placement
        //CREATE portfolio
        //UPDATE portfolio
        //DELETE portfolio
        public Task<Portfolio> GetPortfolioByIdAsync(int id);
        public Task<Portfolio> GetPortfolioByPersonAsync(string firstName, string lastName);
        public Task<IEnumerable<Portfolio>> GetPublishedPortfolios(bool isPublished);
        public Task<IEnumerable<Portfolio>> GetPortfoliosByLocationAsync(string countryName, string cityName);
        public Task<int> CreatePortfolioAsync(Portfolio portfolio);
        public Task DeletePortfolioAsync(int id);
        public Task UpdatePortfolioAsync(int id, Portfolio portfolio);
    }
}
