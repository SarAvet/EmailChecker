using System;
using System.Security.Cryptography;
using System.Text;

namespace EmailCheckerDAL
{
    /// <summary>
    /// Класс для хранения и работы с паролями
    /// </summary>
    [Serializable]
    public class Password
    {
        private readonly String _privateKey;
        private readonly byte[] _password;

        public Password(String passwordText)
        {
            var rsa = new RSACryptoServiceProvider();
            _privateKey = rsa.ToXmlString(true);

            _password = Encrypt(passwordText.ToCharArray());
        }

        public Password(char[] passwordChars)
        {
            var rsa = new RSACryptoServiceProvider();
            _privateKey = rsa.ToXmlString(true);

            _password = Encrypt(passwordChars);
        }

        /// <summary>
        /// Получение текста пароля
        /// </summary>
        /// <returns>Текст пароля</returns>
        public String GetPasswordText()
        {
            var rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(_privateKey);

            var passwordBytes = rsa.Decrypt(_password, true);
            return Encoding.UTF8.GetString(passwordBytes);
        }

        private byte[] Encrypt(char[] passwordChars)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(_privateKey);

                var passwordBytes = Encoding.UTF8.GetBytes(passwordChars);
                return rsa.Encrypt(passwordBytes, true);
            }
            catch (CryptographicException)
            {
                throw new CryptographicException();
            }
        }

    }
}