﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    public interface ILanguage
    {
        string LegalName();
        string Title();
        string Email();
        string Phone();
        string MovingDate();
        string FlexibleDate();
        string DepartureAddressCity();
        string DestinationAddressCity();
        string FloorDeparture();
        string FloorDestination();
        string Refrigerator();
        string Small();
        string MediumSmall();
        string Large();
        string LargeFreezer();
        string MediumFreezer();
        string CookersOvenStove();
        string Dishwasher();
        string Dryer();
        string StackedWasherDryer();
        string Washer();
        string DryerAboveWasher();
        string KingBedBase();
        string QueenBedBase();
        string DoubleBedBase();
        string SingleBedBase();
        string KingMattress();
        string QueenMattress();
        string DoubleMattress();
        string SingleMattressSmall();
        string BoxspringKing();
        string BoxspringSingle();
        string BoxspringQueen();
        string BoxspringDouble();
        string Commode();
        string Nightstand();
        string Wardrobe2Doors();
        string Wardrobe1Door();
        string Cradle();
        string Loveseat2SeaterSofa();
        string Sofa3Seater();
        string Armchair();
        string TvStand();
        string LargeTv();
        string MediumSmallTv();
        string CoffeeAndSideTables();
        string DiningOrPatioTables();
        string Chairs();
        string Library();
        string DrawerFolderCabinet();
        string DessertHucheCabinets();
        string MirrorsFrames();
        string LargeCarpet();
        string SmallMediumCarpet();
        string LampsAndLampShades();
        string Safe();
        string SentenceSmall();
        string SentenceAverage();
        string SentenceBig();
        string Piano();
        string Barbecue();
        string Bike();
        string StationaryBikes();
        string Suitcases();
        string Tires();
        string Treadmill();
        string PoolTable();
        string YourBoxesApproximate();
        string WardrobeBoxes4Provided();
        string MoreDetails();
        string HowDidYouHearAboutUs();
    }
}
