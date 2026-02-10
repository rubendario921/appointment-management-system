using domain.repositories;
using domain.entity;
using infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.adapters;

public class AppointmentAdapters : IAppointmentRepository
{
    private readonly AppointmentDbContext _dbContext;

    public AppointmentAdapters(AppointmentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Appointment?> GetById(int id)
    {
        return await _dbContext.Appointment.FindAsync(id);
    }

    public async Task<List<Appointment>> GetByPlaque(string plaque)
    {
        return await _dbContext.Appointment.Where(p => p.Plaque == plaque.ToUpper()).ToListAsync();
    }

    public async Task<Appointment> Create(Appointment appointment)
    {
        _dbContext.Appointment.Add(appointment);
        await _dbContext.SaveChangesAsync();
        return appointment;
    }
}