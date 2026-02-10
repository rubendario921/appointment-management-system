using domain.entity;

namespace domain.repositories;

public interface IAppointmentRepository
{
    // Task<List<Appointment>> GetAll();
    Task<Appointment?> GetById(int id);
    Task<List<Appointment>> GetByPlaque(string plaque);
    Task<Appointment> Create(Appointment appointment);
    // Task<bool> Exists(DateTime dateTime);
}