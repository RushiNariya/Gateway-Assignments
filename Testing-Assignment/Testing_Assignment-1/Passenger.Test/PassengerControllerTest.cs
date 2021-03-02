using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Testing_Assignment_1.Controllers;
using Testing_Assignment_1.Repository;
using Xunit;

namespace Passenger.Test
{
    public class PassengerControllerTest
    {
        private readonly Mock<IDataRepository> mockDataRepository = new Mock<IDataRepository>();
        private readonly PassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new PassengerController(mockDataRepository.Object);
        }

        [Fact]
        public void Test_GetPassenger()
        {
            // Arrange
            var resultObject = mockDataRepository.Setup(x => x.getPassengersList()).Returns(GetPassengers());

            // Act
            var response = _passengerController.Get();

            // Asert
            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void Test_DeletePassenger()
        {
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            // Arrange
            var resultObject = mockDataRepository.Setup(x => x.Delete(passenger.Id)).Returns(true);

            // Act
            var response = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.True(response);

        }

        [Fact]
        public void Test_GetPassengerById()
        {
            // Arrange
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Raj";
            passenger.LastName = "Nariya";
            passenger.ContactNumber = "9864751235";

            // Act
            var responseObj = mockDataRepository.Setup(x => x.GetById(passenger.Id)).Returns(passenger);
            var result = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<Testing_Assignment_1.Models.Passenger>>(result);
            // Assert
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_AddPassenger()
        {
            // Arrange
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Raj";
            passenger.LastName = "Patel";
            passenger.ContactNumber = "9864751235";
            // Act
            var response = mockDataRepository.Setup(x => x.AddPassenger(passenger)).Returns(AddPassenger());
            var result = _passengerController.Post(passenger);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Test_UpdatePassenger()
        {
            // Arrange
            var model = JsonConvert.DeserializeObject<Testing_Assignment_1.Models.Passenger>(File.ReadAllText("Data/UpdateUser.json"));

            // Act
            var resultObject = mockDataRepository.Setup(x => x.Update(model)).Returns(model);
            var response = _passengerController.Put(model);
            // Assert
            Assert.Equal(model, response);
        }

        private static IList<Testing_Assignment_1.Models.Passenger> GetPassengers()
        {
            Guid id1 = new Guid();
            Guid id2 = new Guid();
            Guid id3 = new Guid();
            IList<Testing_Assignment_1.Models.Passenger> passengers = new List<Testing_Assignment_1.Models.Passenger>()
            {                
                new Testing_Assignment_1.Models.Passenger() {Id = id1, FirstName = "Raj", LastName = "Patel" ,ContactNumber = "9870695432"},
                new Testing_Assignment_1.Models.Passenger() { Id = id2, FirstName = "Rahul", LastName = "Dave", ContactNumber = "8769584392" },
                new Testing_Assignment_1.Models.Passenger() { Id = id3, FirstName = "Rohan", LastName = "Radadiya", ContactNumber = "9870658432" },

            };
            return passengers;
        }

        private static Testing_Assignment_1.Models.Passenger AddPassenger()
        {
            var passenger = new Testing_Assignment_1.Models.Passenger();
            passenger.Id = new Guid();
            passenger.FirstName = "Raj";
            passenger.LastName = "Nariya";
            passenger.ContactNumber = "9864751235";
            return passenger;
        }
    }
}
