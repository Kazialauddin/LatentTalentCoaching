using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using w1.Interface;
using w1.Models;

namespace w1.Services
{

    public class QuestionMakerServices : IQuestionMakerService
    {
        public StudentDbContext db = new StudentDbContext();

        public string Create(QuestionViewModel model)
        {
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {


                try
                {

                    Question question = new Question();

                    question.Qustions = model.Qustions;
                    db.question.Add(question);

                    db.SaveChanges();
                    var QID = question.Id;
                    Options options = new Options();
                    options.QuestionId = QID;
                    options.OptionA = model.OptionA;
                    options.OptionB = model.OptionB;
                    options.OptionC = model.OptionC;
                    options.OptionD = model.OptionD;
                    db.options.Add(options);
                    db.SaveChanges();

                    var newOptionId = options.Id;

                    Answer answer = new Answer();
                    answer.QuestionId = QID;
                    answer.OptionId = newOptionId;
                    answer.Answers = model.Answers;


                    db.answers.Add(answer);
                  var result=  db.SaveChanges();
                    transaction.Commit();
                    return result==1?"Save":"Failed";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Error occurred.");
                    return ex.Message;
                }
            }
        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose(bool QuestionViewModel)
        {
            throw new NotImplementedException();
        }

        public List<QuestionViewModel> GetAllList()
        {
            var r = db.question.ToList();
            var result = (from q in db.question.ToList()
                          join ans in db.answers.ToList()
                          on q.Id equals ans.QuestionId
                          join opt in db.options.ToList()
                          on ans.OptionId equals opt.Id
                          select new QuestionViewModel
                          {
                              Qustions = q.Qustions,
                              Answers = ans.Answers,
                              OptionA = opt.OptionA,
                              OptionB = opt.OptionB,
                              OptionC = opt.OptionC,
                              OptionD = opt.OptionD,
                          }).ToList();
            var a = db.answers.ToList();
            var o = db.options.ToList();
            return result;
        }



        public IQueryable<QuestionViewModel> GetIQueryableList()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionDetails(int id)
        {
            return db.question.Find(id);
        }
  

        public QuestionViewModel SingleData(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(QuestionViewModel student)
        {
            throw new NotImplementedException();
        }
    }

}