﻿using FacilityServices.DataLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using OnlineServices.Shared.FacilityServices.Interfaces.Repositories;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacilityServices.DataLayer.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private FacilityContext facilityContext;

        public RoomRepository(FacilityContext facilityContext)
        {
            this.facilityContext = facilityContext;
        }

        public RoomTO Add(RoomTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            var tracking = facilityContext.Rooms.Add(Entity.ToEF());
            tracking.State = EntityState.Added;
            return tracking.Entity.ToTranfertObject();
        }

        public IEnumerable<RoomTO> GetAll()
        {
            return facilityContext.Rooms
                                  .Include(r => r.Floor)
                                  .Select(r => r.ToTranfertObject());
        }

        public RoomTO GetByID(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return facilityContext.Rooms
                                  .AsNoTracking()
                                  .Include(r => r.Floor)
                                  .FirstOrDefault(r => r.Id == Id).ToTranfertObject();
        }

        public List<RoomTO> GetRoomsByFloors(FloorTO Floor)
        {
            if (Floor is null)
            {
                throw new ArgumentNullException(nameof(Floor));
            }

            return facilityContext.Rooms
                                  .Include(r => r.Floor)
                                  .Where(r => r.Floor.Id == Floor.Id)
                                  .Select(r => r.ToTranfertObject())
                                  .ToList();
        }

        public List<RoomTO> GetRoomsByFloors(FloorTO Floor)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(RoomTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var entityEF  = facilityContext.Rooms.Find(entity.Id);
            var tracking = facilityContext.Rooms.Remove(entityEF);
            return tracking.State == EntityState.Deleted;
        }

        public bool Remove(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentException("The ID isn't in the correct format!");
            }

            return Remove(GetByID(Id));
        }

        public RoomTO Update(RoomTO Entity)
        {
            if (Entity is null)
            {
                throw new ArgumentNullException(nameof(Entity));
            }

            facilityContext.Entry(Entity.ToEF()).State = EntityState.Modified;

            return Entity;
        }
    }
}