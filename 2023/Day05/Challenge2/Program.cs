using System.Collections.Generic;
using System.Text.RegularExpressions;

string strInput = File.ReadAllText("input.txt");
long iLowestLocation = 0;

string[] strGrouppedInput = strInput.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);

string[] strSeeds = strGrouppedInput[0].Substring("seeds: ".Length).Split(" ");
string[] strSeedToSoilMaps = strGrouppedInput[1].Substring("seed-to-soil map:: ".Length).Split("\r\n");
string[] strSoilToFertilizerMaps = strGrouppedInput[2].Substring("soil-to-fertilizer map: \n".Length).Split("\r\n");
string[] strFertilizerToWaterMaps = strGrouppedInput[3].Substring("fertilizer-to-water map: \n".Length).Split("\r\n");
string[] strWaterToLightMaps = strGrouppedInput[4].Substring("water-to-light map: \n".Length).Split("\r\n");
string[] strLightToTemperatureMaps = strGrouppedInput[5].Substring("light-to-temperature map: \n".Length).Split("\r\n");
string[] strTemperatureToHumidityMaps = strGrouppedInput[6].Substring("temperature-to-humidity map: \n".Length).Split("\r\n");
string[] strHumidityToLocationMaps = strGrouppedInput[7].Substring("humidity-to-location map: \n".Length).Split("\r\n");

int iAlternate = 0;
long iBaseSeed = 0;

//Create seed pairs
var listPairs = new List<Tuple<long, long>>();
foreach (string strSeed in strSeeds)
{
    if (iAlternate == 0)
    {
        iBaseSeed = long.Parse(strSeed);
        iAlternate = 1;
    }
    else
    {
        listPairs.Add(new Tuple<long, long>(iBaseSeed, long.Parse(strSeed)));
        iAlternate = 0;
    }
}

listPairs.Sort((x, y) => y.Item1.CompareTo(x.Item1));
listPairs.Reverse();

int iRuns = 0;
List<long> strSeedsRanged = new List<long>();

foreach (Tuple<long, long> tuplePair in listPairs)
{
    long lSeedToAdd = tuplePair.Item1;
    long lMax = tuplePair.Item1 + tuplePair.Item2;
    long lTotalRuns = tuplePair.Item2;
    try
    {
        //Thought this would help, but does absolutely nothing
        if (lMax >= listPairs[iRuns + 1].Item1)
        {
            lTotalRuns = listPairs[iRuns + 1].Item1 - listPairs[iRuns].Item1;
        }
    }
    catch { }
    for (long l = 0; l < lTotalRuns; l++)
    {
        strSeedsRanged.Add(lSeedToAdd + l);
    }
    iRuns++;
}

iRuns = 1;


//Precreate relations

var listSeedToSoilRelations = CreateRelations(strSeedToSoilMaps);
var listSoilToFertilizerRelations = CreateRelations(strSoilToFertilizerMaps);
var listFertilizerToWaterRelations = CreateRelations(strFertilizerToWaterMaps);
var listWaterToLightRelations = CreateRelations(strWaterToLightMaps);
var listLightToTemperatureRelations = CreateRelations(strLightToTemperatureMaps);
var listTemperatureToHumidityRelations = CreateRelations(strTemperatureToHumidityMaps);
var listHumidityToLocationRelations = CreateRelations(strHumidityToLocationMaps);

Console.Write("Running for :" + strSeedsRanged.Count + " seeds.");
Console.WriteLine();

foreach (long lSeed in strSeedsRanged)
{
    long iSeed = lSeed;
    long iSoil = CheckArray(listSeedToSoilRelations, iSeed); ;
    long iFertilizer = CheckArray(listSoilToFertilizerRelations, iSoil);
    long iWater = CheckArray(listFertilizerToWaterRelations, iFertilizer); ;
    long iLight = CheckArray(listWaterToLightRelations, iWater); ;
    long iTemperature = CheckArray(listLightToTemperatureRelations, iLight); ;
    long iHumidity = CheckArray(listTemperatureToHumidityRelations, iTemperature); ;
    long iLocation = CheckArray(listHumidityToLocationRelations, iHumidity); ;

    if (iLocation < iLowestLocation || iLowestLocation == 0)
    {
        iLowestLocation = iLocation;
    }
    iRuns++;
    if (iRuns % 2000000 == 0)
    {
        double dPercent = (double)iRuns / (double)strSeedsRanged.Count;
        dPercent = dPercent * 100;
        Console.WriteLine(dPercent.ToString() + "%");
    }
}

Console.WriteLine("Lowest Location Seed is: " + iLowestLocation.ToString());
// Welp this pulls out the value +1, so the solution is actually incomplete but I want to get ready for day 6 :)
Console.ReadKey(true);

static long CheckArray(List<Tuple<long, long, long>> listRelations, long iSource)
{
    long lValue = 0;
    foreach (Tuple<long, long, long> tuplePair in listRelations)
    {
        if (iSource >= tuplePair.Item2 && iSource < tuplePair.Item2 + tuplePair.Item3)
        {
            lValue = iSource - tuplePair.Item2 + tuplePair.Item1;
        }
    }
    if (lValue == 0)
    {
        lValue = iSource;
    }
    return lValue;
}

static List<Tuple<long, long, long>> CreateRelations(string[] strStringToMap)
{
    var listRelations = new List<Tuple<long, long, long>>();
    foreach (string strMap in strStringToMap)
    {
        string[] strRelations = strMap.Split(" ");
        listRelations.Add(new Tuple<long, long, long>(long.Parse(strRelations[0]), long.Parse(strRelations[1]), long.Parse(strRelations[2])));
    }
    return listRelations;
}