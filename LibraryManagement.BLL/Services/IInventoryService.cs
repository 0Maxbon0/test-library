namespace LibraryManagement.BLL.Services;
    using Models;
{
    public interface IInventoryService
{
    Task<int> GetTotalItemsAsync();
    Task<int> GetLowStockItemsAsync();
    Task<int> GetUsersCountAsync();
    Task<List<ActivityModel>> GetRecentActivityAsync();
}

}
