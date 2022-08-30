using System.Diagnostics;
using System.Text;

namespace XIV.DataStructures.Test
{
    using Console = System.Console;

    public abstract class DataStructureTest
    {
        static StringBuilder writer = new StringBuilder();
        protected Stopwatch stopwatch = new Stopwatch();
        public float ElapsedSeconds => stopwatch.ElapsedMilliseconds / 1000f;

        public virtual void Main()
        {
            Write("--------- " + this.GetType().Name + " Test ---------", 2);
        }

        public static void Write(string value, int lineSpace = 1)
        {
            writer.Append(value);
            for (int i = 0; i < lineSpace; i++)
            {
                writer.AppendLine();
            }

            Console.Write(writer);
            writer.Clear();
        }

    }
}
