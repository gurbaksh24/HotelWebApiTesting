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
        private Hotel hotels = new Hotel();
        [When(@"User calls GetHotelById with '(.*)' api")]
        public void WhenUserCallsGetHotelByIdWithApi(int hotelId)
        {
            hotels = HotelsApiCaller.GetHotelById(hotelId);
        }


        [Then(@"Hotel with '(.*)' should be displayed in the response")]
        public void ThenHotelWithShouldBeDisplayedInTheResponse(int hotelId)
        {
            hotels.Id.Should().Be(hotelId);
            //hotels.Should().Be(hotelId);
            //hotel = hotels.Find(ht => ht.Id == hotelId);
            //hotel.Should().NotBeNull(string.Format("No hotel found with this id"));
        }
    }
}
