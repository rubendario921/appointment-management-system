using application.UseCase;
using appointment_api.DTOs;
using domain.entity;
using domain.value_object;
using Microsoft.AspNetCore.Mvc;

namespace appointment_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly ILogger<AppointmentController> _logger;
    private readonly CreateUseCase _createUseCase;
    private readonly GetByPlaqueUseCase _getByPlaqueUseCase;
    private readonly GetByIdUseCase _getByIdUseCase;

    public AppointmentController(
        ILogger<AppointmentController> logger, 
        CreateUseCase createUseCase,
        GetByPlaqueUseCase getByPlaqueUseCase, 
        GetByIdUseCase getByIdUseCase)
    {
        _logger = logger;
        _createUseCase = createUseCase;
        _getByPlaqueUseCase = getByPlaqueUseCase;
        _getByIdUseCase = getByIdUseCase;
    }

    [HttpGet("history/{plaque}")]    
    public async Task<IActionResult> GetHistory(string plaque)
    {
        var result = await _getByPlaqueUseCase.GetByPlaqueAsync(plaque);
        if (result == null || result.Count == 0) return NotFound();
        
        var response = new AppointmentDTOs.ResultDto<List<Appointment>>(true, result, "Appointment found");
        return Ok(response);
    }

    [HttpGet("{id}")]    
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _getByIdUseCase.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(new AppointmentDTOs.ResultDto<Appointment>(true, result, "Appointment found"));
    }

    [HttpPost]   
    public async Task<IActionResult> NewAppointment([FromBody] AppointmentDTOs.NewAppointment request)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var appointment = new Appointment(
                new PlaqueVo(request.Plaque), 
                new TimeTableVo(request.CreatedHour), 
                DateTime.Now);

            var result = await _createUseCase.CreateAsync(appointment);
            var response = new AppointmentDTOs.ResultDto<Appointment>(true, result, "Appointment created");
            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new AppointmentDTOs.ResultDto<string>(false, string.Empty, ex.Message));
        }
    }
}