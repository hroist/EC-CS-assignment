
using ConsoleApp.Services;

var mainMenu = new MainMenuService();

bool ProgramIsRunning = true;

while (ProgramIsRunning)
{
    Console.Clear();
    mainMenu.WelcomeMenu();
}
