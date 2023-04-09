﻿using Domain.Entities;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TripDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }

        public DateTime? Start { get;  set; }

        public DateTime? End { get;  set; }

        public string BackgroundImage { get; set; }
        public Location? Location { get;  set; } 
        public TouristDTO Owner { get; private set; }
        public List<TouristDTO> Viewers { get; set; }
        public List<ActivityDTO> Activities { get; private set; }
        public List<ToDOListDTO> ToDOLists { get; set; }

        public static TripDTO FromTrip(Trip trip)
        {
            return new TripDTO
            {
                Id = trip.Id,
                Name = trip.Name,
                Start = trip.Start,
                End = trip.End,
                Owner = TouristDTO.FromTourist(trip.Owner),
                Location = trip.Location,
                BackgroundImage = trip.BackgroundImage,
                Activities = trip.Activities.Select(t => ActivityDTO.FromActivity(t)).ToList(),
                Viewers = trip.TripViewers.Select(t => TouristDTO.FromTourist(t)).ToList(),
                ToDOLists = trip.ToDoLists.Select(list => ToDOListDTO.FromToDoList(list)).ToList(),
            };              
        }
    }
}