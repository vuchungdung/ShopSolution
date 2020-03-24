namespace Shop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int ID { get; set; }

        [StringLength(80)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
