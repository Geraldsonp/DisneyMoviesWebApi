using DisneyMovies.Api.Controllers;
using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.DataTransferObjects;
using DisneyMovies.Application.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace WebApi.Test;

public class AuthControllerTest
{
    [Fact]
    public void Authenticate_Should_Return200Ok()
    {
        //Arrange
        var request = new RegisterRequest() { Email = "", Name = "", Password = "", UserName = "" };
        var authService = new Mock<IAuthenticationService>();
        authService.Setup(x => x.Register(request))
            .Returns(new AuthenticationResult()
            { IsSuccess = true, Token = "123456789" });
        Auth sut;
        sut = new Auth(authService.Object);

        //Act
        var result = (OkObjectResult)sut.Register(request);

        //assert
        result.StatusCode.Should().Be(200);
    }
    [Fact]
    public void Authenticate_Should_Return400()
    {
        //Arrange
        var request = new RegisterRequest() { Email = "", Name = "", Password = "", UserName = "" };
        var authService = new Mock<IAuthenticationService>();
        authService.Setup(x => x.Register(request))
            .Returns(new AuthenticationResult()
                { IsSuccess = false, Token = "123456789" });
        var sut = new Auth(authService.Object);

        //Act
        var result = (BadRequestResult)sut.Register(request);

        //assert
        result.StatusCode.Should().Be(400);
    }
}