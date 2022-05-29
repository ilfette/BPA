using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class Lector
    {
        public Lector()
        {
            LectionLectors = new HashSet<LectionLector>();
        }

        public int Id { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LectionLector> LectionLectors { get; set; }
    }
}
