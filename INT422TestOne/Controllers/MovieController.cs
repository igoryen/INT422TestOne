using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INT422TestOne.ViewModels;

namespace INT422TestOne.Controllers {
  public class MovieController : Controller {
    private RepoMovie repo = new RepoMovie();
    private RepoGenre gen = new RepoGenre();
    private RepoDirector dir = new RepoDirector();

    //===============================================================================
    // SELECT * FROM MovieBase;
    // and navigates to:
    // GET: /Movie/
    // it will call ViewModels/RepoMovie()/getListOfMovieBase()
    // and display its retval
    //===============================================================================
    public ActionResult Index() {
      return View(repo.getListOfMovieBase());
    }

    //===============================================================================
    // SELECT * FROM MovieFull WHERE id = id;
    // GET: /Movie/Details/5
    //===============================================================================
    public ActionResult Details(int id) {
      return View(repo.getMovieFull(id));
    }

    //===============================================================================
    // GET: /Movie/Create
    //===============================================================================
    public ActionResult Create() {
      ViewBag.genres = gen.getGenreSelectList();
      ViewBag.directors = dir.getDirectorSelectList();

      return View();
    }
    //===============================================================================
    // INSERT INTO movie? (column1,column2,column3, column3)
    // VALUES (value1,value2,value3,value4);
    // POST: /Movie/Create
    // 10. if the number of values of parameter "form" == 5, i.e. ??
    //===============================================================================
    [HttpPost]
    public ActionResult Create(FormCollection form) {
      try {
        if (form.Count == 5) { // 10
          repo.createMovie(form[1], form[2], form[3], form[4]);
        }

        return RedirectToAction("Index");
      }
      catch (Exception e) {
        ViewBag.ExceptionMessage = e.Message;

        return View("Error");
      }
    }
  }
}
