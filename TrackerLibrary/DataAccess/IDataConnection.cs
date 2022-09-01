using TournamentTracker.Data;

namespace TrackerLibrary.DataAccess;

public interface IDataConnection
{
    Prize CreatePrize(Prize model);
}