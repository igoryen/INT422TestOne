using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestOne.Controllers {
  public class GenreController : Controller {
    //===============================================================================
    // instantiate ViewModels/RepoGenre
    //===============================================================================
    private INT422TestOne.ViewModels.RepoGenre repo = new ViewModels.RepoGenre();

    //===============================================================================
    // GET: /Genre/
    // action method called by "Genre/"
    // return the retval of ViewModels/RepoGenre/getListOfGenreBase()
    //===============================================================================
    
    public ActionResult Index() {
      return View(repo.getListOfGenreBase());
    }

    //===============================================================================
    // GET: /Genre/Details/5
    // will call action method Details()
    //===============================================================================
    public ActionResult Details(int id) {
      return View();
    }

    //===============================================================================
    // for work with a click on link "Create a Genre"
    // GET: /Genre/Create
    //===============================================================================
    public ActionResult Create() {
      return View();
    }

    //===============================================================================
    // aCreate a genre
    // After the click on link "Create a Genre"
    // POST: /Genre/Create
    // 10. display "Genre/"
    // 20. display "Genre/"
    //===============================================================================
    [HttpPost]
    public ActionResult Create(FormCollection collection) {
      try {
        // TODO: Add insert logic here

        return RedirectToAction("Index"); // 10
      }
      catch {
        return View(); // 20
      }
    }

    //===============================================================================
    // Edit the details of genre x (x = id)
    // GET: /Genre/Edit/5
    // to work on click of link "Edit"
    //===============================================================================
    public ActionResult Edit(int id) {
      return View();
    }

    //===============================================================================
    // this action method is called on click of button "Submit" after filling out
    // a details form
    // POST: /Genre/Edit/5
    // 10. pieces passed: genre id & the form-collection
    //===============================================================================
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) { // 10
      try {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch {
        return View();
      }
    }

    //
    // GET: /Genre/Delete/5
    public ActionResult Delete(int id) {
      return View();
    }

    //
    // POST: /Genre/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection) {
      try {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch {
        return View();
      }
    }
  }
}
