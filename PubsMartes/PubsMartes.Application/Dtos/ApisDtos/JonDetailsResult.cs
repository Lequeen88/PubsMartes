namespace PubsMartes.Application.Dtos.Jobs;

public class JonDetailsResult
{
    public bool success { get; set; }
    public string message { get; set; }
    public List<JobsDtoGetAll> data { get; set; }
}