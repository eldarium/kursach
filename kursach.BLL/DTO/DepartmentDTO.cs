﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach.BLL.DTO
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WorkerDTO> AssignedWorkers { get; set; }
        public DepartmentDTO() { }
    }
}
