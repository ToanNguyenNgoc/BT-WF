namespace B_7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("studentTable")]
    public partial class studentTable
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string studentId { get; set; }

        [Required]
        [StringLength(50)]
        public string fullName { get; set; }

        [Required]
        [StringLength(10)]
        public string averageScore { get; set; }

        public int facultyId { get; set; }
        

        // public virtual facultyTable facultyTable { get; set; }
    }
}
