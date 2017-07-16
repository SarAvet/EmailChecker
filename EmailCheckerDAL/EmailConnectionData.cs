using System;

namespace EmailCheckerDAL
{
    [Serializable]
    public class EmailConnectionData
    {
        public String UserName { get; set; }
        public Password Password { get; set; }
        public String EmailServerHost { get; set; }
        public int EmailServerPort { get; set; }
    }
}
