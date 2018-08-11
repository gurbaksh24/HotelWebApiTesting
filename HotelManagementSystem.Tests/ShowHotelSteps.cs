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

        private List<Hotel> hotels = new List<Hotel>();
        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }
        
        [Then(@"Hotels with their details should be displayed in the response")]
        public void ThenHotelsWithTheirDetailsShouldBeDisplayedInTheResponse()
        {
            hotels.Should().NotBeNull(string.Format("No Hotel found"));
        }

    }
}
