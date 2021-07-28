using System;
using System.Collections.Generic;

namespace DatabaseTraining.Data.Entities
{
    public class PostOffice
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Storage> Storages { get; set; }
    }
}