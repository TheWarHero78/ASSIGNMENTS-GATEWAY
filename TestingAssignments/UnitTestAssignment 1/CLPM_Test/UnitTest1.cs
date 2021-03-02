using System.Collections.Generic;
using System.IO;
using System.Web.Http.Results;
using AarshModi_CLPM.Controllers;
using AarshModi_CLPM.Models;
using CLPM.DAL.Repository.Interface;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace CLPM_Test
{
    public class UnitTest1
    {
        private readonly Mock<IPassengerRepository> mockDataRepo = new Mock<IPassengerRepository>();
        private readonly PassengerController _passengerController;
        public UnitTest1()
        {
            _passengerController = new PassengerController(mockDataRepo.Object);
        }
        [Fact]
        public void Test_GetAllPassengers()
        {
            //Arrange
            var resultType = mockDataRepo.Setup(x => x.getAllPassenger()).Returns(getPassengerList());
            //Act
            var response = _passengerController.getAllPassenger();
            //Assert
            Assert.Equal(3, response.Count);
        }

        [Fact]
        public void Test_DeletePassenger()
        {   
            //Arrange
            var passenger = new Passenger();
            passenger.PNumber = new System.Guid("1f02f425-800a-4f8d-aa8b-c1450981ce1e");
        
            var resultType = mockDataRepo.Setup(x => x.deletePassengerDetails(passenger.PNumber.ToString())).Returns(true);
            //Act
            var response = _passengerController.deletePassengerDetails(passenger.PNumber.ToString());
            //Assert
            Assert.True(response);
        }

        [Fact]
        public void Test_GetUserById()
        {
            //Arrange
            var passenger = new Passenger();
            passenger.PNumber = new System.Guid("3CDBC747-DB0A-4EF1-9353-6A1110DC05B9");

            var resultType = mockDataRepo.Setup(x => x.getPassengerByexID(passenger.PNumber.ToString())).Returns(passenger);
            //Act
            var result = _passengerController.GetPassenger(passenger.PNumber.ToString());
            //Assert
            var isNull = Assert.IsType<OkNegotiatedContentResult<Passenger>>(result);
            Assert.NotNull(isNull);
        }

        [Fact]
        public void Test_AddPassenger()
        {
            //Arrange
            var newpassenger = new Passenger() { PNumber = new System.Guid(), FirstName = "Pinkal", LastName = "SHARMA", PhoneNumber = "123456789" };
            var response = mockDataRepo.Setup(x => x.registerPassenger(newpassenger)).Returns(AddPassenger());
            //Act          
            var result = _passengerController.registerPassenger(newpassenger);
            //Assert
            Assert.NotNull(result);




        }




        [Fact]
        public void Test_UpdatePassenger()
        {
            //Act
            var model = JsonConvert.DeserializeObject<Passenger>(File.ReadAllText("Data/UpdatePassenger.json"));

            //Arrange
            var result = mockDataRepo.Setup(x => x.updatePassengerDetails(model)).Returns(model);
            var response = _passengerController.updatePassengerDetails(model);


            //Assert
            Assert.Equal(model, response);
        }






        private static IList<Passenger> getPassengerList()
        {
            IList<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){PNumber=new System.Guid("1f02f425-800a-4f8d-aa8b-c1450981ce1e"),FirstName="Ramesh",LastName="SHARMA",PhoneNumber="123456789"},
                new Passenger(){PNumber=new System.Guid("3CDBC747-DB0A-4EF1-9353-6A1110DC05B9"),FirstName="RAM",LastName="KUMAR",PhoneNumber="123456789"},
                new Passenger(){PNumber=new System.Guid("71db59ab-f61c-4ff6-ba2b-2ff4026b05b9"),FirstName="VIJAY",LastName="SHARMA",PhoneNumber="123456789"}
            };
            return passengers;
        }


        private static Passenger AddPassenger()
        {

            var passenger = new Passenger() {PNumber=new System.Guid("98D66512-B3F4-4107-BFB2-9E7BE0D82040"), FirstName = "YATIN", LastName = "SHARMA", PhoneNumber = "123456789" };               
            return passenger;
        }






    }





}
