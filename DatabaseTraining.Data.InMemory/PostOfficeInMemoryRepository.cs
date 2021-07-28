using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DatabaseTraining.Data.Abstractions;
using DatabaseTraining.Data.Abstractions.Infrastructure;
using DatabaseTraining.Data.Entities;

namespace DatabaseTraining.Data.InMemory
{
    public class PostOfficeInMemoryRepository : IRepository<PostOffice>
    {
        private static readonly List<PostOffice> _postOffices = new()
        {
            new PostOffice
            {
                Id = Guid.NewGuid(),
                Name = "PostOffice1",
                Storages = new List<Storage>
                {
                    new()
                    {
                        Number = 1,
                        Name = "Storage11",
                    },
                    new()
                    {
                        Number = 2,
                        Name = "Storage12",
                    }
                }
            },
            new PostOffice
            {
                Id = Guid.NewGuid(),
                Name = "PostOffice2",
                Storages = new List<Storage>
                {
                    new()
                    {
                        Number = 3,
                        Name = "Storage21",
                    },
                    new()
                    {
                        Number = 4,
                        Name = "Storage22",
                    }
                }
            }
        };

        public void Add(PostOffice entity)
        {
            entity.Id = Guid.NewGuid();

            _postOffices.Add(entity);
        }

        public void Update(PostOffice entity)
        {
            var postOffice = _postOffices.FirstOrDefault(x => x.Id == entity.Id);
            if (postOffice == null)
            {
                throw new KeyNotFoundException();
            }

            _postOffices.Remove(postOffice);
            _postOffices.Add(entity);
        }

        public void Delete(object id)
        {
            var postOffice = _postOffices.FirstOrDefault(x => x.Id == (Guid) id);
            if (postOffice == null)
            {
                throw new KeyNotFoundException();
            }

            _postOffices.Remove(postOffice);
        }

        public Task<bool> Any(Expression<Func<PostOffice, bool>> predicate)
        {
            var result = _postOffices.AsQueryable().Any(predicate);

            return Task.FromResult(result);
        }

        public Task<PostOffice> FindFirstAsync(
            Expression<Func<PostOffice, bool>> predicate,
            bool isTracked = false,
            params string[] includes)
        {
            var result = _postOffices.AsQueryable().FirstOrDefault(predicate);

            return Task.FromResult(result);
        }

        public Task<List<PostOffice>> FindAsync(
            Expression<Func<PostOffice, bool>> predicate,
            SelectParameters parameters = null,
            bool isTracked = false,
            params string[] includes)
        {
            var result = _postOffices.AsQueryable().Where(predicate).ToList();

            return Task.FromResult(result);
        }
    }
}