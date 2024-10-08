﻿using Microsoft.EntityFrameworkCore;
using MiWebApi.Entities;

namespace MiWebApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
                
        }

        public DbSet<ServiciosFinancieros> ServiciosFinancieros { get; set; }
    }
}
