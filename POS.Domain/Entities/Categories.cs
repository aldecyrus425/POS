using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Domain.Entities
{
    public class Categories
    {
        public int CategoriesId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public bool IsDeleted { get; private set; }
    }
}
