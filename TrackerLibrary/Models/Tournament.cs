namespace TrackerLibrary.Models;

public class Tournament
{
    public string TournamentName { get; set; }
    
    public decimal EntryFee { get; set; }
    
    public List<Team> EnteredTeams { get; set; } = new();
    
    public List<Prize> Prizes { get; set; } = new();
    
    private List<List<Matchup>> Rounds { get; set; } = new();
}