using System;

namespace EmailCheckerDAL.EmailCheckResult
{
    public class CheckResultWithError : BaseCheckResult
    {
        public Object Error { get; set; }

        public override string GetMessage()
        {
            return $"Произошла ошибка: пользователь {UserName}, ошибка: {Error}";
        }
    }
}
