using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace INT422TestOne.ViewModels {
  //===============================================================================
  // CREATE TABLE MovieBase (MovieId int, Title string);
  //===============================================================================
  public class MovieBase {

    [Key]
    public int MovieId { get; set; }
    [Required]
    public string Title { get; set; }
  }
  //===============================================================================
  // CREATE TABLE MovieFull ([MovieId int, Title string], TicketPrice decimal,
  //  Movies List<MovieFull>);
  //===============================================================================
  public class MovieFull : MovieBase {
    [Required]
    [Display(Name = "Ticket Price")]
    public decimal TicketPrice { get; set; }

    public DirectorFull Director { get; set; }

    public List<GenreBase> Genres { get; set; }

    //===============================================================================
    // INSERT INTO MovieFull (Director, Genres) VALUES ('', List<MovieFull>);
    //===============================================================================
    public MovieFull() {
      this.Director = new DirectorFull();
      this.Genres = new List<GenreBase>();

    }
  }

}