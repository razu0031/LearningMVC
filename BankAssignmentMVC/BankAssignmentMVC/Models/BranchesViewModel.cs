using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAssignmentMVC.Models
{
    public class BranchViewModel
    {
        [Key]
        public int BranchID { get; set; }

        public virtual int BankID { get; set; }

        [Required(ErrorMessage = "Please enter the branch name.")]
        [DisplayName("Name")]
        public string BranchName { get; set; }

        [Required(ErrorMessage = "Please enter the branch code.")]
        [DisplayName("Code")]
        public string BranchCode { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        public string Address { get; set; }
    }
}