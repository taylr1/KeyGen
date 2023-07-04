// See https://aka.ms/new-console-template for more information

using System.ComponentModel;
using KeyGen.Common;
using KeyGen.Common.Enum;
using KeyGen.Common.Records;

Console.WriteLine("Please specify which algorithm you would like to use: ");

foreach (var a in Enum.GetNames(typeof(Algorithm)))
{
    Console.WriteLine(a);
}

Algorithm? selectedAlg = null;
bool canContinue = false;

while (!canContinue)
{
    try
    {
        var userInput = Console.ReadLine();

        if (!Enum.TryParse(userInput, true, out Algorithm alg))
            throw new InvalidEnumArgumentException();
        
        canContinue = true;
        selectedAlg = alg;
    }
    catch (InvalidEnumArgumentException ex)
    {
        var values = string.Join(',', Enum.GetNames<Algorithm>());
        Console.WriteLine($"Unexpected value provided, please try again. Acceptable values are: {values} ");
    }
}

switch (selectedAlg)
{
    case Algorithm.Rsa:
        var aService = Factory.CreateKeyService<AsymmetricalKeyValue>();
        var keys = aService.CreateKeys();
        aService.OutputKeys(keys);
        break;
    case Algorithm.Aes:
        var sService = Factory.CreateKeyService<SymmetricalKeyValue>();
        var sKeys = sService.CreateKeys();
        sService.OutputKeys(sKeys);
        break;
    default:
        throw new InvalidEnumArgumentException("Invalid algorithm enum type provided.");
}

