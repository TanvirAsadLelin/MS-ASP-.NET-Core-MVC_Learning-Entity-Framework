using System;
using System.Collections.Generic;

namespace CRUD_DatabaseFirstApproachEF.Models
{
    public partial class StdParentsDetailsTbl
    {
        public int Id { get; set; }
        public string FatherName { get; set; } = null!;
        public string MotherName { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
