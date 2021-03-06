using ArmenianChairDogsitting.API.Controllers;
using ArmenianChairDogsitting.Data.Enums;
using ArmenianChairDogsitting.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArmenianChairDogsitting.Data.Entities;

namespace ArmenianChairDogsitting.API.Tests;

public class SittersControllerTests
{
    private SittersController _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new SittersController();
    }

    [Test]
    public void AddSitter_ValidRequestPassed_CreatedResultReceived()
    {
        //given
        var expectedId = 1;
        var sitter = new SitterRequest()
        {
            Name = "Ilya",
            LastName = "Bozhkov",
            Phone = "89375674583",
            Email = "akfm@aof.d",
            Password = "123456789",
            Age = 27,
            Experience = 7,
            Sex = Sex.Male
        };
        //when
        var actual = _sut.AddSitter(sitter);

        //then
        var actualResult = actual.Result as CreatedResult;

        Assert.AreEqual(StatusCodes.Status201Created, actualResult.StatusCode);
        Assert.AreEqual(expectedId, actualResult.Value);
    }

    [Test]
    public void GetSitterById_ValidRequestPassed_OkReceived()
    {
        //given
        var expectedSitter = new SitterMainInfoResponse();
        var sitterId = 1;

        //when
        var actual = _sut.GetSitterById(sitterId);

        //then
        var actualResult = actual.Result as ObjectResult;

        Assert.AreEqual(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.AreEqual(expectedSitter.GetType(), actualResult.Value.GetType());
    }

    [Test]
    public void UpdateSitterById_ValidRequestPassed_NoContentReceived()
    {
        //given
        var expectedSitter = new SitterUpdateRequest();
        var sitterId = 2;

        //when
        var actual = _sut.UpdateSitter(expectedSitter, sitterId);

        //then
        var actualResult = actual as NoContentResult;

        Assert.AreEqual(StatusCodes.Status204NoContent, actualResult.StatusCode);

    }

    [Test]
    public void GetAllSitters_ValidRequestPassed_OkReceived()
    {
        //given
        var expectedListSitters = new List<SitterAllInfoResponse>();

        //when
        var actual = _sut.GetAllSitters();

        //then
        var actualResult = actual.Result as ObjectResult;

        Assert.AreEqual(StatusCodes.Status200OK, actualResult.StatusCode);
        Assert.AreEqual(expectedListSitters.GetType(), actualResult.Value.GetType());
    }

    [Test]
    public void RemoveOrRestoreSitterById_ValidRequestPassed_NoContentReceived()
    {
        //given
        var sitterId = 1;

        //when
        var actual = _sut.RemoveOrRestoreSitterById(sitterId);

        //then
        var actualResult = actual as NoContentResult;

        Assert.AreEqual(StatusCodes.Status204NoContent, actualResult.StatusCode);
    }

    [Test]
    public void UpdatePasswordSitter_ValidRequestPassed_NoContentReceived()
    {
        //given
        var sitterId = 1;
        var password = "123456789";

        //when
        var actual = _sut.UpdatePasswordSitter(sitterId, password);

        //then
        var actualResult = actual as NoContentResult;

        Assert.AreEqual(StatusCodes.Status204NoContent, actualResult.StatusCode);
    }

    [Test]
    public void UpdatePriceCatalogSitter_ValidRequestPassed_NoContentReceived()
    {
        //given
        var sitterId = 1;
        var priceCatalog = new List<PriceCatalog>();

        //when
        var actual = _sut.UpdatePriceCatalogSitter(sitterId, priceCatalog);

        //then
        var actualResult = actual as NoContentResult;

        Assert.AreEqual(StatusCodes.Status204NoContent, actualResult.StatusCode);
    }
}