namespace ASP.NET_AJAX.Models;

public class ApplicationResultModel
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public int BirthYear { get; set; }

    public int Age { get; set; }

    public string Education { get; set; } = string.Empty;

    public string Comment { get; set; } = string.Empty;

    public DateTime SubmittedAt { get; set; }
}
