using domain.entity;
using domain.repositories;

namespace application.UseCase;

public class GetByIdUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetByIdUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public Task<Appointment?> GetByIdAsync(int id)
    {
        if (id <= 0) throw new ArgumentException("Id must be greater than 0.", nameof(id));
        return _appointmentRepository.GetById(id);
    }
}