namespace AssemblyTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string outPut = Translator.Translate(Type.R, "add", "$t0", "$s1", "$s2");
            string outPut2 = Translator.TranslateR(Type.R, "sub", "$t0", "$s1", "$t4");
            string outPut = Translator.TranslateI(Type.I, "addi", "$s0", "$s1", "5");
            Console.WriteLine(outPut2);
            Console.WriteLine(outPut);
        }
    }
}
