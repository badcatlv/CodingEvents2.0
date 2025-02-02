﻿using System;
using CodingEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingEvents.Data
{
	public class EventDbContext : DbContext
	{
		public DbSet<Event> Events { get; set; }
		public DbSet<EventCategory> Categories { get; set; }
		public DbSet<Tag> Tags { get; set; }


 		public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                  .HasMany(e => e.Tags)
                  .WithMany(e => e.Events)
                  .UsingEntity(j => j.ToTable("EventTags"));
        }
    }
}

