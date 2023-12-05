using System.Text.RegularExpressions;

string strInput = File.ReadAllText("input.txt");
long iLowestLocation = 0;

string[] strGrouppedInput = strInput.Split(new string[] {"\r\n\r\n"},StringSplitOptions.None);

string[] strSeeds = strGrouppedInput[0].Substring("seeds: ".Length).Split(" ");
string[] strSeedToSoilMaps = strGrouppedInput[1].Substring("seed-to-soil map:: ".Length).Split("\r\n");
string[] strSoilToFertilizerMaps = strGrouppedInput[2].Substring("soil-to-fertilizer map: \n".Length).Split("\r\n");
string[] strFertilizerToWaterMaps = strGrouppedInput[3].Substring("fertilizer-to-water map: \n".Length).Split("\r\n");
string[] strWaterToLightMaps = strGrouppedInput[4].Substring("water-to-light map: \n".Length).Split("\r\n");
string[] strLightToTemperatureMaps = strGrouppedInput[5].Substring("light-to-temperature map: \n".Length).Split("\r\n");
string[] strTemperatureToHumidityMaps = strGrouppedInput[6].Substring("temperature-to-humidity map: \n".Length).Split("\r\n");
string[] strHumidityToLocationMaps = strGrouppedInput[7].Substring("humidity-to-location map: \n".Length).Split("\r\n");

foreach (string strSeed in strSeeds)
{
    long iSeed = long.Parse(strSeed);
    long iSoil = 0;
    long iFertilizer = 0;
    long iWater= 0;
    long iLight= 0;
    long iTemperature = 0;
    long iHumidity = 0;
    long iLocation = 0;


    // Seed to Soil
    foreach (string strMap in strSeedToSoilMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iSeed >= long.Parse(strRelations[1]) && iSeed < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iSoil = iSeed - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iSoil == 0)
    {
        iSoil = iSeed;
    }

    // Soil to Fertilizer
    foreach (string strMap in strSoilToFertilizerMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iSoil >= long.Parse(strRelations[1]) && iSoil < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iFertilizer = iSoil - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iFertilizer == 0)
    {
        iFertilizer = iSoil;
    }

    // Fertilizer to Water
    foreach (string strMap in strFertilizerToWaterMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iFertilizer >= long.Parse(strRelations[1]) && iFertilizer < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iWater = iFertilizer - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iWater == 0)
    {
        iWater = iFertilizer;
    }

    // Water to Light
    foreach (string strMap in strWaterToLightMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iWater >= long.Parse(strRelations[1]) && iWater < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iLight = iWater - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iLight == 0)
    {
        iLight = iWater;
    }

    // Light to Temperature
    foreach (string strMap in strLightToTemperatureMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iLight >= long.Parse(strRelations[1]) && iLight < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iTemperature = iLight - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iTemperature == 0)
    {
        iTemperature = iLight;
    }

    // Temperature to Humidity
    foreach (string strMap in strTemperatureToHumidityMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iTemperature >= long.Parse(strRelations[1]) && iTemperature < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iHumidity = iTemperature - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iHumidity == 0)
    {
        iHumidity = iTemperature;
    }

    // Humidity to Location
    foreach (string strMap in strHumidityToLocationMaps)
    {
        string[] strRelations = strMap.Split(" ");
        if (iHumidity >= long.Parse(strRelations[1]) && iHumidity < long.Parse(strRelations[1]) + long.Parse(strRelations[2]))
        {
            iLocation = iHumidity - long.Parse(strRelations[1]) + long.Parse(strRelations[0]);
        }
    }
    if (iLocation == 0)
    {
        iLocation = iHumidity;
    }

    if (iLocation < iLowestLocation || iLowestLocation == 0)
    {
        iLowestLocation = iLocation;
    }
}


Console.WriteLine(iLowestLocation.ToString());