using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseTraining.Data.Entities
{
    public class Storage
    {
        [Key]
        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        public Guid PostOfficeId { get; set; }

        public PostOffice PostOffice { get; set; }
    }
}