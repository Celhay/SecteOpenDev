using RefactoBase.Models;
using RefactoBase.Utils;

namespace RefactoBase.Core;

public class MenuManager
{ 
    public static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
        Console.WriteLine(" 1. List all of our current pet information");
        Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
        Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
        Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
        Console.WriteLine(" 5. Edit an animal’s age");
        Console.WriteLine(" 6. Edit an animal’s personality description");
        Console.WriteLine(" 7. Display all cats with a specified characteristic");
        Console.WriteLine(" 8. Display all dogs with a specified characteristic");
        Console.WriteLine(" --");
    }

    public static int? GetUserMenuSelection()
    {
        Console.WriteLine();
        Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
        var userInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(userInput))
        {
            return null;
        }

        if (userInput.ToLower() == "exit")
        {
            return 0;
        }

        if (int.TryParse(userInput, out var userSelection) && userSelection is >= 1 and <= 8)
        {
            return userSelection;
        }

        return null;
    }

    public static void DoMenuAction(Actions selectedAction, IEnumerable<Animal> animals)
    {
        switch (selectedAction)
        {
            case Actions.ListAllOfOurCurrentPetInformation:
                animals.ListAllPetInfo();
                break;
            case Actions.AddANewAnimalFriendToTheOurAnimalsArray:
                animals.AddNewAnimal();
                break;
            case Actions.EnsureAnimalAgesAndPhysicalDescriptionsAreComplete:
                animals.CompleteAgesAndPhysicalDescriptions();
                break;
            case Actions.EnsureAnimalNicknamesAndPersonalityDescriptionsAreComplete:
                animals.CompleteNicknamesAndPersonalityDescriptions();
                break;
            case Actions.EditAnAnimalAge:
                Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                break;
            case Actions.EditAnAnimalPersonalityDescription:
                Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                break;
            case Actions.DisplayAllCatsWithASpecifiedCharacteristic:
                Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
                break;
            case Actions.DisplayAllDogsWithASpecifiedCharacteristic:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(selectedAction), selectedAction, null);
        }
    }
}