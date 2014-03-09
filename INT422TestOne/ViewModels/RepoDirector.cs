using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestOne.ViewModels {
  public class RepoDirector : RepositoryBase {

    //===============================================================================
    // getDirectorFull
    // 10. get the first element of a sequence, or a default value if the 
    //     sequence contains no elements.
    // 20. if user enters nonexistent id, return null
    // 30. make a DirectorFull row
    // 40. copy from director to DirectorFull
    // 50. make a List of MovieBase obkects
    // 70. return a DirectorFull
    //===============================================================================
    public DirectorFull getDirectorFull(int? id) {
      var director = dc.Directors.FirstOrDefault(i => i.Id == id); // 10
      if (director == null) return null; // 20

      DirectorFull df = new DirectorFull(); // 30
      df.DirectorId = director.Id; // 40
      df.Name = director.Name;
      List<MovieBase> mv = new List<MovieBase>(); // 50
      foreach (var item in director.Movies) {
        MovieBase mb = new MovieBase();
        mb.MovieId = item.Id;
        mb.Title = item.Title;
        mv.Add(mb);
      }
      //df.Movies = mv;

      return df; // 70
    }

    //===============================================================================
    // getListOfDirectorBase
    // 10. SELECT # FROM Directors ORDER BY Name
    // 20. short circuit: if there are no rows in Directors
    // 30. CREATE TABLE dls / 
    // 60. bring to grass "dls"
    //===============================================================================
    public IEnumerable<DirectorBase> getListOfDirectorBase() {
      var directors = dc.Directors.OrderBy(d => d.Name); // 10
      if (directors == null) return null; // 20

      List<DirectorBase> dls = new List<DirectorBase>(); // 30
      foreach (var item in directors) {
        DirectorBase db = new DirectorBase();
        db.DirectorId = item.Id;
        db.Name = item.Name;
        dls.Add(db);
      }
      return dls; // 60
    }

    //===============================================================================
    // toDirectorFull
    // 10. Models/AppDomainClasses()/Director
    // 20. make a row of DirectorFull
    // 70. bring on grass df
    //===============================================================================
    public DirectorFull toDirectorFull(Models.Director d) { // 10
      if (d == null) return null;

      DirectorFull df = new DirectorFull(); // 20
      df.DirectorId = d.Id;
      df.Name = d.Name;

      df.Movies = new List<MovieFull>();
      foreach (var item in d.Movies) {
        MovieFull m = new MovieFull();
        m.MovieId = item.Id;
        m.TicketPrice = item.TicketPrice;
        m.Title = item.Title;
        df.Movies.Add(m);
      }

      return df; // 70
    }
    //===============================================================================
    // getDirectorSelectList
    // 10. SelectList represents a list that lets users select one item.
    //     Get "DirectorId" and "Name", pass them to getListOfDirectorBase()
    //===============================================================================
    public SelectList getDirectorSelectList() {
      SelectList sl = new SelectList(getListOfDirectorBase(), "DirectorId", "Name"); // 10
      return sl;
    }
  }
}