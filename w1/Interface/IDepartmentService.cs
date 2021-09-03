﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w1.Models;

namespace w1.Interface
{
    interface IDepartmentService
    {
        List<Department> GetAllList();
        Department SingleData(int id);
        string Create(Department department);
        string Update(Department department);
        string Delete(int id);
        void Dispose(bool disposing);
    }
}
