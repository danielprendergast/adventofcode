using System.Text.RegularExpressions;

string[] strInputArray = File.ReadAllLines("input.txt");

int iTotal = 0;



foreach (string strInputLine in strInputArray)
{
    int iMatchValue = 0;
    int iMatches = 0;

    string strCards = strInputLine.Split(':')[1];

    string[] strCardsArray = strCards.Split('|');

    // Get all numeric instances
    string strNumberPattern = @"([0-9])+";
    Regex rExp = new Regex(strNumberPattern);

    MatchCollection matchedWinningNumbers = rExp.Matches(strCardsArray[0]);
    MatchCollection matchedMyNumbers = rExp.Matches(strCardsArray[1]);

    foreach (Match matchWinner in matchedWinningNumbers)
    {
        foreach (Match matchMine in matchedMyNumbers)
        {
            if (matchWinner.ToString() == matchMine.ToString())
            {
                if (iMatchValue == 0)
                {
                    iMatchValue = 1;
                    iMatches++;
                }
                else
                {
                    iMatchValue = iMatchValue * 2;
                    iMatches++;
                }
            }
        }
    }

    iTotal = iTotal + iMatchValue;

    Console.WriteLine("Line: " + strInputLine + " Increment: " + iMatchValue.ToString());
    Console.WriteLine("Matches: " + iMatches.ToString());

}
Console.WriteLine(iTotal.ToString());
Console.ReadKey();
