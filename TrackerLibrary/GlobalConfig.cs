using System.Reflection;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary;

//cannot be instantiated, visible for everyone
public static class GlobalConfig
{
    public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

    //sets up connections for app
    public static void InitializeConnections(bool isDatabase, bool isTextFile)
    {
        if (isDatabase)
        {
            //create SQL connection
            SQLConnector sql = new SQLConnector();
            Connections.Add(sql);
        }

        if (isTextFile)
        {
           //create text connection
           TextFileConnection text = new TextFileConnection();
           Connections.Add(text);
        }
    }
    
}