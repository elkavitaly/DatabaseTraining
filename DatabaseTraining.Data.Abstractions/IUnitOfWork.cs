using System.Threading.Tasks;

namespace DatabaseTraining.Data.Abstractions
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}