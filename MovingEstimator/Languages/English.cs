using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator.Languages
{
    public class English : ILanguage
    {
        /*
         * DESTINATION ADDRESS + CITY
         * FLOOR at DEPARTURE ADDRESS
         * FLOOR at DESTINATION ADDRESS
         * REFRIGERATOR
         * SMALL
         * LARGE
         * LARGE FREEZER
         * MEDIUM FREEZER
         * COOKERS - OVEN / STOVE
         * DISHWASHER
         * DRYER
         * STACKED WASHER - DRYER
         * WASHER
         * Dryer above washer
         * KING BED BASE
         * QUEEN BED BASE
         * DOUBLE BED BASE
         * SINGLE BED BASE
         * KING MATTRESS
         * QUEEN MATTRESS
         * DOUBLE MATTRESS
         * SINGLE MATTRESS (SMALL)
         * BOXSPRING KING
         * BOXSPRING SINGLE
         * BOXSPRING QUEEN
         * BOXSPRING DOUBLE
         * COMMODE
         * NIGHTSTAND
         * WARDROBE (2 DOORS)
         * WARDROBE (1 DOOR)
         * CRADLE
         * LOVESEAT (2-SEATER SOFA)
         * SOFA (3-SEATER)
         * ARMCHAIR
         * TV STAND
         * LARGE
         * MEDIUM/SMALL
         * TV (LARGE)
         * TV (MEDIUM/SMALL)
         * COFFEE AND SIDE TABLES
         * DINING OR PATIO TABLES
         * CHAIRS
         * LIBRARY
         * DRAWER FOLDER CABINET
         * DESSERT, HUCHE, CABINETS
         * MIRRORS - FRAMES
         * LARGE CARPET
         * SMALL - MEDIUM CARPET
         * LAMPS AND LAMP SHADES
         * SAFE
         * Small
         * Average
         * Big
         * PIANO
         * BARBECUE
         * BIKE
         * STATIONARY BIKES
         * SUITCASES
         * TIRES
         * TREADMILL
         * STATIONARY BIKES
         * POOL TABLE
         * YOUR BOXES (APPROXIMATE)
         * WARDROBE BOXES (4 PROVIDED)
         * MORE DETAILS
         * HOW DID YOU HEAR ABOUT US ?
         */

        public string Armchair()
        {
            return "ARMCHAIR";
        }

        public string Barbecue()
        {
            return "BARBECUE";
        }

        public string Bike()
        {
            return "BIKE";
        }

        public string BoxspringDouble()
        {
            return "BOXSPRING DOUBLE";
        }

        public string BoxspringKing()
        {
            return "BOXSPRING KING";
        }

        public string BoxspringQueen()
        {
            return "BOXSPRING QUEEN";
        }

        public string BoxspringSingle()
        {
            return "BOXSPRING SINGLE";
        }

        public string Chairs()
        {
            return "CHAIRS";
        }

        public string CoffeeAndSideTables()
        {
            return "COFFEE AND SIDE TABLES";
        }

        public string Commode()
        {
            return "COMMODE";
        }

        public string CookersOvenStove()
        {
            return "COOKERS - OVEN / STOVE";
        }

        public string Cradle()
        {
            return "CRADLE";
        }

        public string DepartureAddressCity()
        {
            return "DEPARTURE ADDRESS + CITY";
        }

        public string DessertHucheCabinets()
        {
            return "DESSERT, HUCHE, CABINETS";
        }

        public string DestinationAddressCity()
        {
            return "DESTINATION ADDRESS + CITY";
        }

        public string DiningOrPatioTables()
        {
            return "DINING OR PATIO TABLES";
        }

        public string Dishwasher()
        {
            return "DISHWASHER";
        }

        public string DoubleBedBase()
        {
            return "DOUBLE BED BASE";
        }

        public string DoubleMattress()
        {
            return "DOUBLE MATTRESS";
        }

        public string DrawerFolderCabinet()
        {
            return "DRAWER FOLDER CABINET";
        }

        public string Dryer()
        {
            return "DRYER";
        }

        public string DryerAboveWasher()
        {
            return "Dryer above washer";
        }

        public string Email()
        {
            return "E-MAIL";
        }

        public string FlexibleDate()
        {
            return "FLEXIBLE DATE?";
        }

        public string FloorDeparture()
        {
            return "FLOOR at DEPARTURE ADDRESS";
        }

        public string FloorDestination()
        {
            return "FLOOR at DESTINATION ADDRESS";
        }

        public string HowDidYouHearAboutUs()
        {
            return "HOW DID YOU HEAR ABOUT US ?";
        }

        public string KingBedBase()
        {
            return "KING BED BASE";
        }

        public string KingMattress()
        {
            return "KING MATTRESS";
        }

        public string LampsAndLampShades()
        {
            return "LAMPS AND LAMP SHADES";
        }

        public string Large()
        {
            return "LARGE";
        }

        public string LargeCarpet()
        {
            return "LARGE CARPET";
        }

        public string LargeFreezer()
        {
            return "LARGE FREEZER";
        }

        public string LargeTv()
        {
            return "TV (LARGE)";
        }

        public string LegalName()
        {
           return "LEGAL NAME";
        }

        public string Library()
        {
            return "LIBRARY";
        }

        public string Loveseat2SeaterSofa()
        {
            return "LOVESEAT (2-SEATER SOFA)";
        }

        public string MediumFreezer()
        {
            return "MEDIUM FREEZER";
        }

        public string MediumSmall()
        {
            return "MEDIUM/SMALL";
        }

        public string MediumSmallTv()
        {
            return "TV (MEDIUM/SMALL)";
        }

        public string MirrorsFrames()
        {
            return "MIRRORS - FRAMES";
        }

        public string MoreDetails()
        {
            return "MORE DETAILS";
        }

        public string MovingDate()
        {
            return "MOVING DATE";
        }

        public string Nightstand()
        {
            return "NIGHTSTAND";
        }

        public string Phone()
        {
            return "PHONE#";
        }

        public string Piano()
        {
            return "PIANO";
        }

        public string PoolTable()
        {
            return "POOL TABLE";
        }

        public string QueenBedBase()
        {
            return "QUEEN BED BASE";
        }

        public string QueenMattress()
        {
            return "QUEEN MATTRESS";
        }

        public string Refrigerator()
        {
            return "REFRIGERATOR";
        }

        public string Safe()
        {
            return "SAFE";
        }

        public string SentenceAverage()
        {
            return "Average";
        }

        public string SentenceBig()
        {
            return "Big";
        }

        public string SentenceSmall()
        {
            return "Small";
        }

        public string SingleBedBase()
        {
            return "SINGLE BED BASE";
        }

        public string SingleMattressSmall()
        {
            return "SINGLE MATTRESS (SMALL)";
        }

        public string Small()
        {
            return "SMALL";
        }

        public string SmallMediumCarpet()
        {
            return "SMALL - MEDIUM CARPET";
        }

        public string Sofa3Seater()
        {
            return "SOFA (3-SEATER)";
        }

        public string StackedWasherDryer()
        {
            return "STACKED WASHER - DRYER";
        }

        public string StationaryBikes()
        {
            return "STATIONARY BIKES";
        }

        public string Step1()
        {
            return "STEP 1 - CUSTOMER INFORMATION";
        }

        public string Suitcases()
        {
            return "SUITCASES";
        }

        public string Tires()
        {
            return "TIRES";
        }

        public string Title()
        {
            return "TITLE";
        }

        public string Treadmill()
        {
            return "TREADMILL";
        }

        public string TvStand()
        {
            return "TV STAND";
        }

        public string Wardrobe1Door()
        {
            return "WARDROBE (1 DOOR)";
        }

        public string Wardrobe2Doors()
        {
            return "WARDROBE (2 DOORS)";
        }

        public string WardrobeBoxes4Provided()
        {
            return "WARDROBE BOXES (4 PROVIDED)";
        }

        public string Washer()
        {
            return "WASHER";
        }

        public string YourBoxesApproximate()
        {
            return "YOUR BOXES (APPROXIMATE)";
        }
    }
}
