using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RentalHousingService.WEB.Helpers
{
    public static class UserHelper
    {
        public static string CreatePasswordHash(string password, string dynamicSalt, string globalSalt)
        {
            byte[] passwordInBytes = Encoding.UTF8.GetBytes(password);
            byte[] dynamicSaltInBytes = Encoding.UTF8.GetBytes(dynamicSalt);
            byte[] globalSaltInBytes = Encoding.UTF8.GetBytes(globalSalt);

            var sha = new SHA1CryptoServiceProvider();

            var hashOfPassword = sha.ComputeHash(passwordInBytes);

            var firstAddition = hashOfPassword.Concat(dynamicSaltInBytes).ToArray();
            var hashOfPasswordAndDS = sha.ComputeHash(firstAddition);

            var secondAddition = hashOfPasswordAndDS.Concat(globalSaltInBytes).ToArray();
            var passwordHash = sha.ComputeHash(secondAddition).ToString();

            return passwordHash;
        }
    }
}