
namespace EmailCheckerDAL
{
    public class CheckResult : BaseCheckResult 
    {
        public int NewMessageCount { get; set; }

        public override string GetMessage()
        {
            return $"Пользователь: {UserName}, кол-во сообщений: {NewMessageCount}";
        }
    }
}
