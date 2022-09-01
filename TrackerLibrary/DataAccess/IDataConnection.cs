using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public interface IDataConnection
{
    Prize CreatePrize(Prize model);
}