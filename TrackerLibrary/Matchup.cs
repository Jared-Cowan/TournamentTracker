namespace TrackerLibrary;

public class Matchup
{
    public List<MatchupEntry> Entries { get; set; } = new();
    
    public Team Winner { get; set; }

    public int MatchupRound { get; set; }
}