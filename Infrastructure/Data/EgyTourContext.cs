﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Reflection.Metadata;
using Domain.ValueObjects;
using Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;
using Domain.Services;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data
{
    public class EgyTourContext : DbContext
    {
        public EgyTourContext(DbContextOptions<EgyTourContext> options)
        : base(options)
        {
        }
        public DbSet<Tourist> Tourists { get; set;}
        public DbSet<LocalPerson> LocalPersons { get; set;}
        public DbSet<Service> Services { get; set;}
        public DbSet<Post> Posts { get; set;}
        public DbSet<Comment> Comments { get;}
        public DbSet<Trip> Trips { get; set;}
        public DbSet<Review> Reviews { get; set;}
        public DbSet<ToDoList> ToDoLists { get; set;}
        public DbSet<ToDoItem> ToDoItems { get; set;}
        public DbSet<ServiceReview> ServiceReviews { get; set;}
        public DbSet<LocalReview> LocalReviews { get; set;}
        public DbSet<Messege> Messeges { get; set;}
        public DbSet<Note> Notes { get; set; }
        public DbSet<TouristFriend> touristFriends { get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         

            modelBuilder.Entity<TouristFriend>().HasKey(t => new { t.FriendId, t.TouristId });
            modelBuilder.Entity<Post>()
                .HasOne(a => a.Writer)
                .WithMany(b => b.WrittenPosts);


            modelBuilder.Entity<Post>()
                .HasMany(a => a.Likers)
                .WithMany(b => b.LikedPosts);

            modelBuilder.Entity<Post>().OwnsMany(p => p.Pictures);
            modelBuilder.Entity<Messege>()
                .HasOne(a => a.Sender)
                .WithMany(b => b.SentMessages)
                .OnDelete(DeleteBehavior.Restrict);
                

            modelBuilder.Entity<Messege>()
               .HasOne(a => a.Reciever)
               .WithMany(b => b.RecievedMessages);

            modelBuilder.Entity<LocalReview>()
                .HasOne(a => a.Reviwer)
                .WithMany(b => b.LocalReviews)
                ;
                

            modelBuilder.Entity<LocalReview>()
                .HasOne(a => a.PersonReviewd)
                .WithMany(b => b.Reviews);


            modelBuilder.Entity<Tourist>()
                .HasMany(a => a.Friends);

           

            modelBuilder.Entity<Location>().Property<int>("Id");
            modelBuilder.Entity<Location>().HasKey("Id");

            modelBuilder.Entity<Location>().ToTable("Location");

            modelBuilder.Entity<Activity>().OwnsMany(i => i.Notes);


            modelBuilder.Entity<Trip>()
                .HasOne(a => a.Owner)
                .WithMany(b=>b.OwnedTrips);

            modelBuilder.Entity<Trip>().OwnsMany(i => i.images);

            modelBuilder.Entity<Service>().OwnsMany(s => s.Images);

            modelBuilder.HasDbFunction(typeof(LevenshteinDistance).GetMethod(nameof(LevenshteinDistance.Calculate)))
            .HasName("LevenshteinDistance");

           
             
               
        }
    }
}
