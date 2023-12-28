using StockServiceHttpClient.Models;

namespace StockServiceHttpClient.StockService
{
    public interface IStock
    {
        Task<StockModel> GetStockReport(string StockName);

        Task<List<StockSymbol>> GetStockSymbol();
    }
}
