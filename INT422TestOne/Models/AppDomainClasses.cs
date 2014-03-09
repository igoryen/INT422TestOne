using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace INT422TestOne.Models {
  
  //===============================================================================
  // TABLE Movie
  //===============================================================================
  public class Movie {
    public Movie() {
      this.Genres = new List<Genre>();
    }
    //===============================================================================
    // CREATE TABLE Movie( Id int, Title string, TicketPrice decimal,
    //    Director Director, Genres List<Genre> );
    //===============================================================================
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public decimal TicketPrice { get; set; }

    public Director Director { get; set; }

    public List<Genre> Genres { get; set; }
  }
  //===============================================================================
  // TABLE Director
  //===============================================================================
  public class Director {
    //===============================================================================
    // Constructors
    //===============================================================================
    public Director() {
      this.Name = string.Empty;
      this.Movies = new List<Movie>();
    }
    public Director(string d) {
      this.Name = d;
      this.Movies = new List<Movie>();
    }
    //===============================================================================
    // CREATE TABLE Director( Id int, Name string, Movies List<Movie>  );
    //===============================================================================
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
  }
  //===============================================================================
  // TABLE Genre
  //===============================================================================
  public class Genre {
    //===============================================================================
    // Constructors
    //===============================================================================
    public Genre() {
      this.Name = string.Empty;
      this.Movies = new List<Movie>();
    }
    public Genre(string d) {
      this.Name = d;
      this.Movies = new List<Movie>();
    }
    //===============================================================================
    // CREATE TABLE Genre( Id int, Name string, Movies List<Movie>);
    //===============================================================================
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
  }
}