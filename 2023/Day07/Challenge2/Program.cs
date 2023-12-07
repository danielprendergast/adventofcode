using System.Text.RegularExpressions;

string[] strInput = File.ReadAllLines("input.txt");

List<Hand> Hands = new System.Collections.Generic.List<Hand>();
List<Hand> HandsRanked = new System.Collections.Generic.List<Hand>();

var listCardOrder = new List<string> { "J", "1", "2", "3", "4", "5", "6", "7", "8", "9", "T", "Q", "K", "A" };

foreach (string strLine in strInput)
{
    string[] strContents = strLine.Split(" ");

    Hand hand = new Hand();
    Hand handwithoutjoker = new Hand();
    hand.Card1 = strContents[0].Substring(0, 1);
    hand.Card2 = strContents[0].Substring(1, 1);
    hand.Card3 = strContents[0].Substring(2, 1);
    hand.Card4 = strContents[0].Substring(3, 1);
    hand.Card5 = strContents[0].Substring(4, 1);
    handwithoutjoker.Card1 = strContents[0].Substring(0, 1);
    handwithoutjoker.Card2 = strContents[0].Substring(1, 1);
    handwithoutjoker.Card3 = strContents[0].Substring(2, 1);
    handwithoutjoker.Card4 = strContents[0].Substring(3, 1);
    handwithoutjoker.Card5 = strContents[0].Substring(4, 1);

    int iJoker = 0;

    // 4 or 5 joker are always totaling 25
    // 1 joker can be 25, 17, 13, 11, 7
    // 2 joker can be 25, 17, 11
    // 3 joker can be 25, 17

    if (hand.Card1 == "J")
    {
        handwithoutjoker.Card1 = "Z";
        iJoker++;
    }
    if (hand.Card2 == "J")
    {
        handwithoutjoker.Card2 = "X";
        iJoker++;
    }
    if (hand.Card3 == "J")
    {
        handwithoutjoker.Card3 = "C";
        iJoker++;
    }
    if (hand.Card4 == "J")
    {
        handwithoutjoker.Card4 = "V";
        iJoker++;
    }
    if (hand.Card5 == "J")
    {
        handwithoutjoker.Card5 = "B";
        iJoker++;
    }



    // >5 = High Card, 7 = One Pair, 9 = Two Pair, 11 = ThreeOAK, 13 = Full House, 17 = Four of a kind, 25 = Five of a kind

    var lCardCounts = new List<int>() { Regex.Matches(strContents[0], hand.Card1).Count(), Regex.Matches(strContents[0], hand.Card2).Count(), Regex.Matches(strContents[0], hand.Card3).Count(), Regex.Matches(strContents[0], hand.Card4).Count(), Regex.Matches(strContents[0], hand.Card5).Count() };
    var lCardCountswithoutjoker = new List<int>() { Regex.Matches(strContents[0], handwithoutjoker.Card1).Count(), Regex.Matches(strContents[0], handwithoutjoker.Card2).Count(), Regex.Matches(strContents[0], handwithoutjoker.Card3).Count(), Regex.Matches(strContents[0], handwithoutjoker.Card4).Count(), Regex.Matches(strContents[0], handwithoutjoker.Card5).Count() };
    hand.CardMatches = lCardCounts.Sum();

    if (iJoker == 1)
    {
        if (lCardCountswithoutjoker.Sum() == 4)
        {
            hand.CardMatches = 7;
        }
        if (lCardCountswithoutjoker.Sum() == 6)
        {
            hand.CardMatches = 11;
        }
        if (lCardCountswithoutjoker.Sum() == 8)
        {
            hand.CardMatches = 13;
        }
        if (lCardCountswithoutjoker.Sum() == 10)
        {
            hand.CardMatches = 17;
        }
        if (lCardCountswithoutjoker.Sum() == 16)
        {
            hand.CardMatches = 25;
        }
    }
    if (iJoker == 2)
    {
        if (lCardCountswithoutjoker.Sum() == 3)
        {
            hand.CardMatches = 11;
        }
        if (lCardCountswithoutjoker.Sum() == 5)
        {
            hand.CardMatches = 17;
        }
        if (lCardCountswithoutjoker.Sum() == 9)
        {
            hand.CardMatches = 25;
        }
    }
    if (iJoker == 3)
    {
        if (lCardCountswithoutjoker.Sum() == 2)
        {
            hand.CardMatches = 17;
        }
        if (lCardCountswithoutjoker.Sum() == 4)
        {
            hand.CardMatches = 25;
        }
    }
    if (iJoker == 4 || iJoker == 5)
    {
        hand.CardMatches = 25;
    }


    hand.Bid = int.Parse(strContents[1]);

    Hands.Add(hand);
}

IEnumerable<Hand> query = Hands.OrderBy(hand => hand.CardMatches).ThenBy(hand => listCardOrder.IndexOf(hand.Card1)).ThenBy(hand => listCardOrder.IndexOf(hand.Card2)).ThenBy(hand => listCardOrder.IndexOf(hand.Card3)).ThenBy(hand => listCardOrder.IndexOf(hand.Card4)).ThenBy(hand => listCardOrder.IndexOf(hand.Card5));

int iRank = 1;
long iTotal = 0;

foreach (var hand in query)
{
    hand.Rank = iRank;
    hand.Total = hand.Rank * hand.Bid;
    iTotal += hand.Total;
    HandsRanked.Add(hand);
    iRank++;
}

Console.WriteLine(iTotal.ToString());

public class Hand
{
    public string Card1 { get; set; }
    public string Card2 { get; set; }
    public string Card3 { get; set; }
    public string Card4 { get; set; }
    public string Card5 { get; set; }
    public int Bid { get; set; }

    public int CardMatches { get; set; }
    public int Rank { get; set; }
    public long Total { get; set; }
}

