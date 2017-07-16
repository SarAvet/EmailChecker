using EmailCheckerDAL.EmailCheckResult;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace EmailCheckerDAL
{
    public class EmailChecker
    {
        private readonly IList<EmailConnectionData> _emailConnectionData;

        public EmailChecker(IList<EmailConnectionData> emailConnectionData)
        {
            _emailConnectionData = emailConnectionData;
        }
        
        /// <summary>
        /// Производит чтение сообщений по почтовым данным
        /// </summary>
        /// <returns>Коллекция результатов чтения</returns>
        public IList<BaseCheckResult> GetCheckResults()
        {
            var emailCheckResults = new List<BaseCheckResult>();


            _emailConnectionData
                .ToList()
                .ForEach(e=> {
                    using (var imapClient = new ImapClient())
                    {
                        BaseCheckResult emailCheckResult = null;
                        try
                        {
                            imapClient.Connect(e.EmailServerHost, e.EmailServerPort, true);
                            imapClient.Authenticate(e.UserName, e.Password.GetPasswordText());

                            var mailFolder = imapClient.Inbox;
                            mailFolder.Open(FolderAccess.ReadOnly);
                            var newMessageCount = mailFolder.Search(SearchQuery.NotSeen).Count;

                             emailCheckResult = new CheckResult
                            {
                                NewMessageCount = newMessageCount,
                                UserName = e.UserName
                            };
                        }
                        catch(AuthenticationException)
                        {
                            emailCheckResult = new CheckResultWithError
                            {
                                UserName = e.UserName,
                                Error = "неправильный логин или пароль."
                            };
                        }
                        catch (SocketException)
                        {
                            emailCheckResult = new CheckResultWithError
                            {
                                UserName = e.UserName,
                                Error = "не удалось устанрвить соединение."
                            };
                        }
                        finally
                        {
                            emailCheckResults.Add(emailCheckResult);
                        }
                    }
                });

            return emailCheckResults;
        }



    }
}
