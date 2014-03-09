using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace INT422TestOne.ViewModels {
  //===============================================================================
  // CREATE TABLE DirectorBase (DirectorId int, Name string);
  //===============================================================================
  public class DirectorBase {
    [Key]
    public int DirectorId { get; set; }
    [Required]
    public string Name { get; set; }
  }

  //===============================================================================
  // CREATE TABLE DirectorFull ([DirectorBase], Movies List<MovieFull>);
  //===============================================================================
  public class DirectorFull : DirectorBase {
    public List<MovieFull> Movies { get; set; }

    //===============================================================================
    // INSERT INTO DirectorFull (Name, Movies) VALUES ('', List<MovieFull>);
    //===============================================================================
    public DirectorFull() {
      this.Name = string.Empty;
      this.Movies = new List<MovieFull>();
    }
  }
}