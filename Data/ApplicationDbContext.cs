using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TarefasTemp.Models;

namespace TarefasTemp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TarefasTemp.Models.Tarefaitem> Tarefaitem { get; set; }

        //public DbSet<TarefasItem> Tarefas {get; set; }
    }
}
