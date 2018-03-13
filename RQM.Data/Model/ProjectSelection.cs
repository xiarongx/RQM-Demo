using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RQM.Data.Model
{
    public class ProjectSelection
    {
        [Required]
        public int ProjectListID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [Required]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }
    }
}
