namespace Shop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        public bool? Status { get; set; }
    }
}
