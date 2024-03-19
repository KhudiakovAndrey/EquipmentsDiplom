using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Domain.Entities
{
    public class Token
    {
        public Guid Id { get; set; }
        public string Tokencontent { get; set; }
        public int Iduser { get; set; }

        public virtual User IduserNavigation { get; set; }
    }
}
