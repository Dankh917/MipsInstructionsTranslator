namespace AssemblyTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string outPut = Translator.Translate(Type.R, "add", "$t0", "$s1", "$s2");
            Console.WriteLine(outPut);
        }
    }
}
