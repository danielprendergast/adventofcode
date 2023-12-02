int iMaxRed = 12;
int iMaxGreen = 13;
int iMaxBlue = 14;

string[] strInputArray = File.ReadAllLines("input.txt");

int iPossibleGameSum = 0;

// could just check whole array for values of red/green/blue larger than max, but building loop logic in prep for part 2
foreach (string strInput in strInputArray)
{
    bool bGameFailed = false;

    string strCurrentGame = strInput.Substring(0, strInput.IndexOf(':')).Replace("Game", "").Trim();
    string strGameContents = strInput.Substring(strInput.IndexOf(":"), strInput.Length - strInput.LastIndexOf(":"));
    strGameContents = strGameContents.Replace(":", "");

    string[] strRounds = strGameContents.Split(';');
    foreach (string strRound in strRounds)
    {
        string[] strColours = strRound.Replace(";", "").Split(',');

        foreach (string strColour in strColours)
        {
            string[] strColourversusquantity = strColour.Substring(1, strColour.Length - 1).Split(" ");

            if (strColourversusquantity[1] == "red")
            {
                if (int.Parse(strColourversusquantity[0]) > iMaxRed)
                {
                    bGameFailed = true;
                }
            }
            if (strColourversusquantity[1] == "blue")
            {
                if (int.Parse(strColourversusquantity[0]) > iMaxBlue)
                {
                    bGameFailed = true;
                }
            }
            if (strColourversusquantity[1] == "green")
            {
                if (int.Parse(strColourversusquantity[0]) > iMaxGreen)
                {
                    bGameFailed = true;
                }
            }
        }
    }
    if (bGameFailed)
    {
        Console.WriteLine("Game " + strCurrentGame + " failed");
    }
    else
    {
        iPossibleGameSum = iPossibleGameSum + int.Parse(strCurrentGame);
    }
    Console.WriteLine("Total Game Value Passed: " + iPossibleGameSum.ToString());
}