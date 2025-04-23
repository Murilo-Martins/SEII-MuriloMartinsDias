
namespace factoryPatternexample
{
	public class SamsungPhone : IMobile
	{
		public string GetCPU()
		{
			return "Samsung CPU";
		}

		public string GetRAM()
		{
			return "16GB";
		}

	}
}
