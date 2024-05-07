const string EXIT_COMMAND = "exit";

try
{
    while (true)
    {
        var result = Console.ReadLine();
        if(result.ToLower() == EXIT_COMMAND)
        {
            Environment.Exit(0);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
