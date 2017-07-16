using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmailCheckerDAL
{
    public class EmailDataReader
    {
        public IList<EmailConnectionData> ReadConnectionsData()
        {
            var binaryFormatter = new BinaryFormatter();

            using (var stream = new FileStream("data.dat", FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var emailConnectionsData = (IList<EmailConnectionData>)binaryFormatter.Deserialize(stream);
                return emailConnectionsData;
            }
        }
    }
}
