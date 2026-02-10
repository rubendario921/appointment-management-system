namespace domain.value_object;

public class PlaqueVo
{
 private readonly string _plaque;

 public PlaqueVo(string plaque)
 {
  if(string.IsNullOrWhiteSpace(plaque)) throw new ArgumentException("Plaque is required");
  if (plaque.Length > 7) throw new ArgumentException("Plaque must be 7 characters");
  if (!System.Text.RegularExpressions.Regex.IsMatch(plaque, @"^[A-Z]{3}\d{4}$")) throw new ArgumentException("Plaque must be in the format ABC1234");
  _plaque = plaque;
 }
 
 public string Value => _plaque;
}