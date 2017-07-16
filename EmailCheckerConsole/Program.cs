using EmailCheckerDAL;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace EmailCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var emailConnectionsData = new List<EmailConnectionData>
            {
                new EmailConnectionData
                {
                    EmailServerHost = "imap.yandex.ru",
                    EmailServerPort = 993,
                    UserName = "avetisyan.sar@yandex.ru",
                    Password = new Password("urartukahak859")
                },
                new EmailConnectionData
                {
                    EmailServerHost = "imap.yandex.ru",
                    EmailServerPort = 993,
                    UserName = "sar.avetisian@yandex.ru",
                    Password = new Password("noviyurartukahak859")
                }
            };
            */

            var emailDataWriter = new EmailDataWriter();
            emailDataWriter.WriteConnectionsData(new[] { new EmailConnectionData()
            {
                EmailServerHost = "imap.yandex.ru",
                EmailServerPort = 993,
                UserName = "sar.avetisian@yandex.ru",
                Password = new Password("noviyurartukahak859")
            } });

            var emailConnectionsData = (IList<EmailConnectionData>) new EmailDataReader().ReadConnectionsData();
            var emailChecker = new EmailChecker(emailConnectionsData);
            var emailCheckResults = emailChecker.GetCheckResults();

            emailCheckResults
                .ToList()
                .ForEach(e => {
                    Console.WriteLine(e.GetMessage());
                });
            Console.Read();
           
        }
    }
}
