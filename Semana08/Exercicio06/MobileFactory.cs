namespace factoryPatternexample
{
	public class MobileFactory
	{
		public static IMobile GetPhoneObj(string PhoneType)
		{
			IMobile mobile = null;
			switch (PhoneType)
			{
				case "Apple":
					mobile = new ApplePhone();
					break;
				case "Samsung":
					mobile = new SamsungPhone();
					break;
				default :
					break;
			}
			return mobile;
		}
		
	}
}
