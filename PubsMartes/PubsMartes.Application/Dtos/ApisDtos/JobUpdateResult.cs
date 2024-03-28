namespace PubsMartes.Application.Dtos.Jobs;

public class JobUpdateResult
{
    public bool success { get; set; }
    public string message { get; set; }
    public JobsDtoUpdate data { get; set; }
}