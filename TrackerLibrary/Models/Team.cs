﻿namespace TrackerLibrary.Models;

public class Team
{
    public List<Person> TeamMembers { get; set; } = new();
    
    public string TeamName { get; set; }
}