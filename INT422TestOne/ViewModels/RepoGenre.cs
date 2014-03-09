using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestOne.ViewModels {
  public class RepoGenre : RepositoryBase {
    //===============================================================================
    // toListOfGenreBase()
    // 10. create a list of GenreBase
    // 20. fill the list
    // 50. return the list
    //===============================================================================
    public List<GenreBase> toListOfGenreBase(List<Models.Genre> genres) {
      List<GenreBase> gls = new List<GenreBase>();// 10
      foreach (var item in genres) { // 20
        GenreBase gf = new GenreBase();
        gf.GenreId = item.Id;
        gf.Name = item.Name;
        gls.Add(gf);
      }
      return gls; // 50
    }
    //===============================================================================
    // getListOfGenreBase()
    // 10. SELECT * FROM Genres WHERE Name = g ORDER BY Name;
    // 20. Short circuit: If nothing is found, return null
    // 30. make a list
    // 40. fill the list
    // 70. return the list
    //===============================================================================
    public IEnumerable<GenreBase> getListOfGenreBase() {

      var genres = dc.Genres.OrderBy(g => g.Name); // 10
      if (genres == null) return null; // 20

      List<GenreBase> gfls = new List<GenreBase>(); // 30
      foreach (var item in genres) { // 40
        GenreBase g = new GenreBase();
        g.GenreId = item.Id;
        g.Name = item.Name;
        gfls.Add(g);
      }

      return gfls; // 70
    }
    //===============================================================================
    // getGenreSelectList()
    // 10. SelectList represents a list in HTML that lets users select one item.
    //     Get "GenreId" and "Name", pass them to getListOfGenreBase()
    //===============================================================================
    public SelectList getGenreSelectList() {
      SelectList sl = new SelectList(getListOfGenreBase(), "GenreId", "Name"); // 10
      return sl;
    }
  }
}