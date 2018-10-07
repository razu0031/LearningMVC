using BankAssignmentMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankAssignmentMVC.Context
{
    public class ViewModelContext : DbContext
    {
        public DbSet<BankViewModel> BankViewModels { get; set; }

        public DbSet<BranchViewModel> BranchViewModels { get; set; }
    }
}