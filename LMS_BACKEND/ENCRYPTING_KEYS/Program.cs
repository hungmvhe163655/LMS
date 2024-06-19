string accessKey = "";
string secretKey = "";
string url = "";
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
var iv = new string(char2);
var encryptionKey = new string(chars);

Console.WriteLine("your encryptionkey: " + encryptionKey);
Console.WriteLine("your iv: " + iv);
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
    Console.WriteLine("Write down your service Url: ");
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
