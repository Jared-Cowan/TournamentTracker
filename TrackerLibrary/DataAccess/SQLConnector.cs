using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess;

public class SQLConnector : IDataConnection
{
    public Prize CreatePrize(Prize model)
    {
        model.Id = 1;
        return model;
    }
}