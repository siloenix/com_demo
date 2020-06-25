using System.Diagnostics;

namespace test
{
    public interface ICommandListener
    {
        void Process(string input);
    }
}