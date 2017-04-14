namespace DataCat.Core.Services
{
    using System.Threading.Tasks;
    using DataCat.Core.Entity;
    using MongoDB.Driver;

    public interface IWidgetService
    {
        IMongoCollection<Widget> Collection { get; }

        Task<Widget> Create(Widget widget);
        Task<Widget> Delete(string id);
        Task<Widget> Find(string id);
        Task<Widget> Update(Widget widget);
    }
}