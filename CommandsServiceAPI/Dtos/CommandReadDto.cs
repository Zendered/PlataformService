namespace CommandsServiceAPI.Dtos;

public class CommandReadDto
{
    public int Id { get; set; }
    public int PlatformId { get; set; }
    public string HowTo { get; set; } = string.Empty;
    public string CommandLine { get; set; } = string.Empty;
}
