﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.BLL.DTO
{
    public class WorkerDTO
    {
        private DateTime _assignDay;
        public int WorkerId { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long BankAccount { get; private set; }
        public double Age => (DateTime.Today - _assignDay).TotalDays; //?
    }
}