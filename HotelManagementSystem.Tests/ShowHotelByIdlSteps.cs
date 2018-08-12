using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class ShowHotelByIdlSteps
    {

        private Hotel hotel = new Hotel();
        private List<Hotel> hotels = new List<Hotel>();
        [Given(@"User provided valid Id '<id>'  and '<name>'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }
        [Given(@"User has added required details for hotel")]
        public void GivenUserHasAddedRequiredDetailsForHotel()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
        [Given(@"User calls AddHotel api to add hotel")]
        public void GivenUserCallsAddHotelApiToAddHotel()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [When(@"User calls GetHotelById with '(.*)' api")]
        public void WhenUserCallsGetHotelByIdWithApi(int hotelId)
        {
            hotel = HotelsApiCaller.GetHotelById(hotelId);
        }
        [Then(@"Hotel with '(.*)' should be present in the response")]
        public void ThenHotelWithShouldBePresentInTheResponse(int hotelId)
        {
            var verifyHotel = hotels.Find(ht => ht.Id == hotel.Id);
            verifyHotel.Should().NotBeNull(string.Format("Added hotel is not present"));
        }
        
    }
}
