using System;
using System.Collections.Generic;

#nullable disable

namespace Equipments.Domain.Entities
{
    public partial class Post
    {
        public Post()
        {
            Workers = new HashSet<Worker>();
        }

        public int Idpost { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
