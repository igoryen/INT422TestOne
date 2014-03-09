using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//======================================================================
// 10. package_name.folder_name
//======================================================================
namespace INT422TestOne.Controllers { // 10

  //====================================================================
  // 10. class DirectController is a derived class of class Controller
  //====================================================================
  public class DirectorController : Controller { //10

    //==================================================================
    // 10. "repo" type is INT422TestOne.ViewModels.RepoDirector
    //==================================================================
    private INT422TestOne.ViewModels.RepoDirector repo = new ViewModels.RepoDirector(); // 10

    //==================================================================
    // 10. Action method for the Index.cshtml
    // 20. call ViewModels.RepoDirector.getListOfDirectorBase()
    //     pass its retval to the View
    //==================================================================
    // GET: /Director/
    public ActionResult Index() { // 10
      return View(repo.getListOfDirectorBase()); // 20
    }
  }
}