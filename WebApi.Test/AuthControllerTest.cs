using DisneyMovies.Api.Controllers;
using DisneyMovies.Application.Authentication;
using DisneyMovies.Application.Authentication.Common;
using DisneyMovies.Application.DataTransferObjects;
using DisneyMovies.Application.Services;
using DisneyMovies.Core.Exceptions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace WebApi.Test;

public class AuthControllerTest
{
    [Fact]
    public void Register_Should_Return200Ok()
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
    public void Register_Should_Return400()
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

    [Fact]
    public void Login_Should_200OK()
    {
        //Arrange
        var logInReq = new LogInRequest() { Password = "password", UserName = "username" };
        var authService = new Mock<IAuthenticationService>();
        authService.Setup(x => x.LogIn(logInReq))
            .Returns(new AuthenticationResult { IsSuccess = true, Token = "token" });
        var sut = new Auth(authService.Object);

        //Act
        var result = (OkObjectResult)sut.LogIn(logInReq);

        //Assert
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void Login_Should_400BadRequest()
    {
        //Arrange
        var logInReq = new LogInRequest() { Password = "password", UserName = "username" };
        var authService = new Mock<IAuthenticationService>();
        authService.Setup(x => x.LogIn(logInReq))
            .Returns(new AuthenticationResult { IsSuccess = false, Token = "token" });
        var sut = new Auth(authService.Object);

        //Act
        var result = (BadRequestObjectResult)sut.LogIn(logInReq);

        //Assert
        result.StatusCode.Should().Be(400);
    }
}