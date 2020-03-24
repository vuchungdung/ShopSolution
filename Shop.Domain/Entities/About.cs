namespace Shop.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(10)]
        public string ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModefiedBy { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        public bool? Status { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [Column(TypeName = "xml")]
        public string Image { get; set; }
    }
}
