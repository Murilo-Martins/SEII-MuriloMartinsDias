//Recriei a pasta, fiz isso pq nao sei se fica pesado, mas o codigo ta ai
using System.Text;
int[] myArray = new int[1];
string[] myStringArray = new string[10];
myStringArray[0] ="Monday";
myStringArray[1] ="Mday";
myStringArray[2] ="Mon";
myStringArray[3] ="Ms";
myStringArray[4] ="Monday";
Console.WriteLine(myStringArray[0]);
foreach(var palavra in myStringArray){
    Console.WriteLine(palavra);
}

List<string> list = new List<string>();
list.Add("Monday");
list.Add("Mday");
list.Add("Mon");
list.Add("Mste");
list.Add("Monday");

for (int i = 0; i < list.Count; i++)
{
    list[i] = list[i].Substring(0,3);
    Console.WriteLine(list[i]);
}
//Só para subir pasta certa

Dictionary<int, string> dictionary = new Dictionary<int, string>();
dictionary[0] ="Monday";
dictionary[1] ="Mday";
dictionary[2] ="Mon";
dictionary[3] ="Mst";
dictionary[4] ="Monday";
dictionary.Add(5, "Outro dia");

for (int i = 0; i < dictionary.Count; i++)
{
    dictionary[i] = dictionary[i].Substring(0,3);
    Console.WriteLine(dictionary[i]);
}
