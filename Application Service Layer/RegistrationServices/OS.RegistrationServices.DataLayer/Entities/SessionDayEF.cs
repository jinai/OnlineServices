﻿using OS.Common.DataAccessHelpers;
using OS.Common.RegistrationServices.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OS.RegistrationServices.DataLayer.Entities
{
    public class SessionDayEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        public SessionPresenceType PresenceType { get; set; }
    }
}