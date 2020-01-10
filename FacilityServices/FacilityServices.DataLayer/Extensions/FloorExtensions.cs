﻿using FacilityServices.DataLayer.Entities;
using OnlineServices.Shared.Extensions;
using OnlineServices.Shared.FacilityServices.Exceptions;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacilityServices.DataLayer.Extensions
{
    public static class FloorExtensions
    {
        public static FloorTO ToTransfertObject(this FloorEF Floor)
        {
            if (Floor is null)
                throw new NotExistingFloorException(nameof(Floor));

            return new FloorTO
            {
                Id = Floor.Id,
                Number = Floor.Number,
                //Rooms = Floor.Rooms?.Select(x => x.ToTransfertObject()).ToList(),
                Archived = Floor.Archived
            };
        }

        public static FloorEF ToEF(this FloorTO Floor)
        {
            if (Floor is null)
                throw new NotExistingFloorException(nameof(Floor));

            return new FloorEF()
            {
                Id = Floor.Id,
                Number = Floor.Number,
                //Rooms = Floor.Rooms?.Select(x => x.ToEF()).ToList(),
                Archived = Floor.Archived
            };
        }

        public static FloorEF UpdateFromDetached(this FloorEF AttachedEF, FloorEF DetachedEF)
        {
            if (AttachedEF is null)
                throw new ArgumentNullException(nameof(AttachedEF));

            if (DetachedEF is null)
                throw new ArgumentNullException(nameof(DetachedEF));

            if (AttachedEF.Id != DetachedEF.Id)
                throw new Exception("Cannot update FloorEF entity as it is not the same.");

            if ((AttachedEF != default) && (DetachedEF != default))
            {
                AttachedEF.Number = DetachedEF.Number;
                AttachedEF.Archived = DetachedEF.Archived;
            }
            return AttachedEF;
        }
    }
}
