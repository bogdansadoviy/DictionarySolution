using Dictionary.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<UserWordMapping> UserWordMappings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        // Note: for testing
        public ApplicationDbContext() { }
    }
}
