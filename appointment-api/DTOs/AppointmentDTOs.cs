namespace appointment_api.DTOs;

public class AppointmentDTOs
{
    public record AppointmentDto(int Id, string Plaque, DateTime CreatedHour);

    public record NewAppointment(string Plaque, DateTime CreatedHour);

    public record ResultDto<T>(bool Success, T Data, string? Message);
}