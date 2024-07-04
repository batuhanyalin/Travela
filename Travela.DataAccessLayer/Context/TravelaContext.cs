using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Context
{
    public class TravelaContext:DbContext
    {
        //override bağlantıyı ezme işlemini yaptırıyor. Bağlantı adresinin istenen şekilde yazılmasına olanak verir
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=TravelaDb;integrated security=true");
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Destination> Destinations { get; set; }   
    }
}
