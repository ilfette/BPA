using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? LrLnId { get; set; }
        public int? Status { get; set; }
        public int Mark { get; set; }

        public virtual LectionLector LrLn { get; set; }
        public virtual Student Student { get; set; }
    }
}
