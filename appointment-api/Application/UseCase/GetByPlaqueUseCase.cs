using domain.entity;
using domain.repositories;

namespace application.UseCase;

public class GetByPlaqueUseCase
{
    private readonly IAppointmentRepository _appointmentRepository;

    public GetByPlaqueUseCase(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public Task<List<Appointment>> GetByPlaqueAsync(string plaque)
    {
        if (string.IsNullOrWhiteSpace(plaque))
            throw new ArgumentException("Plaque is required.", nameof(plaque));

        return _appointmentRepository.GetByPlaque(plaque);
    }
}