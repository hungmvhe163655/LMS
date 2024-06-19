string encryptionKey = null; // Ensure this is a 32-byte (256-bit) key
string iv = null;             // Ensure this is a 16-byte (128-bit) IV

string accessKey = null;
string secretKey = null;
string url = null;
bool check = true;
string checker = "n";

const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-";
char[] chars = new char[32];
char[] char2 = new char[16];
Random rd = new Random();
for (int i = 0; i < 32; i++)
{
    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
}
for (int i = 0; i < 16; i++)
{
    char2[i] = allowedChars[rd.Next(0, allowedChars.Length)];
}
var hold16 = new string(char2);
var hold32 = new string(chars);
encryptionKey = hold32;
iv = hold16;
Console.WriteLine("your encryptionkey: " + encryptionKey);
Console.WriteLine("your iv: " + iv);
/*
while (check)
{
    Console.WriteLine("Please enter your encryptionKey (32 characters)");
    encryptionKey = Console.ReadLine();
    if (encryptionKey == null || encryptionKey.Length != 32)
    {
        Console.WriteLine("String not long enough or too short");
    }
    else
    {
        Console.WriteLine("Is this correct? " + encryptionKey + " y/n: ");

        checker = Console.ReadLine();
        if (checker != null || checker.Equals("y"))
        {
            check = false;
            checker = "n";
        }
    }
}
check = true;
while (check)
{
    Console.WriteLine("Please enter your iv (16 characters)");
    iv = Console.ReadLine();
    if (iv == null || iv.Length != 16)
    {
        Console.WriteLine("String not long enough or too short");
    }
    else
    {
        Console.WriteLine("Is this correct? " + iv + " y/n: ");

        checker = Console.ReadLine();
        if (checker != null && checker.Equals("y"))
        {
            check = false;
            checker = "n";
        }
    }
}
*/
check = true;
while (check)
{
    Console.WriteLine("Please enter your Accesskey");
    accessKey = Console.ReadLine();
    Console.WriteLine("Is this correct? " + accessKey + " y/n: ");
    checker = Console.ReadLine();
    if (checker != null && checker.Equals("y"))
    {
        check = false;
        checker = "n";
    }
}
check = true;
while (check)
{
    Console.WriteLine("Please enter your SecretKey");
    secretKey = Console.ReadLine();
    Console.WriteLine("Is this correct? " + secretKey + " y/n: ");
    checker = Console.ReadLine();
    if (checker != null && checker.Equals("y"))
    {
        check = false;
        checker = "n";
    }

}
check = true;
while (check)
{
    Console.WriteLine("Write down your service Url (ex : https://<your_account_id>.r2.cloudflarestorage.com)");
    url = Console.ReadLine();
    Console.WriteLine("Is this correct? " + url + " y/n: ");
    checker = Console.ReadLine();
    if (checker != null && checker.Equals("y"))
    {
        check = false;
        checker = "n";
    }
}
Console.WriteLine("Press Enter To save to enviroment");
Console.ReadLine();
if (accessKey != null && encryptionKey != null && secretKey != null && iv != null)
{
    string encryptedAccessKey = EncryptionHelper.EncryptString(accessKey, encryptionKey, iv);
    string encryptedSecretKey = EncryptionHelper.EncryptString(secretKey, encryptionKey, iv);
    string encryptedURL = EncryptionHelper.EncryptString(url, encryptionKey, iv);

    EncryptionHelper.SetEnvironmentVariableSystemWide("ENCRYPTED_ACCESS_KEY", encryptedAccessKey);
    EncryptionHelper.SetEnvironmentVariableSystemWide("ENCRYPTED_SECRET_KEY", encryptedSecretKey);
    EncryptionHelper.SetEnvironmentVariableSystemWide("EncryptionKey", encryptionKey);
    EncryptionHelper.SetEnvironmentVariableSystemWide("ivKey", iv);
    EncryptionHelper.SetEnvironmentVariableSystemWide("SERVICE_URL", encryptedURL);
}
