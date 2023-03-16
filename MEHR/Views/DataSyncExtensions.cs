using MEHR.Contexts;
using MEHR.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System;

namespace MEHR.Views;

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

    public static AppUser ParseData(this AppUser appUser, Dictionary<string, string> parameters, DataContext context)
    {
        appUser.CookieHash = ulong.Parse(parameters["CookieHash"], System.Globalization.NumberStyles.HexNumber);
        
        //Add missing rating slots
        int count = int.Parse(parameters["RatingsCount"]);
        if (appUser.Ratings is null) appUser.Ratings = new List<LocationRating>();
        while (appUser.Ratings.Count < count) appUser.Ratings.Add(new LocationRating());

        for (int i = 1; i <= count; i++)
        {
            var item = appUser.Ratings.ElementAt(i - 1);
            item.Location = context.FoodLocations.Include(x => x.Ratings).FirstOrDefault(x => x.Id == int.Parse(parameters["RatingTarget" + i]));
            item.Rating = float.Parse(parameters["RatingVal" + i]);
            item.Text = parameters["RatingText" + i];
            item.Author = appUser;
        }

        //Add missing history slots
        count = int.Parse(parameters["HistoryCount"]);
        if (appUser.History is null) appUser.History = new List<HistoryItem>();

        for (int i = 1; i <= count; i++)
        {
            var idx = parameters["HistoryId" + i];
            var nuLocation = context.FoodLocations.FirstOrDefault(x => x.Id == int.Parse(parameters["HistoryTarget" + i]));
            if ((idx is null || idx == "null") && nuLocation is not null)
            {
                //Item not yet in list
                var nuItm = new HistoryItem() { CreationDate = DateTime.Now.ToBinary(), Owner = appUser, Location = nuLocation };
                appUser.History.Add(nuItm);
            } else if (nuLocation is not null && int.TryParse(idx, out int loc))
            {
                var item = context.HistoryItems.FirstOrDefault(x => x.Id == loc && x.Owner == appUser);
                if (item is null || item.Location == nuLocation) continue;
                item.CreationDate = DateTime.Now.ToBinary();
                item.Location = nuLocation;
            }
        }

        context.SaveChanges();
        return appUser;
    }

    private static FoodTag GetOrRegisterTag(string Name, DataContext context)
    {
        var tag = context.FoodTags.FirstOrDefault(x => x.Name == Name); //Fetch existing food tag
        if (tag is not null) return tag; //If existent, return id
        //Food tag not present, so create
        tag = new FoodTag()
        {
            Name = Name,
            Color = (uint)Random.Shared.Next() << 1 | 0x000000FF //Generate random color, fill empty sign & set alpha byte to max
        };
        return tag;
    }
}