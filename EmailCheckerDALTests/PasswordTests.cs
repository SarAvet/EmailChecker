using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailCheckerDAL;
using System.Security.Cryptography;

namespace EmailCheckerDALTests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void EncryptDecryptEmptyPassword()
        {
            var passwordText = "";
            var actual = new Password(passwordText).GetPasswordText();
            var expected = passwordText;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncryptDecryptMaxLengthPassword()
        {
            //86 symbols
            var passwordText = "788887!zP4RFF78J*=@2rsdAVDE!xxSCA&?U+5=FHE*2AJkLf4?h#yNSCNhh4Vsds$TSCS8zK$#-rLEZ*Qn#9P";
            var actual = new Password(passwordText).GetPasswordText();
            var expected = passwordText;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EncryptDecryptOverMaxLengthPassword()
        {
            try
            {
                //87 symbols
                var passwordText = "asd7788887!zP4RFF78J*=@2rsdAVDE!xxSCA&?U+5=FHE*2AJkLf4?h#yNSCNhh4Vsds$TSCS8zK$#-rLEZ*Qn#9P";
                var actual = new Password(passwordText);

                Assert.AreEqual(0, 1);
            }
            catch(CryptographicException)
            {
                Assert.AreEqual(1,1);
            }
        }

        [TestMethod]
        public void CharsEncryptDecryptEmptyPassword()
        {
            var passwordText = new char[] { };
            var actual = new Password(passwordText).GetPasswordText();
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharsEncryptDecryptMaxLengthPassword()
        {
            //86 symbols
            var passwordText = "788887!zP4RFF78J*=@2rsdAVDE!xxSCA&?U+5=FHE*2AJkLf4?h#yNSCNhh4Vsds$TSCS8zK$#-rLEZ*Qn#9P";
            var actual = new Password(passwordText.ToCharArray()).GetPasswordText();
            var expected = passwordText;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CharsEncryptDecryptOverMaxLengthPassword()
        {
            try
            {
                //87 symbols
                var passwordText = "asd7788887!zP4RFF78J*=@2rsdAVDE!xxSCA&?U+5=FHE*2AJkLf4?h#yNSCNhh4Vsds$TSCS8zK$#-rLEZ*Qn#9P";
                var actual = new Password(passwordText.ToCharArray());

                Assert.AreEqual(0, 1);
            }
            catch (CryptographicException)
            {
                Assert.AreEqual(1, 1);
            }
        }

    }
}
