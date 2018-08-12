using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using HotelManagementSystem.Models;
using FluentAssertions;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class ShowHotelSteps
    {
        private Hotel hotel = new Hotel();
        private List<Hotel> hotels = new List<Hotel>();
        private List<Hotel> _hotelVerify = new List<Hotel>();
        
        [Given(@"User provided valid Id (.*) and name '(.*)' for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }
        public void GivenUserHasAddedRequiredDetailsForHotel()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 11, RoomType = "supreme" } };
            hotel.Address = "Pune City";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
            _hotelVerify.Add(hotel);
        }
        [Given(@"User calls AddHotel api")]
        public void GivenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }
        
        [Then(@"Hotels with their details should be displayed in the response")]
        public void ThenHotelsWithTheirDetailsShouldBeDisplayedInTheResponse()
        {
            _hotelVerify.Should().BeSubsetOf(hotels);
        }

    }
}
