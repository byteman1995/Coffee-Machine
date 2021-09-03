using System.IO;
using System.Runtime.CompilerServices;

namespace CoffeeMachine.Services
{
    class PrinterService
    {
        string filePath = "..\\..\\..\\Resources\\output.txt";
        public PrinterService(string filePath)
        {
            this.filePath = filePath;
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void print(string message)
        {
            // Appending the given texts
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(message);
            }

            return;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void clearFile()
        {
            if (!File.Exists(filePath))
                File.Create(filePath);

            TextWriter tw = new StreamWriter(filePath, false);
            tw.Write(string.Empty);
            tw.Close();
        }
    }
}
