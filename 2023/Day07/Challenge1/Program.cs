using System.Text.RegularExpressions;

string[] strInput = File.ReadAllLines("input.txt");

List<Hand> Hands = new System.Collections.Generic.List<Hand>();
List<Hand> HandsRanked = new System.Collections.Generic.List<Hand>();

var listCardOrder = new List<string> { "1","2","3","4","5","6","7","8","9","T","J","Q","K","A"};

foreach (string strLine in strInput)
{
    string[] strContents = strLine.Split(" ");

    Hand hand = new Hand();
    hand.Card1 = strContents[0].Substring(0,1);
    hand.Card2 = strContents[0].Substring(1,1);
    hand.Card3 = strContents[0].Substring(2,1);
    hand.Card4 = strContents[0].Substring(3,1);
    hand.Card5 = strContents[0].Substring(4,1);

    var lCardCounts = new List<int>() { Regex.Matches(strContents[0], hand.Card1).Count(), Regex.Matches(strContents[0], hand.Card2).Count(), Regex.Matches(strContents[0], hand.Card3).Count(), Regex.Matches(strContents[0], hand.Card4).Count(), Regex.Matches(strContents[0], hand.Card5).Count() };
    
    //5 = High Card, 7 = One Pair, 9 = Two Pair, 11 = ThreeOAK, 13 = Full House, 17 = Four of a kind, 25 = Five of a kind
    hand.CardMatches = lCardCounts.Sum();

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
    public string Card1 { get ; set; }
    public string Card2 { get ; set; }
    public string Card3 { get ; set; }
    public string Card4 { get ; set; }
    public string Card5 { get ; set; }
    public int Bid { get ; set; }

    public int CardMatches { get ; set; }
    public int Rank { get ; set; }  
    public long Total { get ; set; }  
}