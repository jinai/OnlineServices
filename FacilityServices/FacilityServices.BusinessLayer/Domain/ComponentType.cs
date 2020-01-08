﻿using OnlineServices.Shared.TranslationServices.TransfertObjects;
using System.Collections.Generic;

namespace FacilityServices.BusinessLayer.Domain
{
    public class ComponentType
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public bool Archived { get; set; }
        public List<Issue> Issues { get; set; } = new List<Issue>();
    }
}