using System.Reflection.PortableExecutable;

string[] strInput = File.ReadAllLines("input.txt");

string strInstructions = strInput[0];

//back to tuples
//root, left, right
var listPairs = new List<Tuple<string, string, string>>();

strInput = strInput.Skip(2).ToArray();
foreach (string strLine in strInput)
{
    listPairs.Add(new Tuple<string, string, string>(strLine.Substring(0,3),strLine.Substring(7,3), strLine.Substring(12, 3)));
}

int iCurrentLine = 0;
iCurrentLine = listPairs.IndexOf(listPairs.Find(x => x.Item1 == "AAA"));

int iSteps = 0;
string strCurrentRoot = null;

while(strCurrentRoot != "ZZZ")
{
    foreach (char c in strInstructions)
    {
        string strLeft = listPairs[iCurrentLine].Item2;
        string strRight = listPairs[iCurrentLine].Item3;
        if (c == 'R')
        { 
            strCurrentRoot = listPairs.Find(x => x.Item1 == strRight).Item1;
            iCurrentLine = listPairs.IndexOf(listPairs.Find(x => x.Item1 == strRight));
            iSteps++;
        }
        if (c == 'L')
        {
            strCurrentRoot = listPairs.Find(x => x.Item1 == strLeft).Item1;
            iCurrentLine = listPairs.IndexOf(listPairs.Find(x => x.Item1 == strLeft));
            iSteps++;
        }
    }
}



Console.WriteLine(iSteps++);