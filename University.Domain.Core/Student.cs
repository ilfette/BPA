using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class Student
    {
        public Student()
        {
            Attendances = new HashSet<Attendance>();
            StudHws = new HashSet<StudHw>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string Recordbook { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<StudHw> StudHws { get; set; }
    }
}
