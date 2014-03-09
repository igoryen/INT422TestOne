using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INT422TestOne.Models;

namespace INT422TestOne.ViewModels {
  public class RepositoryBase {
    //===============================================================================
    // 10. initialize the new DataContext
    // 20. turn off EF tracking changes and lazy loading; we do it ourselves
    //===============================================================================
    public RepositoryBase() {

      dc = new DataContext(); // 10

      dc.Configuration.ProxyCreationEnabled = false; // 20
      dc.Configuration.LazyLoadingEnabled = false; // 30

    }
    //===============================================================================
    // implementation details: make a new DataContext 
    //===============================================================================
    protected DataContext dc;
  }
}