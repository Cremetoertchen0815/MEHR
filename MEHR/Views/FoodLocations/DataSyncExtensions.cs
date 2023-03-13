using MEHR.Contexts;
using MEHR.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace MEHR.Views.FoodLocations;

public static class DataSyncExtensions
{ 
    public static FoodLocation ParseData(this FoodLocation foodLocation, Dictionary<string, string> parameters, DataContext context)
    {
        //Parse regular data
        foodLocation.Description = parameters["Description"];
        foodLocation.Name = parameters["Name"];
        foodLocation.PhoneNumber = parameters["PhoneNumber"];
        foodLocation.LocationLatitude = double.Parse(parameters["LocationLatitude"]);
        foodLocation.LocationLongitude = double.Parse(parameters["LocationLongitude"]);
        foodLocation.HasDelivery = parameters.ContainsKey("HasDelivery");
        foodLocation.Icon = int.Parse(parameters["Icon"]);
        //Parse opening times
        foodLocation.OpeningTimes = new OpeningTimes()
        {
            SeasonStart = (DateOnly.Parse(parameters["SeasonStart"]).Day, DateOnly.Parse(parameters["SeasonStart"]).Month),
            SeasonEnd = (DateOnly.Parse(parameters["SeasonEnd"]).Day, DateOnly.Parse(parameters["SeasonEnd"]).Month),
            Monday = (TimeOnly.Parse(parameters["TimeOpenMonday"]), TimeOnly.Parse(parameters["TimeCloseMonday"])),
            Tuesday = (TimeOnly.Parse(parameters["TimeOpenTuesday"]), TimeOnly.Parse(parameters["TimeCloseTuesday"])),
            Wednesday = (TimeOnly.Parse(parameters["TimeOpenWednesday"]), TimeOnly.Parse(parameters["TimeCloseWednesday"])),
            Thursday = (TimeOnly.Parse(parameters["TimeOpenThursday"]), TimeOnly.Parse(parameters["TimeCloseThursday"])),
            Friday = (TimeOnly.Parse(parameters["TimeOpenFriday"]), TimeOnly.Parse(parameters["TimeCloseFriday"])),
        };
        //Add missing food slots
        int count = int.Parse(parameters["FoodCount"]);
        if (foodLocation.Foods is null) foodLocation.Foods = new List<Food>();
        while (foodLocation.Foods.Count < count) foodLocation.Foods.Add(new Food());

        for (int i = 1; i <= count; i++)
        {
            var item = foodLocation.Foods.ElementAt(i - 1);
            item.Name = parameters["FoodName" + i];
            item.Tag = GetOrRegisterTag(parameters["FoodTags" + i], context);
            item.LowerPriceRange = decimal.Parse(parameters["FoodLower" + i]);
            item.UpperPriceRange = decimal.Parse(parameters["FoodUpper" + i]);
        }

        context.SaveChanges();
        return foodLocation;
    }

    private static FoodTag GetOrRegisterTag(string Name, DataContext context)
    {
        var tag = context.FoodTags.FirstOrDefault(x => x.Name == Name); //Fetch existing food tag
        if (tag is not null) return tag; //If existent, return id
        //Food tag not present, so create
        tag = new FoodTag()
        {
            Name = Name,
            Color = (((uint)Random.Shared.Next()) << 1) | 0x000000FF //Generate random color, fill empty sign & set alpha byte to max
        };
        context.FoodTags.Add(tag);
        context.SaveChanges();
        return tag;
    }
}