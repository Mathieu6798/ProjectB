class KeyBoardLogic
{
    private int SelectedIndex;
    private string[] Options;
    private string Prompt;

    public KeyBoardLogic(string prompt, string[] options)
    {
        this.Prompt = prompt;
        this.Options = options;
        this.SelectedIndex = 0;
    }
    private void DisplayOptions()
    {
        Console.WriteLine(Prompt);
        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];
            string prefix;
            if (i == SelectedIndex)
            {
                prefix = "*";
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                prefix = " ";
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"{prefix} {currentOption}");
        }
        Console.ResetColor();
    }
    public int Run()
    {
        ConsoleKey keyPressed;
        do
        {
            Console.Clear();
            DisplayOptions();

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            keyPressed = keyInfo.Key;
            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex == -1)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }
            else if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex == Options.Length)
                {
                    SelectedIndex = 0;
                }
            }

        } while (keyPressed != ConsoleKey.Enter);
        return SelectedIndex;
    }
}