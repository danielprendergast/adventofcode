using System.Diagnostics;
using System.Numerics;

string[] strInput = File.ReadAllLines("input.txt");

int iTotal = 0;

foreach (string strInputLine in strInput)
{
    List<int> listNumbers = new List<int>();
    string[] strNumbers = strInputLine.Split(" ");
    foreach (string strNumber in strNumbers)
    {
        listNumbers.Add(int.Parse(strNumber));
    }
    Console.WriteLine();
    Console.WriteLine();
    bool bCompleted = false;
    int iToAdd = 0;
    while (!bCompleted)
    {
        int iFirstLoop = 1;
        int iPreviousNumber = 0;
        int iCurrentIndex = 0;
        List<int> listNextNumbers = new List<int>();
        Console.WriteLine();
        foreach (int iNumber in listNumbers.ToList())
        {
            Console.Write(" " + iNumber.ToString());
            if (iFirstLoop != 1)
            {
                listNextNumbers.Add(iNumber - iPreviousNumber);
            }
            Debug.WriteLine(iNumber);
            // update to double logic
            if (iCurrentIndex == listNumbers.Count-1)
            {
                Debug.WriteLine(listNumbers[listNumbers.Count - 2]);
                Debug.WriteLine(iNumber - listNumbers[listNumbers.Count - 2]);
                iToAdd += (iNumber - listNumbers[listNumbers.Count-2]);
            }
            iFirstLoop = 0;
            iPreviousNumber = iNumber;
            iCurrentIndex++;
        }

        if (listNextNumbers[0] != listNextNumbers[listNextNumbers.Count-1])
        {
            listNumbers = listNextNumbers;
        }
        else
        {
            Console.WriteLine();
            foreach (int iNumber in listNextNumbers)
            {
                Console.Write(" " + iNumber.ToString());
            }
            bCompleted = true;
        }
    }

    int iLastNumber = int.Parse(strNumbers[strNumbers.Length - 1]);
    iTotal += (iToAdd + iLastNumber);
    Console.WriteLine();
    Debug.WriteLine((iLastNumber + iToAdd).ToString());
    Console.WriteLine((iLastNumber + iToAdd).ToString());
}
Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

Console.WriteLine(iTotal);
Debug.WriteLine(iTotal);