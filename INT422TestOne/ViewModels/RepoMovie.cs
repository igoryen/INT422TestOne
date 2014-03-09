using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INT422TestOne.ViewModels;

namespace INT422TestOne.ViewModels {
  public class RepoMovie : RepositoryBase {

    //===============================================================================
    // getMovieFull()
    // 10. SELECT * FROM Movies WHERE Id = id
    //     include in the query: the related objects "Genres" & "Directors"
    // 20. Short circuit: if nothing SELECTED return null
    // 30. create a MovieFull row
    // 70. return the MovieFull row
    //===============================================================================
    public MovieFull getMovieFull(int? id) {
      var movie = dc.Movies.Include("Genres").Include("Director").SingleOrDefault(n => n.Id == id); // 10

      if (movie == null) return null; // 20

      MovieFull mf = new MovieFull(); // 30

      mf.MovieId = movie.Id;
      mf.Title = movie.Title;
      mf.TicketPrice = movie.TicketPrice;

      mf.Director = rd.toDirectorFull(movie.Director);
      mf.Genres = rg.toListOfGenreBase(movie.Genres);

      return mf; // 70
    }
    //===============================================================================
    // getListOfMovieBase()
    // 10. SELECT * FROM Movies ORDER BY Title
    //===============================================================================
    public IEnumerable<MovieBase> getListOfMovieBase() {

      var movies = dc.Movies.OrderBy(m => m.Title); // 10

      List<MovieBase> mbls = new List<MovieBase>();

      foreach (var item in movies) {
        MovieBase mf = new MovieBase();
        mf.MovieId = item.Id;
        mf.Title = item.Title;

        mbls.Add(mf);
      }

      return mbls;
    }
    //===============================================================================
    // getListOfMovieFull()
    // 10. SELECT * FROM Movies ORDER BY Title
    // 
    //===============================================================================
    public IEnumerable<MovieFull> getListOfMovieFull() {

      var movies = dc.Movies.Include("Genres").OrderBy(m => m.Title); // 10

      List<MovieFull> mfls = new List<MovieFull>();

      foreach (var item in movies) {
        MovieFull mf = new MovieFull();
        mf.MovieId = item.Id;
        mf.Title = item.Title;
        mf.TicketPrice = item.TicketPrice;

        mf.Director = rd.getDirectorFull(item.Id); // 
        mf.Genres = rg.toListOfGenreBase(item.Genres);

        mfls.Add(mf);
      }

      return mfls;
    }
    //===============================================================================
    // createMovie()
    // 10. make a row of MovieFull
    // 20. make a row of Movie
    // 40. make gids a string array that contains the substrings in this instance 
    //     that are delimited by commas
    // 50. convert the id into integer
    // 60. SELECT * FROM Genres WHERE Id = intItem;
    //     Return the first element, or a default value if no elements.
    // 70. take string in "d" and convert it representation of a number to an 
    //     equivalent 32-bit signed integer.
    // 80. SELECT * FROM Directors WHERE Id = did;
    //     Return the first element, or a default value if no elements.
    // 90. return retval of getMovieFull(m.Id)
    //===============================================================================
    public MovieFull createMovie(string title, string price, string gids, string d) { // 10
      Models.Movie m = new Models.Movie(); // 20

      m.Title = title;
      m.TicketPrice = Convert.ToDecimal(price);

      foreach (var item in gids.Split(',')) { // 40
        var intItem = Convert.ToInt32(item); // 50
        var g = dc.Genres.FirstOrDefault(gg => gg.Id == intItem); // 60
        m.Genres.Add(g);
      }

      int did = Convert.ToInt32(d); // 70
      m.Director = dc.Directors.FirstOrDefault(n => n.Id == did); // 80

      dc.Movies.Add(m);
      dc.SaveChanges();

      return getMovieFull(m.Id); // 90
    }
    //===============================================================================
    // toListOfMovieBase()
    // 10. make an empty table of MovieBase rows
    // 20. make a MovieBase row
    //===============================================================================
    public List<MovieBase> toListOfMovieBase(List<Models.Movie> movies) {

      List<MovieBase> mbls = new List<MovieBase>(); // 10

      foreach (var item in movies) {
        MovieBase mm = new MovieBase(); // 20
        mm.MovieId = item.Id;
        mm.Title = item.Title;
        mbls.Add(mm);
      }

      return mbls;
    }
    //===============================================================================
    // RepoMovie() ???
    //===============================================================================
    public RepoMovie() {
      rd = new RepoDirector();
      rg = new RepoGenre();
    }
    //===============================================================================
    // Implementation details
    // Bring in RepoDirector and RepoGenre
    //===============================================================================
    RepoDirector rd;
    RepoGenre rg;
  }
}