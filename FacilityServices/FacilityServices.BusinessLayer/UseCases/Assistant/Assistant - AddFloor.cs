﻿using OnlineServices.Common.FacilityServices.TransfertObjects;

namespace FacilityServices.BusinessLayer.UseCases
{
    public partial class AssistantRole
    {
        public FloorTO AddFloor(FloorTO floorToAdd)
        {
            if (floorToAdd is null)
            {
                throw new System.ArgumentNullException(nameof(floorToAdd));
            }

            return iFSUnitOfWork.FloorRepository.Add(floorToAdd);
        }
    }
}