/// 2. Write a C# Sharp program that takes userid
/// and password as input (type string). After 3
/// wrong attempts, user will be rejected.

using System.Security.Cryptography;
using System.Text;

// initialize accounts
Dictionary<string, string> userInfoDb = new Dictionary<string, string>
{
    { "admin", ComputeSha256Hash("password") },
    { "soomin", ComputeSha256Hash("123456")}
};

// begin login loop
bool loginSuccess = false;
uint badAttempts = 0;
while (badAttempts < 3)
{
    Console.Write("User ID: ");
    string idAttempt = Console.ReadLine();
    if (idAttempt == null) { idAttempt = ""; }

    Console.Write("Password: ");
    string passwordAttempt = Console.ReadLine();
    if (passwordAttempt == null) { passwordAttempt = ""; }
    
    string pwOnRecord;

    try
    {
        // check if ID exists and get the password from dictionary
        pwOnRecord = userInfoDb[idAttempt];
    }
    catch
    {
        // throw new Exception("ID not found");
        Console.WriteLine("ID not found.");
        pwOnRecord = "";
    }

    if (pwOnRecord == "")
    {
        // if ID is not found, do nothing and go back to asking for id/pw
    }
    else if (pwOnRecord != ComputeSha256Hash(passwordAttempt))
    {
        badAttempts++;
        Console.WriteLine($"Incorrect attempt #{badAttempts}");
        if (badAttempts >= 3)
        {
            Console.WriteLine("Too many login attempts");
        }
    }
    else
    {
        loginSuccess = true;
        break;
    }
}
if (loginSuccess)
{
    // main menu and whatnot here
    Console.WriteLine("Login successful!");
}

/// https://www.c-sharpcorner.com/article/compute-sha256-hash-in-c-sharp/
static string ComputeSha256Hash(string rawData)
{
    // Create a SHA256
    using (SHA256 sha256Hash = SHA256.Create())
    {
        // ComputeHash - returns byte array
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
