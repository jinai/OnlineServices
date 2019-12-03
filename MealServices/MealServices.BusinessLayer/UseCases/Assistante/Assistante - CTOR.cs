﻿using MealServices.Shared.Interfaces;

namespace MealServices.BusinessLayer.UseCases.Assistante
{
    public partial class Assistante : Participant
    {
        public Assistante(IUnitOfWork iUnitOfWork) : base(iUnitOfWork)
        {
            this.iUnitOfWork = iUnitOfWork ?? throw new System.ArgumentNullException(nameof(iUnitOfWork));
        }

        public IUnitOfWork iUnitOfWork { get; }
    }
}