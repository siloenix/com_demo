namespace test
{
    public class DefaultCommandListener : ICommandListener
    {
        public void Process(string input)
        {
            System.Console.Out.WriteLine($"<reader>: {input}");
        }
    }
}