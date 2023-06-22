using Newtonsoft.Json;

namespace Library.MvcUi.Models.Writer;

public class WriterModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [JsonIgnore]
    public string FullName
    {
        get
        {
            return $"{FirstName} {LastName}";
        }
        set
        {
            FullName = value;
        }
    }
}

