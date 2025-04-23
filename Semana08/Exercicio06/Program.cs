// See https://aka.ms/new-console-template for more information
using factoryPatternexample;

string PhoneType = "Apple";

IMobile mobile = MobileFactory.GetPhoneObj(PhoneType);
/*switch (PhoneType)*/
/*{*/
/*	case "Apple":*/
/*		mobile = new ApplePhone();*/
/*		break;*/
/*	case "Samsung":*/
/*		mobile = new SamsungPhone();*/
/*		break;*/
/*	default :*/
/*		break;*/
/*}*/

Console.WriteLine("CPU: "+mobile.GetCPU());
Console.WriteLine("RAM: "+mobile.GetRAM());

Console.ReadLine();
