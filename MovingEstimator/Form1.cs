using MovingEstimator.Languages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovingEstimator
{
    public partial class Form1 : Form
    {
        private string s_client_name,
            s_client_phn_number,
            s_client_email,
            s_moving_date,
            s_moving_date2,
            s_moving_date3,
            s_inventory,
            s_notes;
        private double dLoading_time,
            dUnLoading_time,
            dVolume,
            dDistance,
            dHourly_rate,
            dMoving_estimated_cost,
            dnb_of_trucks;
        private int nPlastic_bags,
            nWardrobe_boxes;

        public Form1()
        {
            InitializeComponent();
            //  initialise all moving variables
            s_client_name = "";
            s_client_phn_number = "";
            s_client_email = "";
            s_moving_date = "";
            s_moving_date2 = "";
            s_moving_date3 = "";
            s_inventory = "";
            s_notes = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n_items = 0; // number of a specific item in the invetory
            reset();            // intializing elements
            if (Move_description.Text.Length > 2)
            {
                const string GEnglishToDetect = "STEP 1 - CUSTOMER INFORMATION";
                const string GFrenchToDetect = "ÉTAPE 1 - INFORMATIONS CLIENT";
                ILanguage language = null;

                // divides text into lines
                string[] s_Lines = Move_description.Text.Split(new string[] { "\n\n" }, StringSplitOptions.None);
                int n_Line = 0;
  
                // Choose language
                if (Move_description.Text.Contains(GFrenchToDetect))
                {
                    language = new French();
                }
                else if (Move_description.Text.Contains(GEnglishToDetect))
                {
                    language = new English();
                }

                string key, value;
                string[] arr;
                while (n_Line < s_Lines.Length)
                {
                    arr = s_Lines[n_Line].Split(new string[] { "\n" }, StringSplitOptions.None);
                    if (arr.Length < 2)
                    {
                        ++n_Line;
                        continue;
                    }

                    key = arr[0].Trim();
                    value = arr[1].Trim();

                    if (key.Contains(language.LegalName()))
                    {
                        // delete FIRST NAME
                        s_client_name += value;
                        // add separator
                        s_client_name += ' ';
                    }
                    if (key.Contains(language.Title()))
                    {
                        //delete TITLE
                        string title_and_name = value;
                        title_and_name += " " + s_client_name;
                        s_client_name = title_and_name;

                    }
                    if (key.Contains(language.Email()))
                    {
                        //delete E-MAIL
                        s_client_email = value;
                    }
                    if (key.Contains(language.Phone()))
                    {
                        //delete PHONE
                        s_client_phn_number = value;
                    }
                    if (key == language.MovingDate())
                    {
                        //delete DATED
                        s_moving_date = value;
                        label_flexible_date.Text = s_moving_date;
                        DateTime dt1 = new DateTime(int.Parse(s_moving_date.Substring(0, 4)), int.Parse(s_moving_date.Substring(5, 2)), int.Parse(s_moving_date.Substring(8, 2)));

                        monthCalendar1.SetDate(dt1);
                        monthCalendar2.SetDate(dt1);
                        monthCalendar3.SetDate(dt1);
                    }
                    if (key.Contains(language.FlexibleDate()))
                    {
                        label_flexible_date.Text = value;
                    }
                    if (key.Contains(language.DepartureAddressCity()))
                    {
                        //delete DEPARTURE ADDRESS + CITY
                        textBox_Starting_address.Text = value;
                    }
                    if (key.Contains(language.DestinationAddressCity()))
                    {
                        //delete DESTINATION ADDRESS + CITY
                        textBox_Destination_address.Text = value;
                    }
                    if (key.Contains(language.FloorDeparture()))
                    {
                        //FLOOR DEPARTURE ADDRESS
                        textBox_Starting_address_floor.Text = value;
                    }
                    if (key.Contains(language.FloorDestination()))
                    {
                        //delete FLOOR DESTINATION ADDRESS
                        textBox_Destination_address_floor.Text = value;
                    }
                    if (key.Contains(language.Refrigerator()))
                    {
                        if (!key.Contains(language.Small()) && !key.Contains(language.Large()))// both previous ifs were false
                        {
                            //REFRIGERATOR	1
                            n_items = int.Parse(value);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += "x " + language.Refrigerator() + "; ";
                                dVolume += n_items;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains(language.Large()))
                        {
                            //LARGE REFRIGERATOR	1 
                            n_items = int.Parse(value);
                            if (n_items > 0)
                            {
                                s_inventory += n_items; // number of LARGE REFRIGERATOR
                                s_inventory += "x " + language.Large() + " " + language.Refrigerator() + "; ";
                                dVolume += n_items * 1.3;
                                dLoading_time += n_items * 0.2;
                                dUnLoading_time += n_items * 0.15;
                            }
                        }
                        if (key.Contains(language.Small()))
                        {
                            //SMALL REFRIGERATOR	1
                            n_items = int.Parse(value);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += "x " + language.Small() + " " + language.Refrigerator() + "; ";
                                dVolume += n_items * 0.5;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                    }// fridges
                    if (key.Contains(language.LargeFreezer()))
                    {
                        //LARGE FREEZER   1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.LargeFreezer() + "; ";

                            dVolume += n_items;
                            dLoading_time += n_items * 0.15;
                            dUnLoading_time += n_items * 0.12;
                        }
                    }
                    if (key.Contains(language.MediumFreezer()))
                    {
                        //MEDIUM FREEZER   1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.MediumFreezer() + "; ";

                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.CookersOvenStove()))
                    {
                        //COOKERS - OVEN / STOVE    1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.CookersOvenStove() + "; ";

                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.Dishwasher()))
                    {
                        //DISHWASHER    1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Dishwasher() + "; ";

                            dVolume += n_items * .4;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.07;
                        }
                    }
                    if (key.Contains(language.Dryer()) && !key.Contains(language.StackedWasherDryer()))
                    {
                        //DRYER    1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Dryer() + "; ";

                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.07;
                        }
                    }
                    if (key.Contains(language.Washer()) && !key.Contains(language.StackedWasherDryer()))
                    {
                        //WASHER    1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Washer() + "; ";

                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.07;
                        }
                    }
                    if (key.Contains(language.DryerAboveWasher()))
                    {
                        s_inventory += " " + language.DryerAboveWasher() + "; ";
                        dLoading_time += 0.1;
                        dUnLoading_time += 0.1;
                    }
                    if (key.Contains(language.KingBedBase()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.KingBedBase() + "; ";

                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.2;
                            dUnLoading_time += n_items * 0.13;
                        }
                    }
                    if (key.Contains(language.QueenBedBase()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.QueenBedBase() + "; ";

                            dVolume += n_items * .3;
                            dLoading_time += n_items * 0.11;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.DoubleBedBase()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.DoubleBedBase() + "; ";

                            dVolume += n_items * .3;
                            dLoading_time += n_items * 0.11;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.SingleBedBase()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.SingleBedBase() + "; ";

                            dVolume += n_items * .25;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.07;
                        }
                    }
                    if (key.Contains(language.KingMattress()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += 2 * n_items;
                        if (n_items > 0)
                        {

                            s_inventory += n_items;
                            s_inventory += " x " + language.KingMattress() + "; ";

                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.15;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }
                    if (key.Contains(language.QueenMattress()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {

                            s_inventory += n_items;
                            s_inventory += " x " + language.QueenMattress() + "; ";

                            dVolume += n_items * .4;
                            dLoading_time += n_items * 0.05;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }
                    if (key.Contains(language.DoubleMattress()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {

                            s_inventory += n_items;
                            s_inventory += " x " + language.DoubleMattress() + "; ";

                            dVolume += n_items * .35;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.SingleMattressSmall()))
                    {
                        //SINGLE MATTRESS (SMALL)
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.SingleMattressSmall() + "; ";

                            dVolume += n_items * .2;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.BoxspringKing()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.BoxspringKing() + "; ";
                            dVolume += n_items * .2;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.BoxspringSingle()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.BoxspringSingle() + "; ";
                            dVolume += n_items * .2;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.BoxspringQueen()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.BoxspringQueen() + "; ";
                            dVolume += n_items * .3;
                            dLoading_time += n_items * 0.04;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }
                    if (key.Contains(language.BoxspringDouble()))
                    {
                        n_items = int.Parse(value);
                        nPlastic_bags += n_items;
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.BoxspringDouble() + "; ";
                            dVolume += n_items * .25;
                            dLoading_time += n_items * 0.04;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }
                    if (key.Contains(language.Commode()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Commode() + "; ";
                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.Nightstand()))
                    {
                        //TABLE DE CHEVET 1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Nightstand() + "; ";

                            dVolume += n_items * .3;
                            dLoading_time += n_items * 0.07;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }
                    if (key.Contains(language.Wardrobe2Doors()))
                    {
                        //ARMOIRE(2 PORTES)  1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Wardrobe2Doors() + "; ";
                            dVolume += n_items * .8;
                            dLoading_time += n_items * 0.12;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }
                    if (key.Contains(language.Wardrobe1Door()))
                    {
                        //WARDROBE (1 DOOR)  1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Wardrobe1Door() + "; ";

                            dVolume += n_items * .3;
                            dLoading_time += n_items * 0.05;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }
                    if (key.Contains(language.Cradle()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Cradle() + "; ";
                            dVolume += n_items * .4;
                            dLoading_time += n_items * 0.08;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }
                    if (key.Contains(language.Loveseat2SeaterSofa()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Loveseat2SeaterSofa() + "; ";

                            dVolume += n_items * 1.0;
                            dLoading_time += n_items * 0.12;
                            dUnLoading_time += n_items * 0.06;
                        }
                    }
                    if (key.Contains(language.Sofa3Seater()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Sofa3Seater() + "; ";
                            dVolume += n_items * 1.3;
                            dLoading_time += n_items * 0.15;
                            dUnLoading_time += n_items * 0.10;
                        }
                    }
                    if (key.Contains(language.Armchair()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Armchair() + "; ";
                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }

                    if (key.Contains(language.TvStand()))
                    {
                        if (key.Contains(language.Large()))
                        {
                            n_items = int.Parse(value);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x " + language.TvStand() + " (" + language.Large() + "); ";
                                dVolume += n_items * 1.2;
                                dLoading_time += n_items * 0.3;
                                dUnLoading_time += n_items * 0.2;
                            }
                        }
                        if (key.Contains(language.MediumSmall()))
                        {
                            n_items = int.Parse(value);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x " + language.TvStand() + " (" + language.MediumSmall() + "); ";
                                dVolume += n_items * 0.4;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                    }

                    if (key.Contains(language.LargeTv()))
                    {// TÉLÉVISEUR(GRAND) 2
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.LargeTv() + ";  ";
                            dVolume += n_items * 0.3;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.1;
                        }
                    }
                    if (key.Contains(language.MediumSmallTv()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.MediumSmallTv() + ";  ";
                            dVolume += n_items * 0.1;
                            dLoading_time += n_items * 0.05;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }

                    if (key.Contains(language.CoffeeAndSideTables()))
                    {//COFFEE AND SIDE TABLES  1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.CoffeeAndSideTables() + "; ";
                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.05;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.DiningOrPatioTables()))
                    {//DINING OR PATIO TABLES  1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.DiningOrPatioTables() + "; ";

                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.15;
                            dUnLoading_time += n_items * 0.05;
                        }
                    }
                    if (key.Contains(language.Chairs()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Chairs() + "; ";
                            dVolume += n_items * .4;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.Library()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Library() + "; ";
                            dVolume += n_items * .4;
                            dLoading_time += n_items * 0.03;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.DrawerFolderCabinet()))
                    {
                        //DRAWER FOLDER CABINET 1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.DrawerFolderCabinet() + "; ";
                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.04;
                            dUnLoading_time += n_items * 0.03;
                        }
                    }
                    if (key.Contains(language.DessertHucheCabinets()))
                    {
                        //DESSERT, HUCHE, CABINETS  1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.DessertHucheCabinets() + "; ";
                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.08;
                        }
                    }
                    if (key.Contains(language.MirrorsFrames()))
                    {
                        //MIRRORS - FRAMES    2
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.MirrorsFrames() + "; ";
                            dVolume += n_items * .1;
                            dLoading_time += n_items * 0.02;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.LargeCarpet()))
                    {
                        //LARGE CARPET 1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.LargeCarpet() + "; ";
                            dVolume += n_items * .1;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.1;
                        }
                    }
                    if (key.Contains(language.SmallMediumCarpet()))
                    {
                        //LARGE CARPET 1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.SmallMediumCarpet() + "; ";
                            dVolume += n_items * .1;
                            dLoading_time += n_items * 0.02;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.LampsAndLampShades()))
                    {
                        //LAMPE 1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.LampsAndLampShades() + "; ";

                            dVolume += n_items * .2;
                            dLoading_time += n_items * 0.01;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.Safe()))
                    {
                        if (key.Contains(language.SentenceSmall()))
                        {
                            s_inventory += " Small SAFE; ";
                            dVolume += .4;
                            dLoading_time += 0.04;
                            dUnLoading_time += 0.03;
                        }
                        if (key.Contains(language.SentenceAverage()))
                        {
                            s_inventory += "---- MEDIUM SAFE (maximum 300 lbs, else 1 hour extra); ----";
                            dVolume += .6;
                            dLoading_time += 0.4;
                            dUnLoading_time += 0.2;
                        }
                        if (key.Contains(language.SentenceBig()))
                        {
                            s_inventory += "---- BIG SAFE (maximum 300 lbs, else 1 hour extra); ----";
                            dVolume += 1.2;
                            dLoading_time += 1.5;// 1 h exrtra
                            dUnLoading_time += 0.5;
                        }
                    }
                    if (key.Contains(language.Piano()))
                    {
                        if (key.Contains(language.SentenceSmall()))
                        {
                            s_inventory += " SMALL PIANO; ";
                            dVolume += .4;
                            dLoading_time += 0.04;
                            dUnLoading_time += 0.03;
                        }
                        if (key.Contains(language.SentenceAverage()))
                        {
                            s_inventory += "---- Average PIANO (maximum 300 lbs, else 1 hour extra); ----";
                            dVolume += .6;
                            dLoading_time += 0.4;
                            dUnLoading_time += 0.2;
                        }
                        if (key.Contains(language.SentenceBig()))
                        {
                            s_inventory += "---- Big PIANO ( maximum 300 lbs, else 1 hour extra); ----";
                            dVolume += 1.2;
                            dLoading_time += 1.5;// 1 h exrtra
                            dUnLoading_time += .5;
                        }
                    }
                    if (key.Contains(language.Barbecue()))
                    {
                        //BARBECUE	2
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Barbecue() + "; ";
                            dVolume += n_items * .6;
                            dLoading_time += n_items * 0.04;
                            dUnLoading_time += n_items * 0.04;
                        }
                    }
                    if (key.Contains(language.Bike()) && !key.Contains(language.StationaryBikes()))
                    {
                        //VÉLO	1
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Bike() + "; ";

                            dVolume += n_items * .5;
                            dLoading_time += n_items * 0.02;
                            dUnLoading_time += n_items * 0.02;
                        }
                    }
                    if (key.Contains(language.Suitcases()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Suitcases() + "; ";

                            dVolume += n_items * .2;
                            dLoading_time += n_items * 0.01;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.Tires()))
                    {
                        //PNEUS   13
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Tires() + "; ";

                            dVolume += n_items * .15;
                            dLoading_time += n_items * 0.01;
                            dUnLoading_time += n_items * 0.01;
                        }
                    }
                    if (key.Contains(language.Treadmill()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.Treadmill() + "; ";
                            dVolume += n_items * .8;
                            dLoading_time += n_items * 0.15;
                            dUnLoading_time += n_items * 0.15;
                        }
                    }
                    if (key.Contains(language.StationaryBikes()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.StationaryBikes() + "; ";
                            dVolume += n_items;
                            dLoading_time += n_items * 0.1;
                            dUnLoading_time += n_items * 0.1;
                        }
                    }
                    if (key.Contains(language.PoolTable()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += "\n---- " + n_items + " x " + language.PoolTable() + "; ----\n";

                            dVolume += n_items * 15;
                            dLoading_time += n_items * 3;
                            dUnLoading_time += n_items * 3;
                        }
                    }
                    if (key.Contains(language.YourBoxesApproximate()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            s_inventory += " x " + language.YourBoxesApproximate() + ";";
                            dVolume += n_items * .15;
                            dLoading_time += n_items * .015;
                            dUnLoading_time += n_items * .01;
                        }
                    }
                    if (key.Contains(language.WardrobeBoxes4Provided()))
                    {
                        n_items = int.Parse(value);
                        if (n_items > 0)
                        {
                            s_inventory += n_items;
                            nWardrobe_boxes += n_items;
                            s_inventory += " x " + language.WardrobeBoxes4Provided() + ";";

                            dVolume += n_items * .6;
                            dLoading_time += n_items * .075;
                            dUnLoading_time += n_items * .03;
                        }
                    }
                    if (key.Contains(language.MoreDetails()))
                    {
                        //PLUS DE PRÉCISIONS rien pour l\'instant
                        s_notes += "\n" + language.MoreDetails() + ": ";
                        s_notes += value;
                    }
                    if (key.Contains(language.HowDidYouHearAboutUs()))
                    {
                        s_notes += '\n' + value;
                        textBox_Destination_source.Text = value;
                    }

                    n_Line++;
                    n_items = 0;
                }

                // inventory completed and basic loading times
                //Adjust times with floors
                if (textBox_Starting_address_floor.Text.Contains("Entrepôt.") || textBox_Starting_address_floor.Text.Contains("Warehouse."))
                    dLoading_time *= 1.35;
                if (textBox_Destination_address_floor.Text.Contains("Entrepôt.") || textBox_Destination_address_floor.Text.Contains("Warehouse."))
                    dUnLoading_time *= 1.35;
                if (textBox_Starting_address_floor.Text.Contains("Ascenseur dans immeuble.") || textBox_Starting_address_floor.Text.Contains("Elevator in the building."))
                    dLoading_time *= 1.5;
                if (textBox_Destination_address_floor.Text.Contains("Ascenseur dans immeuble.") || textBox_Destination_address_floor.Text.Contains("Elevator in the building."))
                    dUnLoading_time *= 1.5;


                if (textBox_Starting_address_floor.Text.Contains("Demi Sous-Sol") || textBox_Starting_address_floor.Text.Contains("Basement."))
                    dLoading_time *= 1.15;
                if (textBox_Destination_address_floor.Text.Contains("Demi Sous-Sol") || textBox_Destination_address_floor.Text.Contains("Basement"))
                    dUnLoading_time *= 1.15;
                if (textBox_Starting_address_floor.Text.Contains("1er niveau au-dessus du RC") || textBox_Starting_address_floor.Text.Contains("1st level above RC"))
                    dLoading_time *= 1.2;
                if (textBox_Destination_address_floor.Text.Contains("1er niveau au-dessus du RC") || textBox_Destination_address_floor.Text.Contains("1st level above RC"))
                    dUnLoading_time *= 1.2;
                if (textBox_Starting_address_floor.Text.Contains("2e niveau au-dessus du RC") || textBox_Starting_address_floor.Text.Contains("2nd level above RC"))
                    dLoading_time *= 1.35;
                if (textBox_Destination_address_floor.Text.Contains("2e niveau au-dessus du RC") || textBox_Destination_address_floor.Text.Contains("2nd level above RC"))
                    dUnLoading_time *= 1.35;
                if (textBox_Starting_address_floor.Text.Contains("3e niveau au-dessus du RC") || textBox_Starting_address_floor.Text.Contains("3rd level above RC"))
                    dLoading_time *= 1.6;
                if (textBox_Destination_address_floor.Text.Contains("3e niveau au-dessus du RC") || textBox_Destination_address_floor.Text.Contains("3rd level above RC)"))
                    dUnLoading_time *= 1.6;

                // round values
                dVolume = Math.Round(dVolume, 2);
                dLoading_time = Math.Round(dLoading_time, 2);
                dUnLoading_time = Math.Round(dUnLoading_time, 2);
                //nb of trucks
                //39 cubic meter is max load capacity of 22' truck
                dnb_of_trucks = Math.Ceiling(dVolume / 39);
                label_nb_of_trucks.Text = " " + dnb_of_trucks + " camion";
                if (dnb_of_trucks > 1)
                {
                    label_nb_of_trucks.Text += "s";
                }
                label_nb_of_trucks.Text += " 22 pieds à ";
                // % of loading
                label_nb_of_trucks.Text += Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) + "%";
                if (dnb_of_trucks > 1)
                {
                    label_nb_of_trucks.Text += " ou " + dnb_of_trucks + " voyages avec le même camion si possible";
                }
                label_nb_of_trucks.Text += ".";
                if (Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) > 85)
                {
                    label_nb_of_trucks.Text += "\n  (!) risque de débordement.";
                }



                // fill labels for 2 men
                label_2men_loading_time.Text = "";
                label_2men_loading_time.Text += dLoading_time;
                label_2men_unloading_time.Text = "";
                label_2men_unloading_time.Text += dUnLoading_time;
                // fill labels for 3 men
                label_3men_loading_time.Text = "";
                label_3men_loading_time.Text += Math.Round((Double)dLoading_time * 0.7, 2);
                label_3men_unloading_time.Text = "";
                label_3men_unloading_time.Text += Math.Round((Double)dUnLoading_time * 0.7, 2);
                // fill labels for 4 men
                label_4men_loading_time.Text = "";
                label_4men_loading_time.Text += Math.Round((Double)dLoading_time * 0.55, 2);
                label_4men_unloading_time.Text = "";
                label_4men_unloading_time.Text += Math.Round((Double)dUnLoading_time * 0.55, 2);

            }
            Move_description.Text += "Analyse completed...";
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            s_moving_date = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            s_moving_date2 = monthCalendar2.SelectionStart.ToShortDateString();
        }

        private void monthCalendar3_DateChanged(object sender, DateRangeEventArgs e)
        {
            s_moving_date3 = monthCalendar3.SelectionStart.ToShortDateString();
        }

        private string jour_de_semaine(DayOfWeek j)
        {
            switch (j)
            {
                case DayOfWeek.Sunday: return "Dimanche ";
                case DayOfWeek.Monday: return "Lundi ";
                case DayOfWeek.Tuesday: return "Mardi ";
                case DayOfWeek.Wednesday: return "Mercredi ";
                case DayOfWeek.Thursday: return "Jeudi ";
                case DayOfWeek.Friday: return "Vendredi ";
                case DayOfWeek.Saturday: return "Samedi ";
            }
            return " ";
        }
        private string Day_of_week(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Sunday: return "Sunday ";
                case DayOfWeek.Monday: return "Monday ";
                case DayOfWeek.Tuesday: return "Tuesday ";
                case DayOfWeek.Wednesday: return "Wednesday ";
                case DayOfWeek.Thursday: return "Thursday ";
                case DayOfWeek.Friday: return "Friday ";
                case DayOfWeek.Saturday: return "Saturday ";
            }
            return " ";
        }
        private double minimum_billed(double h)
        {
            if (h < 2) return 2;
            if (h < 3) return 3;
            double rounded_Minimum = h * .75;
            if (h * .75 < 3) return 3;
            return quarter_round(h * .75);
        }
        private double quarter_round(double q)
        {
            double nearestInt = Math.Truncate(q);
            double fractionalPart = q - nearestInt;

            if (fractionalPart < 0.125) return nearestInt;
            if (fractionalPart < 0.375) return nearestInt + 0.25;
            if (fractionalPart < 0.625) return nearestInt + 0.5;
            if (fractionalPart < 0.875) return nearestInt + 0.75;

            return nearestInt + 1.0;
        }


        private void checkBox_2men_CheckedChanged(object sender, EventArgs e)
        {
            // uncheck other options
            if (checkBox_3men.CheckState == CheckState.Checked)
                checkBox_3men.CheckState = CheckState.Unchecked;
            if (checkBox_4men.CheckState == CheckState.Checked)
                checkBox_4men.CheckState = CheckState.Unchecked;

            textBox_loadingTimeContract.Text = label_2men_loading_time.Text;
            textBox_UnloadingTimeContract.Text = label_2men_unloading_time.Text;
            textBox_HourlyRate.Text = "0";


        }

        private void checkBox_3men_CheckedChanged(object sender, EventArgs e)
        {
            // uncheck other options
            if (checkBox_2men.CheckState == CheckState.Checked)
                checkBox_2men.CheckState = CheckState.Unchecked;
            if (checkBox_4men.CheckState == CheckState.Checked)
                checkBox_4men.CheckState = CheckState.Unchecked;

            textBox_loadingTimeContract.Text = label_3men_loading_time.Text;
            textBox_UnloadingTimeContract.Text = label_3men_unloading_time.Text;
            textBox_HourlyRate.Text = "0";
        }

        private void checkBox_4men_CheckedChanged(object sender, EventArgs e)
        {
            // uncheck other options
            if (checkBox_3men.CheckState == CheckState.Checked)
                checkBox_3men.CheckState = CheckState.Unchecked;
            if (checkBox_2men.CheckState == CheckState.Checked)
                checkBox_2men.CheckState = CheckState.Unchecked;

            textBox_loadingTimeContract.Text = label_4men_loading_time.Text;
            textBox_UnloadingTimeContract.Text = label_4men_unloading_time.Text;
            textBox_HourlyRate.Text = "0";
        }


        private void button_contract_eng_Click(object sender, EventArgs e)
        {
            RTXTbox_Contrat.Text = "=🚚🏃🏘== 48H SPECIAL OFFER =🥇= ";
            RTXTbox_Contrat.Text += "\nMoving with X ";
            RTXTbox_Contrat.Text += "\nHello, " + s_client_name + " " + s_client_phn_number + " ";
            s_moving_date = Day_of_week(monthCalendar1.SelectionStart.DayOfWeek);
            s_moving_date += monthCalendar1.SelectionStart.ToShortDateString();
            s_moving_date += " " + textBox1_time.Text;
            if (checkBox1_lastavailability.Checked)
                s_moving_date += " Last availability.";

            switch ((monthCalendar1.SelectionStart.ToShortDateString()).Remove(0, 8))
            {
                case "01":
                case "02":
                    RTXTbox_Contrat.Text += "\nYou're moving at the beginning of the month, the busiest time!";
                    break;
                case "29":
                case "30":
                case "31":
                    RTXTbox_Contrat.Text += "\nYou're moving at the end of the month, the busiest time!";
                    break;
                default:
                    break;
            }

            RTXTbox_Contrat.Text += "\nIndications: " + label_flexible_date.Text + "---";
            RTXTbox_Contrat.Text += "\nDate";
            if (textBox2_time.Text != "" || textBox3_time.Text != "")
                RTXTbox_Contrat.Text += "s:\n";

            RTXTbox_Contrat.Text += "                 - " + s_moving_date;
            if (textBox2_time.Text != "")
            {
                s_moving_date2 = Day_of_week(monthCalendar2.SelectionStart.DayOfWeek);
                s_moving_date2 += monthCalendar2.SelectionStart.ToShortDateString();
                s_moving_date2 += " " + textBox2_time.Text;
                if (checkBox2_lastavailability.Checked)
                    s_moving_date2 += "  Last availability.";
                RTXTbox_Contrat.Text += "\n               Or else\n               - " + s_moving_date2;
            }
            if (textBox3_time.Text != "")
            {
                s_moving_date3 = Day_of_week(monthCalendar3.SelectionStart.DayOfWeek);
                s_moving_date3 += monthCalendar3.SelectionStart.ToShortDateString();
                s_moving_date3 += " " + textBox3_time.Text;
                if (checkBox3_lastavailability.Checked)
                    s_moving_date3 += "  Last availability.";
                RTXTbox_Contrat.Text += "\n               Or else\n               - " + s_moving_date3;
            }

            RTXTbox_Contrat.Text += "\n Orig: " + textBox_Starting_address.Text + "  " + textBox_Starting_address_floor.Text;
            RTXTbox_Contrat.Text += "\n Dest: " + textBox_Destination_address.Text + "  " + textBox_Destination_address_floor.Text;

            RTXTbox_Contrat.Text += "\n\n We offer you (";

            if (checkBox_2men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 2;
            if (checkBox_3men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 3;
            if (checkBox_4men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 4;
            RTXTbox_Contrat.Text += ") professional movers + ";
            RTXTbox_Contrat.Text += "(" + dnb_of_trucks + ") 22 feet truck";
            if (dnb_of_trucks > 1)
            {
                RTXTbox_Contrat.Text += "s";
            }
            RTXTbox_Contrat.Text += " (";
            RTXTbox_Contrat.Text += Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) + "% loaded). ";
            if (dnb_of_trucks > 1)
            {
                RTXTbox_Contrat.Text += " \n   or " + dnb_of_trucks + " trips with the same truck if possible.";
            }
            if (Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) > 85)
            {
                RTXTbox_Contrat.Text += "\n  (!) risk of exceeding truck capacity.";
            }




            double dheures = 0;
            RTXTbox_Contrat.Text += "\n\nMoving Estimator Pro 3.7 estimated as follows:";


            textBox_Distance.Text = textBox_Distance.Text.Replace('.', ',');
            dDistance = Math.Round((Double)Convert.ToDouble(textBox_Distance.Text), 2);


            textBox_InitialTimeContract.Text = textBox_InitialTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_InitialTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_InitialTimeContract.Text + "h Initial trip/Truck/Insurance and drive back";
            if (dDistance > 70)
                RTXTbox_Contrat.Text += " to MTL";
            RTXTbox_Contrat.Text += " after unloading";

            textBox_loadingTimeContract.Text = textBox_loadingTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_loadingTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_loadingTimeContract.Text + "h protecting your furniture and loading.";

            textBox_DriveTimeContract.Text = textBox_DriveTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_DriveTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_DriveTimeContract.Text + "h drive (assuming no traffic or weather condition).";

            textBox_UnloadingTimeContract.Text = textBox_UnloadingTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_UnloadingTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_UnloadingTimeContract.Text + "h unloading + invoicing + payment.";

            dheures = quarter_round(dheures);
            textBox_HourlyRate.Text = textBox_HourlyRate.Text.Replace('.', ',');
            dHourly_rate = Math.Round((Double)Convert.ToDouble(textBox_HourlyRate.Text), 2);
            RTXTbox_Contrat.Text += "\n     Total estimated hours " + dheures + "h x $" + dHourly_rate + "/h ( minimum " + minimum_billed(dheures) + "h):";

            dMoving_estimated_cost = 0;
            dMoving_estimated_cost += dheures * dHourly_rate;


            RTXTbox_Contrat.Text += "\nNo hidden fees!!! :)";

            //if plastic bags needed
            if (nPlastic_bags > 0)
            {
                RTXTbox_Contrat.Text += "\nPlastic mattress covers (" + nPlastic_bags + ") are included in the price.";
            }
            if (nWardrobe_boxes > 0)
            {
                RTXTbox_Contrat.Text += "\nWardrobe boxes (" + nWardrobe_boxes + ") are included in the price.";
            }
            //if distance sup 35 km
            if (dDistance > 35)
            {
                RTXTbox_Contrat.Text += "\nDistance traveled(" + dDistance + "km): Diesel costs are included in the price.";
                textBox_kmRate.Text = textBox_kmRate.Text.Replace('.', ',');
                RTXTbox_Contrat.Text += "\n    Hourly rate should be $" + (Math.Round((Double)dDistance * Math.Round((Double)Convert.ToDouble(textBox_kmRate.Text), 2) / dheures, 1) + dHourly_rate) + "/h";
            }

            RTXTbox_Contrat.Text += "\n Inventory: ==>\n";
            RTXTbox_Contrat.Text += s_inventory;
            RTXTbox_Contrat.Text += "\n<== Inventory\n";
            RTXTbox_Contrat.Text += s_notes;

            RTXTbox_Contrat.Text += "\n=== THIS OFFER EXPIRES IN 48H ===";

            RTXTbox_Contrat.Text += "\n\nTo accept our offer a $" + dHourly_rate + " deposit is required.";
            RTXTbox_Contrat.Text += "\nWe accept to x Or else by crédit card on X";
            RTXTbox_Contrat.Text += "\nWill be subtracted from your invoice total.";
            RTXTbox_Contrat.Text += "\nNon-refundable in the event of cancellation.";
            RTXTbox_Contrat.Text += "\n\n =====TERMS AND CONDITIONS:";
            RTXTbox_Contrat.Text += "\n 1. Please check THE INFORMATION YOU PROVIDED: THE INVENTORY *, the addresses and apartment #.";
            RTXTbox_Contrat.Text += "\n 2. Alcohol, Firearms, Jewelry and Chocolate: We do not carry bottles of alcoholic beverages / spirits, firearms, jewelry, and cash. Please transport them yourself or put them in well padded, closed boxes with unspecified contents.";
            RTXTbox_Contrat.Text += "\n 3. Inventory modification: The movers might refuse any significant inventory increase if we have to service other clients after your move. ";
            RTXTbox_Contrat.Text += "\n 4. An arrival time will be provided to first customers during the day. Movers will call 30 minutes in advance for subsequent clients. The client has to be being available to receive the movers within 30 minutes of their call, failing which the waiting time will be billed or the move may be canceled.";
            RTXTbox_Contrat.Text += "\n 5. Please prepare parking space for the truck at the origin and at the destination. The ideal is to come to an agreement with neighbors to park three cars one after the other. Also you can put chairs connected by a rope with signs on them indicating the date of the move.";
            RTXTbox_Contrat.Text += "\n 6. Invoicing is done in 15-minute increments. From the time of arrival until the truck is gone. We charge a minimum of 1 hour for the initial trip and a minimum of 2 hours of service. Unless otherwise agreed.";
            RTXTbox_Contrat.Text += "\n 7. We will cancel our service in the event of the presence of vermin, cockroaches, bedbugs or excessive dirtiness, or if the premises are deemed unsafe.";
            RTXTbox_Contrat.Text += "\n 8. Passing a piece of furniture through a balcony or a window is not covered by damage insurance and will be billed as an extra.";
            RTXTbox_Contrat.Text += "\n 9. Furniture over 140 kg (300 pounds) must be mentioned in advance and are invoiced as an extra: pianos, safes, pool tables, heavy table tops et more .";
            RTXTbox_Contrat.Text += "\n 10. We accept cash or Interac transfers.\n         3.5% fee applies with credit cards. \n         Company checks are also accepted, but personal checks are not.";
            RTXTbox_Contrat.Text += "\n         Payment may be required before unloading (art. 2056 and 2057 Code.civil.Qc.)";
            RTXTbox_Contrat.Text += "\n 11. Right of retention: The mover has the right to retain the goods transported until payment of the transport costs and, where applicable, reasonable storage costs (art. 2058 C.c.Q.).";
            RTXTbox_Contrat.Text += "\n 12. In the event of non-payment at the end of the service, the client agrees to be sued in civil matters and to pay three times (3x) the amount of the invoice in addition to legal fees and all costs relating to the prosecution.";
            RTXTbox_Contrat.Text += "\n 13. Damage insurance: The mover assumes no responsibility for:";
            RTXTbox_Contrat.Text += "\n         a) items valued over $ 3,000, unless an additional premium has been agreed in advance.";
            RTXTbox_Contrat.Text += "\n         b) tv sets over $ 500, unless they are in a special box (available on request for $ 35).";
            RTXTbox_Contrat.Text += "\n         c) the goods that the customer has packaged himself, those that he asks not to pack and those that he helps to handle.";
            RTXTbox_Contrat.Text += "\n         d) fragile Ikea / Structube type pressed wood furniture, unless they have been dismantled beforehand.";
            RTXTbox_Contrat.Text += "\n         e) very fragile goods such as windows, mirrors, marble, works of art, lamps and plants.";
            RTXTbox_Contrat.Text += "\n         f) the connection / disconnection of household appliances.";
            RTXTbox_Contrat.Text += "\n         g) the disassembly / assembly of furniture. Even though the movers do for most models, the time required is not in the estimate, the time varies depending on the model.";
            RTXTbox_Contrat.Text += "\n 14. Complaints:";
            RTXTbox_Contrat.Text += "\n         a) All complaints must be made by email within 3 days.";
            RTXTbox_Contrat.Text += "\n         b) No complaint will be considered before full payment for the services.";
            RTXTbox_Contrat.Text += "\n         c) No complaint can constitute a reason for non-payment.";
            RTXTbox_Contrat.Text += "\n         d) Any complaint for compensation must be documented with photos (our insurance requires it).";

            RTXTbox_Contrat.Text += "\n 15. Appliances:";
            RTXTbox_Contrat.Text += "\n         a) Washers, dishwashers and refrigerators should be disconnected beforehand and the water hoses separated or tied with duct tape.";
            RTXTbox_Contrat.Text += "\n         b) Refrigerators and freezers must be disconnected and emptied 24 hours before the arrival of our movers to avoid bad smelling leaks. We kindly ask you to clean the inside with bleach so that you can use them 2 hours after arriving at your destination.";
            RTXTbox_Contrat.Text += "\n         c) At the destination we do not install water pipes on appliances and will not be responsible for any water damage due to improper installation.";



        }

        private void button_contract_fr_Click(object sender, EventArgs e)
        {
            RTXTbox_Contrat.Text = "=🚚🏃🏘== OFFRE SPECIALE de 48H =🥇= ";
            RTXTbox_Contrat.Text += "\nDéménagement par X ";
            RTXTbox_Contrat.Text += "\nBonjour " + s_client_name + " " + s_client_phn_number + ", ";

            s_moving_date = jour_de_semaine(monthCalendar1.SelectionStart.DayOfWeek);
            s_moving_date += monthCalendar1.SelectionStart.ToShortDateString();
            s_moving_date += "        " + textBox1_time.Text;
            if (checkBox1_lastavailability.Checked)
                s_moving_date += " Dernière disponibilité.";

            RTXTbox_Contrat.Text += "\n Indications: " + label_flexible_date.Text + "---";
            RTXTbox_Contrat.Text += "\nDate";
            if (textBox2_time.Text != "" || textBox3_time.Text != "")
                RTXTbox_Contrat.Text += "s:\n";

            RTXTbox_Contrat.Text += "                 - " + s_moving_date;

            if (textBox2_time.Text != "")
            {
                s_moving_date2 = jour_de_semaine(monthCalendar2.SelectionStart.DayOfWeek);
                s_moving_date2 += monthCalendar2.SelectionStart.ToShortDateString();
                s_moving_date2 += "        " + textBox2_time.Text;
                if (checkBox2_lastavailability.Checked)
                    s_moving_date2 += " Dernière disponibilité.";

                RTXTbox_Contrat.Text += "\n                   Ou bien \n                 - " + s_moving_date2;

            }
            if (textBox3_time.Text != "")
            {
                s_moving_date3 = jour_de_semaine(monthCalendar3.SelectionStart.DayOfWeek);
                s_moving_date3 += monthCalendar3.SelectionStart.ToShortDateString();
                s_moving_date3 += "        " + textBox3_time.Text;
                if (checkBox3_lastavailability.Checked)
                    s_moving_date3 += " Dernière disponibilité.";

                RTXTbox_Contrat.Text += "\n                   Ou bien \n                 - " + s_moving_date3;

            }
            switch ((monthCalendar1.SelectionStart.ToShortDateString()).Remove(0, 8))
            {
                case "01":
                case "02":
                    RTXTbox_Contrat.Text += "\nVous déménagez le début du mois, la période la plus achalandée!";
                    break;
                case "29":
                case "30":
                case "31":
                    RTXTbox_Contrat.Text += "\nVous déménagez la fin du mois, la période la plus achalandée!";
                    break;
                default:
                    break;
            }
            RTXTbox_Contrat.Text += "\nDépart: " + textBox_Starting_address.Text + "  " + textBox_Starting_address_floor.Text;
            RTXTbox_Contrat.Text += "\nDest  : " + textBox_Destination_address.Text + "  " + textBox_Destination_address_floor.Text;


            RTXTbox_Contrat.Text += "\nOn vous offre (";

            if (checkBox_2men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 2;
            if (checkBox_3men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 3;
            if (checkBox_4men.CheckState == CheckState.Checked)
                RTXTbox_Contrat.Text += 4;

            dHourly_rate = Math.Round((Double)Convert.ToDouble(textBox_HourlyRate.Text), 2);
            RTXTbox_Contrat.Text += ") déménageurs professionnels + (";
            RTXTbox_Contrat.Text += dnb_of_trucks + ") camion";
            if (dnb_of_trucks > 1)
            {
                RTXTbox_Contrat.Text += "s ";
            }
            RTXTbox_Contrat.Text += " 22 pieds (à ";
            RTXTbox_Contrat.Text += Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) + "%).";
            if (dnb_of_trucks > 1)
            {
                RTXTbox_Contrat.Text += " \n Ou bien (" + dnb_of_trucks + ") voyages avec le même camion si possible";
            }
            RTXTbox_Contrat.Text += ".";
            if (Math.Ceiling(100 * dVolume / (39 * Math.Ceiling((Double)dVolume / 39))) > 85)
            {
                RTXTbox_Contrat.Text += "\n  (!) risque de débordement.";
            }

            double dheures = 0;
            RTXTbox_Contrat.Text += "\n\nMoving Estimator Pro 3.7 estime votre déménagement comme suit :";

            textBox_InitialTimeContract.Text = textBox_InitialTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_InitialTimeContract.Text);
            textBox_Distance.Text = textBox_Distance.Text.Replace('.', ',');
            dDistance = Math.Round((Double)Convert.ToDouble(textBox_Distance.Text), 2);

            RTXTbox_Contrat.Text += "\n     + " + textBox_InitialTimeContract.Text + "h Déplacement initial/Camion/Assur et retour";
            if (dDistance > 70)
                RTXTbox_Contrat.Text += " à MTL";
            RTXTbox_Contrat.Text += " après le travail.";

            textBox_loadingTimeContract.Text = textBox_loadingTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_loadingTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_loadingTimeContract.Text + "h protection des meubles et chargement.";

            textBox_DriveTimeContract.Text = textBox_DriveTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_DriveTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_DriveTimeContract.Text + "h de route (conditions normales, pas de congestion ni tempête).";

            textBox_UnloadingTimeContract.Text = textBox_UnloadingTimeContract.Text.Replace('.', ',');
            dheures += Convert.ToDouble(textBox_UnloadingTimeContract.Text);
            RTXTbox_Contrat.Text += "\n     + " + textBox_UnloadingTimeContract.Text + "h déchargement + facturation + paiement.";

            dheures = quarter_round(dheures);
            RTXTbox_Contrat.Text += "\n     Total heures estimées " + dheures;
            dMoving_estimated_cost = 0;

            dMoving_estimated_cost += dheures * dHourly_rate;
            textBox_HourlyRate.Text = textBox_HourlyRate.Text.Replace('.', ',');
            RTXTbox_Contrat.Text += "h x " + dHourly_rate + "$/h ( minimum " + minimum_billed(dheures) + "h):";

            RTXTbox_Contrat.Text += "\nAucun frais caché!!! :)";
            //if plastic bags needed
            if (nPlastic_bags > 0)
            {
                RTXTbox_Contrat.Text += "\nLes housses à matelas (" + nPlastic_bags + ") sont incluses dans le prix.";
            }
            if (nWardrobe_boxes > 0)
            {
                RTXTbox_Contrat.Text += "\nLes boîtes garde robes (" + nWardrobe_boxes + ") sont incluses dans le prix.";
            }
            //if distance sup 35 km
            if (dDistance > 35)
            {
                RTXTbox_Contrat.Text += "\nDistance totale parcourue (" + dDistance + "km): les frais Diesel sont inclus dans le prix";
                textBox_kmRate.Text = textBox_kmRate.Text.Replace('.', ',');
                RTXTbox_Contrat.Text += "\n    Taux horaire devrait être  $" + (Math.Round((Double)dDistance * Math.Round((Double)Convert.ToDouble(textBox_kmRate.Text), 2) / dheures, 1) + dHourly_rate) + "/h";
            }
            //RTXTbox_Contrat.Text += "\n Total approximatif** : $" + Math.Round(dMoving_estimated_cost, 2) + " + Taxes.";

            RTXTbox_Contrat.Text += "\n Inventaire: ==>\n";
            RTXTbox_Contrat.Text += s_inventory;
            RTXTbox_Contrat.Text += "\n<== Inventaire\n";
            RTXTbox_Contrat.Text += s_notes;

            RTXTbox_Contrat.Text += "\n=== CETTE OFFRE EXPIRE DANS 48H ===";
            RTXTbox_Contrat.Text += "\nPour accepter notre offre un acompte de $" + dHourly_rate + " est requis.";
            RTXTbox_Contrat.Text += "\nL'acompte est payable à x ou x. Ou encore par carte de crédit sur y";
            RTXTbox_Contrat.Text += "\nL’acompte sera soustrait du total de votre facture.";
            RTXTbox_Contrat.Text += "\nL’acompte est non remboursable en cas d'annulation. ";
            RTXTbox_Contrat.Text += "\nEn acceptant nos services ou en payant l’acompte, le client reconnaît avoir lu et compris les termes et conditions.";

            RTXTbox_Contrat.Text += "\n\n =====TERMES ET CONDITIONS=====";
            RTXTbox_Contrat.Text += "\nNous comptons sur votre bonne préparation: boîtes fermées, stationnement réservés, respect de l’inventaire etc.";
            RTXTbox_Contrat.Text += "\nÀ moins d’une entente préalable à prix fixe, cette estimation est à titre indicatif uniquement, C'est une facturation horaire";
            RTXTbox_Contrat.Text += "\nDe nombreux facteurs affectent le temps de service: la distance à marcher, les portes à démonter, le nombre d'étages et la présence d'un ascenseur et autres...";
            RTXTbox_Contrat.Text += "\nLe calculateur ne peut estimer et n’inclut pas le temps d'assemblages/désassemblages de meubles, si nécessaire, nos déménageurs peuvent le faire pour la plupart des modèles.";

            RTXTbox_Contrat.Text += "\n\n 1. Vérification : *VÉRIFIEZ LES INFORMATIONS DE LA FICHE DE RÉSERVATION, NOTAMMENT L'INVENTAIRE*, les adresses et # d'appartement, ainsi que la présence d'un # de téléphone où vous serez rejoignable.";
            RTXTbox_Contrat.Text += "\n 2. Alcool, armes à feu, bijoux et chocolat: Nous ne transportons pas les bouteilles de boissons alcoolisées / spiritueux, les armes à feu, les bijoux et l'argent comptant. Nous vous prions de les transporter vous-même ou de les mettre dans des boîtes bien rembourrées, fermées et dont le contenu est non spécifié.";
            RTXTbox_Contrat.Text += "\n 3. Modification d'inventaire : Le déménageur se réserve le droit de refuser tout dépassement significatif d'inventaire, afin de respecter nos autres engagements. Dans le cas d'une réduction significative n'ayant pas été annoncée au moins une semaine à l'avance, 75% du temps estimé sera facturé.";
            RTXTbox_Contrat.Text += "\n 4. Heure d'arrivée : Une heure d’arrivée sera fournie aux premiers clients la journée. Les déménageurs appelleront 30 minutes à l’avance pour les clients suivants. Une heure approximative à titre indicatif sera fournie. Le client est responsable d'être disponible pour recevoir les déménageurs dans les 30 minutes suivant leur appel, à défaut de quoi le temps d'attente lui sera facturé ou le déménagement pourrait être annulé.";
            RTXTbox_Contrat.Text += "\n 5. Stationnement: La veille du déménagement, pensez à réserver un espace pour le camion à l'origine et à la destination. L'idéal est de s'entendre avec des voisins pour stationner trois voitures une à la suite de l'autre. Aussi vous pouvez mettre des chaises reliées par une corde avec des pancartes dessus indiquant la date du déménagement.";
            RTXTbox_Contrat.Text += "\n 6. Facturation : La facturation se fait par tranches de 15 minutes. Depuis le temps d'arrivée jusqu'à ce que le camion soit parti.Nous facturons un minimum de 1 heure pour le déplacement initial et un minimum de 2 heures de service. À moins d’une autre entente préalable.";
            RTXTbox_Contrat.Text += "\n 7. Résiliation du contrat : Le déménageur peut annuler le présent contrat en cas de présence de vermine, coquerelles, punaises de lit ou malpropreté excessive, ou si les accès sont jugés non sécuritaires.";
            RTXTbox_Contrat.Text += "\n 8. Palantage : i.e passer un meuble par un balcon ou une fenêtre n'est pas couvert par l'assurance dommage et sera facturé comme extra.";
            RTXTbox_Contrat.Text += "\n 9. Poids maximal : les meubles de plus de 140 kg (300 livres) doivent être mentionnés en avance et sont facturés en extra : Pianos, coffres forts, tables de billards.";
            RTXTbox_Contrat.Text += "\n 10. Paiement : Nous acceptons argent comptant ou transfert Interac." +
                                    "\n         Pour les cartes de crédit des frais de 3,5% s'appliquent, les taxes sont en sus." +
                                    "\n         Les chèques de compagnies sont aussi acceptés mais pas les chèques personnels." +
                                    "\n         Le paiement peut être exigé avant le déchargement (art. 2056 et 2057 Code.civil.Qc.)";
            RTXTbox_Contrat.Text += "\n 11. Droit de rétention : Le déménageur a le droit de retenir les biens transportés jusqu'au paiement des frais de transport et, le cas échéant, des frais raisonnables d'entreposage(art. 2058 C.c.Q.).";

            RTXTbox_Contrat.Text += "\n 12. L’obligation de paiement: en cas de non-paiement à la fin du service, le client accepte d'être poursuivi au civil et payer trois fois (3x) le montant de la facture en plus des frais d’avocats et tout frais relatif à la poursuite.";
            RTXTbox_Contrat.Text += "\n 13. Assurance dommage: Le déménageur n'assume aucune responsabilité pour:";
            RTXTbox_Contrat.Text += "\n         a) les objets d'une valeur supérieure à 3000$, à moins qu'une surprime ait été convenue à l'avance.";
            RTXTbox_Contrat.Text += "\n         b) les téléviseurs d'une valeur supérieure à 500$, à moins d'être dans une boîte prévue à cet effet(disponible sur demande pour 35$).";
            RTXTbox_Contrat.Text += "\n         c) les biens que le client a emballés lui-même, ceux qu'il demande de ne pas emballer et ceux qu'il aide à manipuler.";
            RTXTbox_Contrat.Text += "\n         d) les meubles fragiles en aggloméré mélaminé de type Ikea / Structube  à moins qu'ils soient démontés.";
            RTXTbox_Contrat.Text += "\n         e) les biens très fragiles tels que vitres, miroirs, marbre, œuvres d'art, lampes et plantes.";
            RTXTbox_Contrat.Text += "\n         f) le branchement/ débranchement d'appareils électroménagers.";
            RTXTbox_Contrat.Text += "\n         g) le désassemblage/ assemblage de meubles. Même si les déménageurs le font, le temps requis n'est pas dans l'estimation, le temps varie selon ls modèles.";

            RTXTbox_Contrat.Text += "\n 14. Réclamations:";
            RTXTbox_Contrat.Text += "\n         a) Toute réclamation doit être faite par courriel dans les 3 jours.";
            RTXTbox_Contrat.Text += "\n         b) Aucune plainte ne sera considérée avant le paiement complet des services.";
            RTXTbox_Contrat.Text += "\n         c) Aucune plainte ne peut constituer une raison de non-paiement.";
            RTXTbox_Contrat.Text += "\n         d) Toute plainte pour dédommagement doit être accompagnée de photos(nos assurances l’exigent).";

            RTXTbox_Contrat.Text += "\n 15. Appareils Électroménagers:";
            RTXTbox_Contrat.Text += "\n         a) Laveuses, lave - vaisselles et réfrigérateurs doivent être déconnectés au préalable et les tuyaux d’eau séparés ou attachés avec du ruban adhésif.";
            RTXTbox_Contrat.Text += "\n         b) Les réfrigérateurs et congélateurs doivent être déconnectés et vidés 24 h avant l’arrivée de notre équipe pour éviter les fuites à mauvaises odeurs. Nous vous prions de nettoyer l’intérieur à l’eau de javel pour que vous puissiez les utiliser 2 heures après votre arrivée à destination.";
            RTXTbox_Contrat.Text += "\n         c) À la destination nous n’installons pas Les tuyaux d’eau sur Les électroménagers et ne seront pas responsables de tout dégât d’eau dû À une mauvaise installation.";


        }
        private void reset()
        {
            // starts contract from scratch 
            RTXTbox_Contrat.Text = "";
            RTXTbox_Contrat.Text = "";
            s_client_name = "";
            s_client_phn_number = "";
            s_client_email = "";
            textBox_Starting_address_floor.Text = " starting address floor";
            textBox_Destination_address_floor.Text = " destination address floor";
            s_moving_date = "";
            s_moving_date2 = "";
            s_moving_date3 = "";
            s_inventory = "";
            s_notes = "";
            RTXTbox_Contrat.Text = "";
            textBox_Starting_address.Text = " staring address";
            textBox_Destination_address.Text = " destination address";
            dLoading_time = 0;
            label_2men_loading_time.Text = "0";
            label_3men_loading_time.Text = "0";
            label_4men_loading_time.Text = "0";
            textBox_loadingTimeContract.Text = "0";
            dUnLoading_time = 0;
            label_2men_unloading_time.Text = "0";
            label_3men_unloading_time.Text = "0";
            label_4men_unloading_time.Text = "0";
            textBox_UnloadingTimeContract.Text = "0";
            dVolume = 0;
            dDistance = 0;
            dHourly_rate = 0;
            dMoving_estimated_cost = 0;
            dnb_of_trucks = 0;
            nPlastic_bags = 0;
            nWardrobe_boxes = 0;
            textBox1_time.Text = "";
            textBox2_time.Text = "";
            textBox3_time.Text = "";
            textBox_Distance.Text = "0";
            textBox_HourlyRate.Text = "0";
            textBox_InitialTimeContract.Text = "1";
            textBox_DriveTimeContract.Text = "0";
            checkBox_2men.CheckState = CheckState.Unchecked;
            checkBox_3men.CheckState = CheckState.Unchecked;
            checkBox_4men.CheckState = CheckState.Unchecked;
            textBox1_time.Text = "";
            textBox2_time.Text = "";
            textBox3_time.Text = "";
            textBox_Destination_source.Text = "";
            checkBox1_lastavailability.CheckState = CheckState.Unchecked;
            checkBox2_lastavailability.CheckState = CheckState.Unchecked;
            checkBox3_lastavailability.CheckState = CheckState.Unchecked;
        }
        private void button_reset_Click(object sender, EventArgs e)
        {
            reset();
            Move_description.Text = "Paste email text here...";
        }

        private void Move_description_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
