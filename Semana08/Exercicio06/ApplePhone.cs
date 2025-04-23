namespace factoryPatternexample
{
	public class ApplePhone : IMobile
	{
		public string GetCPU()
		{
			return "Apple CPU";
		}

		public string GetRAM()
		{
			return "8GB";
		}

	}
}
