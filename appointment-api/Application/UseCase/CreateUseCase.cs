using System.Runtime.CompilerServices;
using domain.entity;
using domain.repositories;

namespace application.UseCase;

public class CreateUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;
    public CreateUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public Task<Appointment> CreateAsync(Appointment data)
    {
        if(data is null) throw new ArgumentNullException(nameof(data));
        return _appointmentRepository.Create(data);
    }
}