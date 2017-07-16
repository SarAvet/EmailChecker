using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmailCheckerDAL
{
    public class EmailDataWriter
    {
        public void WriteConnectionsData(IList<EmailConnectionData> emailConnectionsData)
        {
            var emailConnectionData = new EmailConnectionDataContainer() {
                EmailConnectionsData = emailConnectionsData
            };

            var binaryFormatter = new BinaryFormatter();

            using (var stream = new FileStream("data.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binaryFormatter.Serialize(stream, emailConnectionsData);
            }

        }

        public void AddConnectionsData(IList<EmailConnectionData> addedEmailConnectionsData)
        {
            var emailDataReader = new EmailDataReader();
            var newEmailConnectionsData = new List<EmailConnectionData>(emailDataReader.ReadConnectionsData());
            newEmailConnectionsData.AddRange(addedEmailConnectionsData);

            var emailDataConnectionsData = new EmailConnectionDataContainer()
            {
                EmailConnectionsData = newEmailConnectionsData
            };
            
            var binaryFormatter = new BinaryFormatter();

            using (var stream = new FileStream("data.dat", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binaryFormatter.Serialize(stream, addedEmailConnectionsData);
            }

        }

    }
}
