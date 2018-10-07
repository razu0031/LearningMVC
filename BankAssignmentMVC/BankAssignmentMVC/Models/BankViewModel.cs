using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankAssignmentMVC.Models
{
    public class BankViewModel
    {
        [Key]
        public int BankId { get; set; }

        [Required(ErrorMessage = "Please enter the bank name.")]
        [DisplayName("Name")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Please enter the bank code.")]
        [DisplayName("Code")]
        public string BankCode { get; set; }

        [Required(ErrorMessage = "Please enter the address.")]
        public string Address { get; set; }

        [DisplayName("Branches")]
        public int TotalBranches { get; set; }
    }
}