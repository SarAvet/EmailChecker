using System;

namespace EmailCheckerDAL
{
    public abstract class BaseCheckResult
    {
        public String UserName { get; set; }
        abstract public String GetMessage();
    }
}
