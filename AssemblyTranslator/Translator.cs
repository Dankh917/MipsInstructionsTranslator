using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyTranslator
{
	static class Translator
	{

		static public string Translate(Type type, string mipsFunction, string rd,string rs, string rt, string shAmt="00000",string op="000000")
		{
			bool allExist = new[] { rd, rs, rt }.All(k => mipsRegisters.ContainsKey(k)) && Functions.ContainsKey(mipsFunction);
			//Check passed values
			if (!allExist)
			{
				return "INVALID params rd,ts,rt OR INVALID mipsFunction";
			}
			
			if(type == Type.R)
			{
				string result;
				op = "000000";
				result = op + mipsRegisters.GetValueOrDefault(rs) + mipsRegisters.GetValueOrDefault(rt) + mipsRegisters.GetValueOrDefault(rd) 
					+ shAmt + Functions.GetValueOrDefault(mipsFunction);


				uint toConvert = Convert.ToUInt32(result, 2);
				string addOn16Base = toConvert.ToString("X8");


				result = "Binary val: "+result + "\nHex val: " + addOn16Base;


				return result;
			}
			else
			{
				return "fail";
			} 
			//else here
		}
		
		static Dictionary<string, string> mipsRegisters = new Dictionary<string, string>
		{
			["$zero"] = Convert.ToString(0, 2).PadLeft(5, '0'),
			["$at"] = Convert.ToString(1, 2).PadLeft(5, '0'),
			["$v0"] = Convert.ToString(2, 2).PadLeft(5, '0'),
			["$v1"] = Convert.ToString(3, 2).PadLeft(5, '0'),
			["$a0"] = Convert.ToString(4, 2).PadLeft(5, '0'),
			["$a1"] = Convert.ToString(5, 2).PadLeft(5, '0'),
			["$a2"] = Convert.ToString(6, 2).PadLeft(5, '0'),
			["$a3"] = Convert.ToString(7, 2).PadLeft(5, '0'),
			["$t0"] = Convert.ToString(8, 2).PadLeft(5, '0'),
			["$t1"] = Convert.ToString(9, 2).PadLeft(5, '0'),
			["$t2"] = Convert.ToString(10, 2).PadLeft(5, '0'),
			["$t3"] = Convert.ToString(11, 2).PadLeft(5, '0'),
			["$t4"] = Convert.ToString(12, 2).PadLeft(5, '0'),
			["$t5"] = Convert.ToString(13, 2).PadLeft(5, '0'),
			["$t6"] = Convert.ToString(14, 2).PadLeft(5, '0'),
			["$t7"] = Convert.ToString(15, 2).PadLeft(5, '0'),
			["$s0"] = Convert.ToString(16, 2).PadLeft(5, '0'),
			["$s1"] = Convert.ToString(17, 2).PadLeft(5, '0'),
			["$s2"] = Convert.ToString(18, 2).PadLeft(5, '0'),
			["$s3"] = Convert.ToString(19, 2).PadLeft(5, '0'),
			["$s4"] = Convert.ToString(20, 2).PadLeft(5, '0'),
			["$s5"] = Convert.ToString(21, 2).PadLeft(5, '0'),
			["$s6"] = Convert.ToString(22, 2).PadLeft(5, '0'),
			["$s7"] = Convert.ToString(23, 2).PadLeft(5, '0'),
			["$t8"] = Convert.ToString(24, 2).PadLeft(5, '0'),
			["$t9"] = Convert.ToString(25, 2).PadLeft(5, '0'),
			["$k0"] = Convert.ToString(26, 2).PadLeft(5, '0'),
			["$k1"] = Convert.ToString(27, 2).PadLeft(5, '0'),
			["$gp"] = Convert.ToString(28, 2).PadLeft(5, '0'),
			["$sp"] = Convert.ToString(29, 2).PadLeft(5, '0'),
			["$fp"] = Convert.ToString(30, 2).PadLeft(5, '0'),
			["$ra"] = Convert.ToString(31, 2).PadLeft(5, '0')
		};
		
		static Dictionary<string, string> Functions = new Dictionary<string, string>
		{
			// ArithLog and ArithLogI
			["add"] = "100000",
			["addu"] = "100001",
			["addi"] = "001000",
			["addiu"] = "001001",
			["and"] = "100100",
			["andi"] = "001100",
			["nor"] = "100111",
			["or"] = "100101",
			["ori"] = "001101",
			["slt"] = "101010",
			["sltu"] = "101001",
			["slti"] = "001010",
			["sltiu"] = "001001",
			["sub"] = "100010",
			["subu"] = "100011",
			["xor"] = "100110",
			["xori"] = "001110",

			// DivMult
			["div"] = "011010",
			["divu"] = "011011",
			["mult"] = "011000",
			["multu"] = "011001",

			// Shift and ShiftV
			["sll"] = "000000",
			["sllv"] = "000100",
			["sra"] = "000011",
			["srav"] = "000111",
			["srl"] = "000010",
			["srlv"] = "000110",

			// LoadI
			["lhi"] = "011001",
			["llo"] = "011000",

			// Branch and BranchZ
			["beq"] = "000100",
			["bgtz"] = "000111",
			["blez"] = "000110",
			["bne"] = "000101",

			// Jump and JumpR
			["j"] = "000010",
			["jal"] = "000011",
			["jalr"] = "001001",
			["jr"] = "001000",

			// LoadStore
			["lb"] = "100000",
			["lbu"] = "100100",
			["lh"] = "100001",
			["lhu"] = "100101",
			["lw"] = "100011",
			["sb"] = "101000",
			["sh"] = "101001",
			["sw"] = "101011",

			// MoveFrom
			["mfhi"] = "010000",
			["mflo"] = "010010",

			// MoveTo
			["mthi"] = "010001",
			["mtlo"] = "010011",

			// Trap
			["trap"] = "011010"
		};




	}


}

enum Type
{
	R,
	I
}

