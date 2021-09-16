using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using w1.Interface;
using w1.Models;

namespace w1.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        public IQuestionMakerService _QuestionMaker;
        public QuestionsController(IQuestionMakerService ques)
        {
            _QuestionMaker = ques;
        }
        public ActionResult Index()
        {
            return View(_QuestionMaker.GetAllList());
        }


        public ActionResult Details(int id)
        {

            return View(_QuestionMaker.SingleData(id));
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionViewModel question)
        {


            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {

                    _QuestionMaker.Create(question);
                    return RedirectToAction("Index");
                }


            }
            return View(question);
        }
    }
}
