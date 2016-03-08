using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Moq;
using SimpleApp.Controllers;
using SimpleApp.Core.Services;
using SimpleApp.DataLayer.Model;
using SimpleApp.Models;
using Xunit;

namespace SimpleApp.Test.Services
{
    /// <summary>
    /// Donor Service Test 
    /// </summary>
    [Trait("Service", "Donor")]
    public class DonorServiceTest
    {
        #region Private Members

        private readonly Mock<IService<Donor>> _mockDonorService;
        private readonly DonorsController _donorController;
        private List<Donor> _donors;
        private readonly Donor _donor;
        private readonly DateTime _deathDate;
        #endregion

        #region Constructor/Setup

        public DonorServiceTest()
        {
            //Create auto-mapping for models
            //This is crucial for all tests to work
            AutoMapperConfig.RegisterMappings();

            _mockDonorService = new Mock<IService<Donor>>();
            _donorController = new DonorsController(_mockDonorService.Object);

            //Sample _deathDate data
            _deathDate = new DateTime(2016, 01, 01);

            //Sample _donor data
            _donor = new Donor()
            {
                Id = 1,
                FirstName = "Chhai",
                LastName = "Eng",
                OrganType = "Liver",
                DeathDateTime = _deathDate
            };

            //Sample list of _donors data
            _donors = new List<Donor>()
                    {
                        new Donor() {Id = 1, FirstName = "Chhai", LastName = "Eng", OrganType = "Liver", DeathDateTime = DateTime.Now},
                        new Donor() {Id = 2, FirstName = "Jonathan", LastName = "Lee", OrganType = "Heart", DeathDateTime = DateTime.Now},
                        new Donor() {Id = 3, FirstName = "Mia", LastName = "Su", OrganType = "Liver", DeathDateTime = DateTime.Now},
                        new Donor() {Id = 4, FirstName = "Ben", LastName = "Eng", OrganType = "Kidney", DeathDateTime = DateTime.Now}
                    };
        }

        #endregion

        #region Add Test

        /// <summary>
        /// Test service for Adding a new _donor
        /// Also testing controller's Create action
        /// </summary>
        [Fact]
        public void AddTest()
        {
            //-------- Arrage --------
            var tempDonor = new Donor();

            //Will throw ArgumentNullException if adding a null _donor
            _mockDonorService.Setup(x => x.Add(tempDonor));

            //-------- Act --------
            //Redirect to the Index page upon successfully adding a new _donor
            var result = (RedirectToRouteResult)_donorController.Create(tempDonor);

            //-------- Assert --------
            //Expecting the redirected page to be "Index"
            Assert.Equal("Index", result.RouteValues["action"]);
        }

        #endregion

        #region Update Test

        /// <summary>
        /// Test service for Updating a donor
        /// Also testing controller's Edit action
        /// </summary>
        [Fact]
        public void UpdateTest()
        {
            //-------- Arrage --------
            //Will throw ArgumentNullException if adding/updating a null _donor
            //_mockDonorService.Setup(x => x.Add(_donor));

            //Updating OrganType from Liver to Heart
            _donor.OrganType = "Heart";

            //Updating the donor
            _mockDonorService.Setup(x => x.Update(_donor));

            //Retrieving the donor
            _mockDonorService.Setup(x => x.FindById(_donor.Id)).Returns(_donor);

            //-------- Act --------
            //Redirect to the Index page upon successfully updating a new _donor
            var result = Mapper.Map<DonorVM>(((ViewResult)_donorController.Edit(_donor.Id)).Model);

            //-------- Assert --------
            //Expecting the redirected page to be "Index"
            Assert.Equal("Heart", result.OrganType);
        }

        #endregion

        #region FindById Test

        /// <summary>
        /// Test service for FindById returning the proper _donor
        /// Also test controller for Details action to return proper model
        /// </summary>
        [Fact]
        public void FindByIdTest()
        {
            //-------- Arrange --------
            //FindById to return the correct _donor
            _mockDonorService.Setup(x => x.FindById(_donor.Id)).Returns(_donor);

            //-------- Act --------
            //Getting result from controller details action
            //Mapping data model to view model with automapper
            var result = Mapper.Map<DonorVM>(((ViewResult) _donorController.Details(_donor.Id)).Model);

            //-------- Assert --------
            //Check all data returning from FindById are correct
            Assert.Equal("Chhai", result.FirstName);
            Assert.Equal("Eng", result.LastName);
            Assert.Equal("Liver", result.OrganType);
            Assert.Equal(_deathDate, result.DeathDateTime);
        }

        #endregion
    }
}