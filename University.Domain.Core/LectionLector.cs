using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class LectionLector
    {
        public LectionLector()
        {
            Attendances = new HashSet<Attendance>();
            Homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }
        public int? LectorId { get; set; }
        public int? LectionId { get; set; }
        public string Date { get; set; }

        public virtual Lection Lection { get; set; }
        public virtual Lector Lector { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
