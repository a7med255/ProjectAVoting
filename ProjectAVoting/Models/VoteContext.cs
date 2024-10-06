using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ProjectAVoting.Models;

public partial class VoteContext : DbContext
{
    public VoteContext()
    {
    }




    public virtual DbSet<Person> persons { get; set; }
    public virtual DbSet<VoteOption> VoteOptions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-32RHGLK;Database=Votes;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }

}
