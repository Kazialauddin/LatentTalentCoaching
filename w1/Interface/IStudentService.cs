using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w1.Models;

namespace w1.Interface
{
   public interface IStudentService
    {
        List<Student> GetAllList();
        Student SingleData(int id);
        string Create(Student student);
        string Update(Student student);
        string Delete(int id);
        void Dispose(bool student);
    }
}
