namespace TrackerLibrary.Models;

public class Matchup
{
    public List<MatchupEntry> Entries { get; set; } = new();
    
    public Team Winner { get; set; } = null!;

    public int MatchupRound { get; set; }
}