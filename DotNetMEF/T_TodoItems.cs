namespace DotNetMEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_TodoItems
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public bool IsComplete { get; set; }

        public int? Category { get; set; }

        public virtual T_Category T_Category { get; set; }
    }
}
