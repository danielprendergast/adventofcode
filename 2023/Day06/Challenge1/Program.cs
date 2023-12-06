using System.Text.RegularExpressions;

string[] strInput = File.ReadAllLines("input.txt");

string strNumberPattern = @"([0-9])+";
Regex rExp = new Regex(strNumberPattern);

MatchCollection matchTimes = rExp.Matches(strInput[0].ToString());
MatchCollection matchDistances = rExp.Matches(strInput[1].ToString());

var listPairs = new List<Tuple<int, int>>();

int iLoop = 0;
foreach (Match match in matchTimes)
{
    listPairs.Add(new Tuple<int, int>(int.Parse(match.Value), int.Parse(matchDistances[iLoop].Value)));
    iLoop++;
}
Console.WriteLine("");

int iTotal = 0;

foreach (Tuple<int, int> tuplePair in listPairs)
{
    int iSuccess = 0;
    int iTime = tuplePair.Item1;
    int iDistance = tuplePair.Item2;

    for (int i = 0; i < iTime; i++)
    {
        int iSpeed = i;
        int iCalculatedDistance = iSpeed * (iTime-iSpeed);

        if(iCalculatedDistance > iDistance)
        {
            iSuccess++;
        }
    }

    if (iTotal == 0)
    {
        iTotal = iSuccess;
    }
    else
    {
        iTotal = iTotal * iSuccess;
    }
    
}
Console.WriteLine(iTotal.ToString());