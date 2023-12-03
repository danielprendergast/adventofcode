using System.Collections.Generic;
using System.Text.RegularExpressions;

string[] strInputArray = File.ReadAllLines("input.txt");

string[] strSymbolArray = File.ReadAllLines("symbols.txt");

//Get Length of each row

int iRowLength = strInputArray[0].Length;
int iCurrentRow = 0;
var listIndexes = new List<Tuple<int, int, int, int>>();
int iTotalValue = 0;

// Get a list of all instances of the symbols in the text per line
foreach (string strInputLine in strInputArray)
{
    foreach (string strSymbol in strSymbolArray)
    {
        for (int i = 0; i < strInputLine.Length; i++)
        {
            if (strInputLine[i] == strSymbol.ToCharArray()[0])
            {
                listIndexes.Add(new Tuple<int, int, int, int>(iCurrentRow, (i), 0, 1));
            }
        }
    }
    iCurrentRow++;
}

iCurrentRow = 0;

foreach (string strInputLine in strInputArray)
{
    // Get all numeric instances
    string strNumberPattern = @"([0-9])+";
    Regex rExp = new Regex(strNumberPattern);

    MatchCollection matchedNumbers = rExp.Matches(strInputLine);

    foreach (Match match in matchedNumbers)
    {
        int iNumberLength = match.ToString().Length;
        int iPosition = match.Index;


        bool bNearSymbol = false;

        for (int i = 0; i < iNumberLength; i++)
        {
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow && s.Item2 == iPosition - 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow && s.Item2 == iPosition - 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow && s.Item2 == iPosition - 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow, iPosition - 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow && s.Item2 == iPosition + 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow && s.Item2 == iPosition + 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow && s.Item2 == iPosition + 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow, iPosition + 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + i);
                listIndexes[index] = Tuple.Create(iCurrentRow + 1, iPosition + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition + 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow + 1, iPosition + 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition - 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition - 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow + 1 && s.Item2 == iPosition - 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow + 1, iPosition - 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + i);
                listIndexes[index] = Tuple.Create(iCurrentRow - 1, iPosition + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition + 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow - 1, iPosition + 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
            if (!bNearSymbol && listIndexes.Contains(listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition - 1 + i)))
            {
                bNearSymbol = true;
                var index = listIndexes.FindIndex(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition - 1 + i);
                var tuple = listIndexes.Find(s => s.Item1 == iCurrentRow - 1 && s.Item2 == iPosition - 1 + i);
                listIndexes[index] = Tuple.Create(iCurrentRow - 1, iPosition - 1 + i, tuple.Item3 + 1, tuple.Item4 * int.Parse(match.ToString()));
            }
        }
    }
    iCurrentRow++;
}

var validTuples = listIndexes.FindAll(s => s.Item3 == 2);


foreach (var tuple in validTuples)
{
    iTotalValue += int.Parse(tuple.Item4.ToString());
}

Console.WriteLine(iTotalValue.ToString());