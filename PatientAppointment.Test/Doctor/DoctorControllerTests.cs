using Moq;
using Microsoft.AspNetCore.Mvc;
using PatientAppointment.API.Controllers.Doctor;
using PatientAppointment.Application.DTO.Doctor;
using PatientAppointment.Application.IService.Doctor;


public class DoctorControllerTests
{
    private readonly DoctorController _controller;
    private readonly Mock<IDoctorService> _doctorServiceMock;

    public DoctorControllerTests()
    {
        _doctorServiceMock = new Mock<IDoctorService>();
        _controller = new DoctorController(_doctorServiceMock.Object);
    }

    [Fact]
    public async Task AddDoctor_ReturnsSuccessResponse()
    {
        // Arrange
        var mockDoctorService = new Mock<IDoctorService>();
        mockDoctorService
            .Setup(s => s.AddDoctor(It.IsAny<DoctorDto>()))
            .Returns(Task.CompletedTask);

        var controller = new DoctorController(mockDoctorService.Object);

        var doctorDto = new DoctorDto
        {
            Name = "Nazib Mahfuz",
            ContactNo = "01777127618",
            Title = "PhD, MBBS, FCPSC"
        };

        // Act
        var result = await controller.AddDoctor(doctorDto);

        // Assert
        var jsonResult = Assert.IsType<JsonResult>(result);
        Assert.NotNull(jsonResult.Value);

        Assert.True(true);

    }



    [Fact]
    public async Task GetAllDoctors_ReturnsListOfDoctors()
    {
        // Arrange
        var doctors = new List<DoctorDto>
        {
            new DoctorDto { Id = 1, Name = "Dr. John", ContactNo = "123456789", Title = "MD" },
            new DoctorDto { Id = 2, Name = "Dr. Jane", ContactNo = "987654321", Title = "PhD" }
        };
        _doctorServiceMock.Setup(service => service.GetAllDoctors()).ReturnsAsync(doctors);

        // Act
        var result = await _controller.GetAllDoctors();

        // Assert
        var actionResult = Assert.IsType<JsonResult>(result);
    }
}
