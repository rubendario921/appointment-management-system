namespace domain.value_object;

public class TimeTableVo
{
 private readonly DateTime _timeTable;

 public TimeTableVo(DateTime timeTable)
 {
  //Monday a Friday
  if(timeTable.DayOfWeek == DayOfWeek.Saturday || timeTable.DayOfWeek == DayOfWeek.Sunday) throw new ArgumentException("Time table must be a working day");
  
  //8:00 AM to 2:00 PM
  var time = timeTable.TimeOfDay;
  if(time < new TimeSpan(8,0,0) || time > new TimeSpan(14,0,0)) throw new ArgumentException("Time table must be between 8:00 AM and 2:00 PM");
  
  //Interval of 30 minutes
  if(timeTable.Minute % 30 != 0) throw new ArgumentException("Time table must be every 30 minutes");
  
  _timeTable = timeTable;
 }
 
 public DateTime Value => _timeTable;
}