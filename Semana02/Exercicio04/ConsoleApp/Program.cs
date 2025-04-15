using System.Text;
using ConsoleApp;

// See https://aka.ms/new-console-template for more information
//if para não rodar atoa, fica feio tudo comentado
if(false){
    //video 1 ---------------------------------------------
    Console.WriteLine("Hello, World!");

    //dotnet watch run - rodar e captar mudanças

    //Video 2 ---------------------------------------------
    Console.WriteLine("Praise the great leader... Frida Kahlo");
    string Frida = "Frida Kahlo";
    var fridaMalOtimizado = "Frida Kahlo, mal otimizada";
    Console.WriteLine(Frida);
    Console.WriteLine(fridaMalOtimizado);


    //Video 3 ---------------------------------------------
    string name = "teddy";
    long  jeffBezosNetworth = 196000000000;
    var charchar =  'c';// não funciona com ""
    Console.WriteLine(charchar);
    Console.WriteLine(name);
    Console.WriteLine(jeffBezosNetworth);


    //Video 4 ---------------------------------------------
    //Create Read Update Delete 
    //Por algum motivo que não entendi o trem não altera array ele cria um novo wtf??
    //CRUD
    string tubarao = "tubarao espada";
    //Concatena
    tubarao = "porcupine" + tubarao;
    Console.WriteLine($"I am buying {tubarao}, you cannot stop me!!");
    Console.WriteLine(tubarao);

    //Read

    //UPDATE
    string newtubarao = tubarao.Replace("porcupine", "Tambaqui ");
    Console.WriteLine(newtubarao);

    //DELETE 
    //String Builder
    StringBuilder newCrustacean = new StringBuilder();
    newCrustacean.Append("fiddler crab");
    Console.WriteLine(newCrustacean);
    newCrustacean.Remove(0,8);//Deleta da posição que você deseja a quantidade de caracteres que deseja
    Console.WriteLine(newCrustacean);


    //Video 5 ---------------------------------------------
    //ARRAY CRUD

    //CREATE
    string[] favoriteRats = ["fancy rat", "brown rat", "radioactive rat", "wolf rat"];

    //Read
    //Console.WriteLine(favoriteRats); não da certo :/
    foreach(var rat in favoriteRats){
        Console.WriteLine(rat);
    }

    //Update
    //favoriteRats[0] = "Fancy Rat";
    var newFavoriteRats = favoriteRats.Where((e) => e.StartsWith("b"));
    foreach(var rat in newFavoriteRats){
        Console.WriteLine(rat);
    }

    //Delete
    //Nao deleta kkkk

    //Video 6 ---------------------------------------------
    //Counter
    for(var i = 1; i <= 10; i ++)
    {
        Console.WriteLine(i);
    }
    string[] bandasMetalFavoritas = ["Guns", "System", "Aerosmith"];
    for(var i = 0; i < bandasMetalFavoritas.Length; i ++)
    {
        Console.WriteLine(bandasMetalFavoritas[i]);
    }
    foreach(var banda in bandasMetalFavoritas){
        Console.WriteLine(banda);
    }
    bandasMetalFavoritas.ToList().ForEach((i)=> {
        Console.WriteLine("ForEach: " + i );
    });
    Array.ForEach(bandasMetalFavoritas, e=> Console.WriteLine("Array.Foreach: " + e));

    //Video 7 ---------------------------------------------
    var aquario = "Gato";
    if((aquario =="Peixe") ||(aquario =="Gato")){
        Console.WriteLine("Quero comprar um " + aquario);
    }
    else{
        Console.WriteLine("Quero comprar nada não");
    }
    string aquarioPreco = "1000";
    if(aquarioPreco is string){
        Console.WriteLine("String");
    }
    else{
        Console.WriteLine("Não string");
    }

    //Video 8 --------------------------------------------- 
    
    var status = Warning.CodeBlue;
    if(status == Warning.CodeBlue){
        Console.WriteLine(status);
    }
    
    //Video 9 ---------------------------------------------
    var preHistoricFish = "plesiossauro";
    switch(preHistoricFish){
        case "Heliobastis":
            Console.WriteLine("Heliobatis");
            break;
        case "plesiossauro":
            Console.WriteLine(preHistoricFish+ "!");
            break;
        default:
            Console.WriteLine("Nenhum");
            break;
    }

    var result = preHistoricFish switch
    {
        "Heliobatis" => "Heliobastis",
        "plesiossauro" => "plesiossauro",
        _ => "No match!"
    };
    Console.WriteLine("Escolhido " + result);
    //Video 10 ---------------------------------------------
    //Vou fazer esse não é um while funciona igual

    //Video 11 ---------------------------------------------
    //CRUD
    Rat wolfRat = new Rat();
    wolfRat.Name = "Wolf Rat";
    wolfRat.Number = 1000;
    wolfRat.IsRadioactive = true;

    Rat fancyRat = new Rat();
    wolfRat.Name = "Fancy Rat";
    wolfRat.Number = 500;
    wolfRat.IsRadioactive = true;

    //Read
    Console.WriteLine(wolfRat.Name);
    Console.WriteLine(fancyRat.Name);

    //Update
    wolfRat.Name="Wold";

    //Video 12 ---------------------------------------------
    RealEstate elmStreet = new(){
        Address = "Elm Street",
        SquareFootage =1300,
        Price = 30000
    };
    Console.WriteLine(elmStreet.CalculatePricePerSquareFoot());

    //Video 13 ---------------------------------------------
    var values = ("t", 2,"p");
    Console.WriteLine(values.Item1);
    Console.WriteLine(values.Item2);
    Console.WriteLine(values.Item3);
    var tubo = (primeiro: "t", segundo: 2);

    (int a, string b, bool c) ReturnValues(){
        return (9,"u", true);
    }

    var tupleReturnValue = ReturnValues();
    Console.WriteLine(tupleReturnValue);
    

}




enum Warning{
    CodeRed,
    CodeBlue,
    CodeYellow
}



