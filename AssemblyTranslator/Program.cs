namespace AssemblyTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //example for R type mips function
            string outPut1 = Translator.TranslateR("sub", "$t0", "$t3", "$t5");
			Console.WriteLine(outPut1);

			//example for I type mips function with immidiate val
			string outPut2 = Translator.TranslateI("addi", "$s0", "$s1", "5");
			Console.WriteLine(outPut2);

			////example for I type mips function with the sw or lw memory and offset
			string outPut3 = Translator.TranslateI("lw", "$t2", "$0", "32");
			Console.WriteLine(outPut3);
		
        }
    }
}
