using RefactoBase;
using RefactoBase.Core;
using RefactoBase.Models;
using RefactoBase.Utils;



// array used to store runtime data
var ourAnimals = new List<Animal>();

// sample data ourAnimals array entries
var sampleDataProvider = new SampleDataProvider();
var sampleData = sampleDataProvider.GetSampleData();
ourAnimals.AddRange(sampleData);


int? menuSelection;
do
{
    MenuManager.DisplayMenu();
    
    menuSelection = MenuManager.GetUserMenuSelection();

    switch (menuSelection)
    {
        case 0:
            Console.WriteLine("Good bye !");
            break;
        case > 0 and <= 8:
            MenuManager.DoMenuAction((Actions)menuSelection, ourAnimals);
            break;
        default:
            Console.WriteLine("Your entry is incorrect ! ");
            break;
    }

    WaitUserToContinue();
    
} 
while (menuSelection != 0);

void WaitUserToContinue()
{
    Console.WriteLine();
    Console.WriteLine("Press the Enter key to continue");
    Console.ReadLine();
}
