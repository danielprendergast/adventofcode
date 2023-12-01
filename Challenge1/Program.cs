// Read all input lines
string[] strInputArray = File.ReadAllLines("input.txt");
// Start counter of total
int iTotalValue = 0;

// Loop each input line
foreach (string input in strInputArray)
{
    Console.WriteLine("Starting");
    Console.WriteLine(input);
    // Convert to individual characters
    char[] chars = input.ToCharArray();
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