using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using _036_MoviesMvcWissen.Entities;

namespace _036_MoviesMvcWissen.Contexts
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("MoviesContext")
        {
            
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<MovieDirector> MovieDirectors { get; set; }
    }
}