using System;
using System.Reflection.PortableExecutable;
using System.Linq;

string[] strInput = File.ReadAllLines("input.txt");

string strInstructions = strInput[0];

//back to tuples
//root, left, right
var listPairs = new List<Tuple<string, string, string>>();

strInput = strInput.Skip(2).ToArray();
foreach (string strLine in strInput)
{
    listPairs.Add(new Tuple<string, string, string>(strLine.Substring(0, 3), strLine.Substring(7, 3), strLine.Substring(12, 3)));
}

// startline, root, left, right, root (for origin)
var listCurrentLines = new List<Tuple<int, string, string, string, string>>();
foreach (var pair in listPairs)
{
    if (pair.Item1.Substring(2, 1) == "A")
    {
        listCurrentLines.Add(new Tuple<int, string, string, string, string>(listPairs.IndexOf(pair), pair.Item1, pair.Item2, pair.Item3, pair.Item1));
    }
}



int iCharPositionLength = strInstructions.Length;


List<long> listValidZValues = new List<long>();


foreach (var pair in listCurrentLines.ToList())
{
    bool bCompleted = false;
    int iCharPosition = 0;
    int iSteps = 0;
    var index = listCurrentLines.ToList().IndexOf(pair);
    char c = strInstructions[iCharPosition];
    while (!bCompleted)
    {
        iSteps++;
        int iCurrentLine = listCurrentLines[index].Item1;
        string strLeft = listCurrentLines[index].Item3;
        string strRight = listCurrentLines[index].Item4;
        string strNewRoot = "";
        string strNewLeft = "";
        string strNewRight = "";
        c = strInstructions[iCharPosition];

        if (c == 'R')
        {
            iCurrentLine = listPairs.IndexOf(listPairs.Find(x => x.Item1 == strRight));

            //var index = listCurrentLines.ToList().IndexOf(pair);
            strNewRoot = listPairs.Find(x => x.Item1 == strRight).Item1;
            strNewLeft = listPairs.Find(x => x.Item1 == strRight).Item2;
            strNewRight = listPairs.Find(x => x.Item1 == strRight).Item3;
            listCurrentLines[index] = Tuple.Create(iCurrentLine, strNewRoot, strNewLeft, strNewRight, pair.Item5);
        }
        if (c == 'L')
        {
            iCurrentLine = listPairs.IndexOf(listPairs.Find(x => x.Item1 == strLeft));

            //var index = listCurrentLines.ToList().IndexOf(pair);
            strNewRoot = listPairs.Find(x => x.Item1 == strLeft).Item1;
            strNewLeft = listPairs.Find(x => x.Item1 == strLeft).Item2;
            strNewRight = listPairs.Find(x => x.Item1 == strLeft).Item3;
            listCurrentLines[index] = Tuple.Create(iCurrentLine, strNewRoot, strNewLeft, strNewRight, pair.Item5);
        }

        if (listCurrentLines[index].Item2.Substring(2, 1) != "Z")
        {
            bCompleted = false;
        }
        else
        {
            listValidZValues.Add(iSteps);
            bCompleted = true;
        }
        iCharPosition++;
        if (iCharPosition >= iCharPositionLength)
        {
            iCharPosition = 0;
        }
    }
}



List<long> listValidZValuesCopy = listValidZValues;
while (!(listValidZValues.ToList().Distinct().Count() == 1))
{
    int iIndex = 0;
    List<long> listTempValidZValues = new List<long>();
    foreach (long iValue in listValidZValues.ToList())
    {
        long iNewValue = iValue;
        if (iValue == listValidZValues.Min() && !(listValidZValues.ToList().Distinct().Count() == 1))
        {
            iNewValue = iValue + listValidZValuesCopy[iIndex];
        }
        else
        {
            if (!(listValidZValues.ToList().Distinct().Count() == 1))
            {
                iNewValue = iValue;
            }
        }
        listTempValidZValues.Add(iNewValue);
        iIndex++;
    }
    listValidZValues = listTempValidZValues;

}


Console.Write(listValidZValues[0].ToString());