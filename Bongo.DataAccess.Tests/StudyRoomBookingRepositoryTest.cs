using Bongo.DataAccess.Repository;
using Bongo.Models.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.DataAccess
{
    [TestFixture]
    public class StudyRoomBookingRepositoryTest
    {
        private StudyRoomBooking studyRoomBooking_One;
        private StudyRoomBooking studyRoomBooking_two;
        private DbContextOptions<ApplicationDbContext> options;

        public StudyRoomBookingRepositoryTest()
        {
            studyRoomBooking_One = new StudyRoomBooking
            {
                FirstName = "Digital",
                LastName = "Eagle",
                Date = new DateTime(2023, 1,1),
                Email = "Eagle@Digital.com",
                BookingId = 11,
                StudyRoomId = 1,
            };
            studyRoomBooking_two = new StudyRoomBooking
            {
                FirstName = "Digital2",
                LastName = "Eagle2",
                Date = new DateTime(2023, 2, 2),
                Email = "Eagle@Digital.com",
                BookingId = 23,
                StudyRoomId = 2,
            };
        }
        [SetUp]
        public void SetUp()
        {
             options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "test_Bongo").Options;
        }


        [Test]
        [Order(1)]
        public void SaveBooking_BookingOne_CheckTheValuesFromDataBase()
        {
            //Arrange

            

            //Act
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new StudyRoomBookingRepository(context);
                repo.Book(studyRoomBooking_One);
            }
            
            //Assert
            using (var context = new ApplicationDbContext(options))
            {
                var BookingFromDB =  context.StudyRoomBookings.FirstOrDefault(u=>u.BookingId==11);
                Assert.AreEqual(studyRoomBooking_One.BookingId, BookingFromDB.BookingId);
                Assert.AreEqual(studyRoomBooking_One.FirstName, BookingFromDB.FirstName);
                Assert.AreEqual(studyRoomBooking_One.LastName, BookingFromDB.LastName);
                Assert.AreEqual(studyRoomBooking_One.Date, BookingFromDB.Date);
                Assert.AreEqual(studyRoomBooking_One.StudyRoomId, BookingFromDB.StudyRoomId);
                Assert.AreEqual(studyRoomBooking_One.Email, BookingFromDB.Email);
            }

        }

        [Test]
        [Order(2)]
        public void GetAllBooking_BookingOneAndTwo_CheckBothBookingsFromDataBase()
        {
            var expectedResult = new List<StudyRoomBooking>{studyRoomBooking_One, studyRoomBooking_two };
            //Arrange

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "test_Bongo").Options;

            
            using (var context = new ApplicationDbContext(options))
            {
                context.Database.EnsureDeleted();
                var repo = new StudyRoomBookingRepository(context);
                repo.Book(studyRoomBooking_One);
                repo.Book(studyRoomBooking_two);
            }



            //Act
            List<StudyRoomBooking> actuallist;
            using (var context = new ApplicationDbContext(options))
            {
                var repo = new StudyRoomBookingRepository(context);
                actuallist = repo.GetAll(null).ToList();
            }

            //Assert
            CollectionAssert.AreEqual(expectedResult, actuallist, new BookingCompare());

        }

        private class BookingCompare : IComparer
        {
            public int Compare(object x, object y)
            {
                var booking1 = (StudyRoomBooking)x;
                var booking2 = (StudyRoomBooking)y;
                if (booking1.BookingId != booking2.BookingId)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
