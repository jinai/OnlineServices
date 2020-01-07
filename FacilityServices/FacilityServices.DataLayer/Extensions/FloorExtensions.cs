﻿using FacilityServices.DataLayer.Entities;
using OnlineServices.Shared.Extensions;
using OnlineServices.Shared.FacilityServices.Exceptions;
using OnlineServices.Shared.FacilityServices.TransfertObjects;
using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System;
using System.Collections.Generic;
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
                Name = Floor.Name,
            };
        }

        public static FloorEF ToEF(this FloorTO Floor)
        {
            if (Floor is null)
                throw new NotExistingFloorException(nameof(Floor));

            return new FloorEF()
            {
                Id = Floor.Id,
                Name = Floor.Name,
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
                AttachedEF.Name = DetachedEF.Name;
            }
            return AttachedEF;
        }
    }
}