using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class ApplicationDbContext: DbContext
{

    public ApplicationDbContext(DbContextOptions options) : base(options) 
    { 
    
    }

    public required DbSet<Activity> Activities { get; set; }
}
