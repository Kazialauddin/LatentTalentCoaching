using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using w1.Models;

namespace w1.Interface
{
   public interface IQuestionMakerService
    {
        List<QuestionViewModel> GetAllList();
        IQueryable<QuestionViewModel> GetIQueryableList();
        QuestionViewModel SingleData(int id);
        string Create(QuestionViewModel student);
        string Update(QuestionViewModel student);
        string Delete(int id);
        void Dispose(bool QuestionViewModel);
    }
}
