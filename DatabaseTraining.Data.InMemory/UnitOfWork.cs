using System.Threading.Tasks;
using DatabaseTraining.Data.Abstractions;

namespace DatabaseTraining.Data.InMemory
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task SaveAsync()
        {
            // commit changes
            return Task.CompletedTask;
        }
    }
}