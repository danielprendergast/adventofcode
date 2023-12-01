// Read all input lines
string[] strInputArray = File.ReadAllLines("input.txt");
// Start counter of total
int iTotalValue = 0;

// Loop each input line
foreach (string input in strInputArray)
{
    //Target input contains no two digit alphanumeric numbers - so just bruteforce it
    string strModifiedInput = input;

    // Jank to sanitise input
    strModifiedInput += strModifiedInput.Replace("oneight", "18");
    strModifiedInput = strModifiedInput.Replace("fiveight", "58");
    strModifiedInput = strModifiedInput.Replace("nineight", "98");
    strModifiedInput = strModifiedInput.Replace("eightwo", "82");
    strModifiedInput = strModifiedInput.Replace("eighthree", "83");
    strModifiedInput = strModifiedInput.Replace("twone", "21");
    strModifiedInput = strModifiedInput.Replace("sevenine", "79");

    strModifiedInput = strModifiedInput.Replace("one", "1");
    strModifiedInput = strModifiedInput.Replace("two", "2");
    strModifiedInput = strModifiedInput.Replace("three", "3");
    strModifiedInput = strModifiedInput.Replace("four", "4");
    strModifiedInput = strModifiedInput.Replace("five", "5");
    strModifiedInput = strModifiedInput.Replace("six", "6");
    strModifiedInput = strModifiedInput.Replace("seven", "7");
    strModifiedInput = strModifiedInput.Replace("eight", "8");
    strModifiedInput = strModifiedInput.Replace("nine", "9");

    Console.WriteLine("Starting");
    Console.WriteLine("Original: " + input);
    Console.WriteLine("Modified " + strModifiedInput);
    // Convert to individual characters
    char[] chars = strModifiedInput.ToCharArray();
    int iFirst = 0;
    int iLast = 0;
    int iCurrent = 0;
    foreach (char c in chars)
    {
        if (iFirst == 0)
        {
            // For each string check if first character is an int, if so store it as digit one
            int.TryParse(c.ToString(), out iFirst);
        }
        // Check if current character is an int, if so store it as digit two, if its not dump the 0 value - no 0's exist in the input data so this is safe
        int.TryParse(c.ToString(), out iCurrent);
        if (iCurrent != 0)
        {
            iLast = iCurrent;
        }
    }
    // Combine and output
    string strCombinedNumber = iFirst.ToString() + iLast.ToString();
    Console.WriteLine("First: " + iFirst.ToString());
    Console.WriteLine("Last: " + iLast.ToString());
    Console.WriteLine("Combined: " + strCombinedNumber);
    iTotalValue += int.Parse(strCombinedNumber);
}
Console.WriteLine("Finished!");
Console.WriteLine(iTotalValue.ToString());