namespace AssemblyTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string outPut = Translator.Translate(Type.R, "add", "$t0", "$s1", "$s2");
            //string outPut2 = Translator.TranslateR( "sub", "$t0", "$s1", "$t4");
            //string outPut = Translator.TranslateI( "addi", "$s0", "$s1", "5");
            string outPut = Translator.TranslateI( "lw", "$t2", "$0", "32");
            //Console.WriteLine(outPut2);
            //Console.WriteLine(outPut);
            Console.WriteLine(outPut);
        }
    }
}
