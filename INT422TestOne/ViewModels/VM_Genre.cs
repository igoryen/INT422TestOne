using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace INT422TestOne.ViewModels {
  //===============================================================================
  // CREATE TABLE GenreBase (GenreId int, Name string);
  //===============================================================================
  public class GenreBase {
    [Key]
    public int GenreId { get; set; }
    [Required]
    public string Name { get; set; }
  }

  //===============================================================================
  // CREATE TABLE GenreFull ([GenreId int, Name string], Movies List<MovieFull>);
  //===============================================================================
  public class GenreFull : GenreBase {
    public List<MovieFull> Movies { get; set; }

    //===============================================================================
    // INSERT INTO GenreFull (Name, Movies) VALUES ('', List<MovieFull>);
    //===============================================================================
    public GenreFull() {
      this.Name = string.Empty;
      this.Movies = new List<MovieFull>();
    }

  }
}