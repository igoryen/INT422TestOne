using System.Data.Entity;

namespace INT422TestOne.Models {

  //===============================================================================
  // This class enables you to do INSERT and SELECT with TABLES 
  // 10. Call the base constructor of class DataContext and assign ... 
  //===============================================================================
  public class DataContext : DbContext {

    public DataContext() : base("name=DataContext") { } // 10
    //===============================================================================
    // Enable INSERT and SELECT into TABLES "Movie", "Director", and "Genres"
    //===============================================================================
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    //===============================================================================
    // ?????
    //===============================================================================
    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.MovieBase> MovieBases { get; set; }
    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.MovieFull> MovieFulls { get; set; }
    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.DirectorBase> DirectorBases { get; set; }
    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.GenreBase> GenreBases { get; set; }

  }
}