int iMaxRed = 12;
int iMaxGreen = 13;
int iMaxBlue = 14;

int iTotalPower = 0;

string[] strInputArray = File.ReadAllLines("input.txt");

int iPossibleGameSum = 0;

foreach (string strInput in strInputArray)
{

    int iMinRed = 0;
    int iMinGreen = 0;
    int iMinBlue = 0;

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
                if (iMinRed == 0)
                {
                    iMinRed = int.Parse(strColourversusquantity[0]);
                }
                if (iMinRed < int.Parse(strColourversusquantity[0]))
                {
                    iMinRed = int.Parse(strColourversusquantity[0]);
                }
            }
            if (strColourversusquantity[1] == "blue")
            {
                if (iMinBlue == 0)
                {
                    iMinBlue = int.Parse(strColourversusquantity[0]);
                }
                if (iMinBlue < int.Parse(strColourversusquantity[0]))
                {
                    iMinBlue = int.Parse(strColourversusquantity[0]);
                }
            }
            if (strColourversusquantity[1] == "green")
            {
                if (iMinGreen == 0)
                {
                    iMinGreen = int.Parse(strColourversusquantity[0]);
                }
                if (iMinGreen < int.Parse(strColourversusquantity[0]))
                {
                    iMinGreen = int.Parse(strColourversusquantity[0]);
                }
            }
        }
    }
    int iGamePower = iMinRed * iMinBlue * iMinGreen;
    iTotalPower = iTotalPower + iGamePower;
}

Console.WriteLine("Total Power: " + iTotalPower.ToString());