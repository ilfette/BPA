using System;
using System.Collections.Generic;

#nullable disable

namespace University.Domain.Core
{
    public partial class Homework
    {
        public Homework()
        {
            StudHws = new HashSet<StudHw>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public int? LrLnId { get; set; }

        public virtual LectionLector LrLn { get; set; }
        public virtual ICollection<StudHw> StudHws { get; set; }
    }
}
