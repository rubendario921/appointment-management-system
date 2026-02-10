using domain.value_object;

namespace domain.entity;

public class Appointment
{
    public int Id { get; set; }
    public string Plaque { get; set; }
    public DateTime CreatedHour { get; set; }
    public DateTime CreatedDate { get; set; }

    public Appointment() { Plaque = null!; }

    public Appointment(PlaqueVo plaque, TimeTableVo createdHour, DateTime createdDate)
    {
        Plaque = plaque.Value;
        CreatedHour = createdHour.Value;
        CreatedDate = createdDate;
    }
}