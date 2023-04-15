using System;
namespace TestFrazioni
{
	class Program
	{
		static void Main(string[] args)
		{
			CHugeNumber prova = new CHugeNumber("235421132");
			for(int i=prova.cifre.Length-1; i>0; i=i-1)
			{
				Console.Write(prova.cifre[i]);
			}
		}
	}
}