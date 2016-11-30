﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kursach.DAL.Entities;

namespace kursach.DAL.Contexts
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(): base("DBConnection") { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Worker> Workers { get; set; }
    }
}