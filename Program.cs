/// 2. Write a C# Sharp program that takes userid
/// and password as input (type string). After 3
/// wrong attempts, user will be rejected.

uint badAttempts = 0;
string userid="admin";
string password = "password";
bool loginSuccess = false;

while (badAttempts<3) {
    Console.Write("User ID: ");
    string idAttempt = Console.ReadLine();
    Console.Write("Password: ");
    string passwordAttempt = Console.ReadLine();
    if(userid!=idAttempt || password!=passwordAttempt) {
        badAttempts++;
        Console.WriteLine($"Incorrect attempt #{badAttempts}");
        if(badAttempts>=3) {
            Console.WriteLine("Too many login attempts");
        }
    } else {
        loginSuccess=true;
        break;
    }
}
if(loginSuccess) {Console.WriteLine("Login successful!");}
