// If the challenge is to waste the most cpu cycles - i win hands down

using System.Text.RegularExpressions;

string[] strInputArray = File.ReadAllLines("input.txt");

int iTotal = 0;
int iMatchesTotal = 0;

int iOneAhead = 0;
int iTwoAhead = 0;
int iThreeAhead = 0;
int iFourAhead = 0;
int iFiveAhead = 0;
int iSixAhead = 0;
int iSevenAhead = 0;
int iEightAhead = 0;
int iNineAhead = 0;
int iTenAhead = 0;
int iElevenAhead = 0;
int iTwelveAhead = 0;

foreach (string strInputLine in strInputArray)
{
    int iMatchValue = 0;
    int iMatches = 0;
    iMatchesTotal++;

    string strCards = strInputLine.Split(':')[1];

    string[] strCardsArray = strCards.Split('|');

    // Get all numeric instances
    string strNumberPattern = @"([0-9])+";
    Regex rExp = new Regex(strNumberPattern);

    MatchCollection matchedWinningNumbers = rExp.Matches(strCardsArray[0]);
    MatchCollection matchedMyNumbers = rExp.Matches(strCardsArray[1]);

   
    int iTimesToRun = iOneAhead + 1;
    Console.WriteLine("Running Times: " + iTimesToRun.ToString());
    for (int i = 0; i < iTimesToRun; i++)
    {
        iMatches = 0;
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
                        iMatchesTotal++;
                    }
                    else
                    {
                        //iMatchValue = iMatchValue * 2;
                        iMatches++;
                        iMatchesTotal++;
                    }
                }
            }
        }



        if (iMatches >= 1)
        {
            iTwoAhead++;
        }
        if (iMatches >= 2)
        {
            iThreeAhead++;
        }
        if (iMatches >= 3)
        {
            iFourAhead++;
        }
        if (iMatches >= 4)
        {
            iFiveAhead++;
        }
        if (iMatches >= 5)
        {
            iSixAhead++;
        }
        if (iMatches >= 6)
        {
            iSevenAhead++;
        }
        if (iMatches >= 7)
        {
            iEightAhead++;
        }
        if (iMatches >= 8)
        {
            iNineAhead++;
        }
        if (iMatches >= 9)
        {
            iTenAhead++;
        }
        if (iMatches >= 10)
        {
            iElevenAhead++;
        }
    }


    Console.WriteLine("Line: " + strInputLine);
    Console.WriteLine("Matches: " + iMatches.ToString());

    iOneAhead = iTwoAhead;
    iTwoAhead = iThreeAhead;
    iThreeAhead = iFourAhead;
    iFourAhead = iFiveAhead;
    iFiveAhead = iSixAhead;
    iSixAhead = iSevenAhead;
    iSevenAhead = iEightAhead;
    iEightAhead = iNineAhead;
    iNineAhead = iTenAhead;
    iTenAhead = iElevenAhead;
    iElevenAhead = iTwelveAhead;

}
Console.WriteLine(iMatchesTotal.ToString());
Console.ReadKey();
