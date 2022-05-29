using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class StudHw
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? HomeworkId { get; set; }
        public int Mark { get; set; }

        public virtual Homework Homework { get; set; }
        public virtual Student Student { get; set; }
    }
}
