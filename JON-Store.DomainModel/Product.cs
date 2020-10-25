using JON_Store.DomainModel.Abstract;
using System;

namespace JON_Store.DomainModel
{
    public class Product : IEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }

    }
}
