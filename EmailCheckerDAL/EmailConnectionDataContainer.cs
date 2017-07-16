using System;
using System.Collections.Generic;

namespace EmailCheckerDAL
{
    [Serializable]
    public class EmailConnectionDataContainer
    {
        public IList<EmailConnectionData> EmailConnectionsData { get; set; }
    }
}
