using Microsoft.VisualStudio.TestTools.UnitTesting;
using OS.Common.RegistrationServices.TransferObjects;
using OS.RegistrationServices.DataLayer.Entities;
using OS.RegistrationServices.DataLayer.Extensions;
using System;
using System.Collections.Generic;
using OS.Common.RegistrationServices.Enumerations;

namespace OS.RegistrationServices.DataLayerTests
{
    [TestClass]
    public partial class SessionExtensionsTests
    {
        [TestMethod()]
        public void Should_Have_Same_Id_As_TO()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                SessionDays = new List<SessionDayTO>()
                {
                   new SessionDayTO(){Id = 1, Date = new DateTime(2020, 2, 3), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayTO(){Id = 2, Date = new DateTime(2020, 2, 4), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayTO(){Id = 3, Date = new DateTime(2020, 2, 5), PresenceType = SessionPresenceType.MorningAfternoon}
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Course = sqlEF,
                Dates = new List<SessionDayEF>()
                {
                   new SessionDayEF(){Id = 1, Date = new DateTime(2020, 2, 3), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayEF(){Id = 2, Date = new DateTime(2020, 2, 4), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayEF(){Id = 3, Date = new DateTime(2020, 2, 5), PresenceType = SessionPresenceType.MorningAfternoon}
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.Id, sessionConverted.Id);
        }

        [TestMethod()]
        public void Should_Have_Same_Course_As_TO()
        {
            #region TOInitialization

            UserTO student = new UserTO()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                Role = UserRole.Attendee,
            };

            UserTO teacher = new UserTO()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                Role = UserRole.Teacher
            };

            CourseTO sql = new CourseTO()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionTO sessionTO = new SessionTO()
            {
                Id = 1,
                Teacher = teacher,
                Course = sql,
                SessionDays = new List<SessionDayTO>()
                {
                   new SessionDayTO(){Id = 1, Date = new DateTime(2020, 2, 3), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayTO(){Id = 2, Date = new DateTime(2020, 2, 4), PresenceType = SessionPresenceType.MorningAfternoon},
                   new SessionDayTO(){Id = 3, Date = new DateTime(2020, 2, 5), PresenceType = SessionPresenceType.MorningAfternoon}
                },

                Attendees = new List<UserTO>()
                {
                    student,
                }
            };

            #endregion TOInitialization

            #region EFInitialization

            UserEF studentEF = new UserEF()
            {
                Id = 1,
                Name = "Jacky Fringant",
                Email = "jacky@supermail.com",
                Role = UserRole.Attendee,
            };

            UserEF teacherEF = new UserEF()
            {
                Id = 2,
                Name = "Johnny Begood",
                Email = "johnny@yolomail.com",
                Role = UserRole.Teacher
            };

            CourseEF sqlEF = new CourseEF()
            {
                Id = 1,
                Name = "SQL"
            };

            SessionEF sessionEF = new SessionEF()
            {
                Id = 1,
                Course = sqlEF,
                Dates = new List<SessionDayEF>()
                {
                    new SessionDayEF { Id=1, Date=new DateTime(2020, 01, 20), PresenceType = SessionPresenceType.MorningOnly},
                    new SessionDayEF { Id=2, Date=new DateTime(2020, 01, 21), PresenceType = SessionPresenceType.MorningOnly},
                    new SessionDayEF { Id=3, Date=new DateTime(2020, 01, 22), PresenceType = SessionPresenceType.MorningOnly},
                },
            };

            List<UserSessionEF> userSessions = new List<UserSessionEF>()
            {
                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = studentEF.Id
                },

                new UserSessionEF
                {
                    SessionId = sessionEF.Id,
                    UserId = teacherEF.Id
                }
            };

            sessionEF.UserSessions = userSessions;

            #endregion EFInitialization

            SessionEF sessionConverted = sessionTO.ToEF();

            Assert.AreEqual(sessionEF.Course.Id, sessionConverted.Course.Id);
            Assert.AreEqual(sessionEF.Course.Name, sessionConverted.Course.Name);
        }
    }
}