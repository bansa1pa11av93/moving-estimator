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
                // divides text into lines
                string[] s_Lines = Move_description.Text.Split(new string[] { "\n\n" }, StringSplitOptions.None);
                int n_Line = 0;
                // french or english  form ?
                //French form
                if (Move_description.Text.Contains("ÉTAPE 1 - INFORMATIONS CLIENT"))
                {
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

                        if (key.Contains("NOM ET PRÉNOM"))
                        {
                            s_client_name = value;
                        }
                        else if (key.Contains("TITRE"))
                        {
                            string title_and_name = value;
                            title_and_name += " " + s_client_name;
                            s_client_name = title_and_name;
                        }
                        if (key.Contains("COURRIEL"))
                        {
                            s_client_email = value;
                        }
                        if (key.Contains("TÉLÉPHONE"))
                        {
                            s_client_phn_number = value;
                        }
                        if (key.Contains("DATE") && !key.Contains("FLEXIBLE"))
                        {
                            //delete date
                            s_moving_date = value;
                            DateTime dt1 = new DateTime(int.Parse(s_moving_date.Substring(0, 4)), int.Parse(s_moving_date.Substring(5, 2)), int.Parse(s_moving_date.Substring(8, 2)));
                            monthCalendar1.SetDate(dt1);
                            monthCalendar2.SetDate(dt1);
                            monthCalendar3.SetDate(dt1);

                        }
                        if (key.Contains("DATE FLEXIBLE ?"))
                        {
                            //DATE FLEXIBLE ?	DATE EXACTE
                            label_flexible_date.Text = value;
                        }
                        if (key.Contains("ADRESSE DE DÉPART + VILLE"))
                        {
                            textBox_Starting_address.Text = value;
                        }
                        if (key.Contains("ADRESSE DESTINATION + VILLE"))
                        {
                            //delete ADRESSE DE DÉPART + VILLE
                            textBox_Destination_address.Text = value;
                        }
                        if (key.Contains("ÉTAGE ADRESSE DE DÉPART"))
                        {
                            //delete ADRESSE DE DÉPART
                            textBox_Starting_address_floor.Text = value;
                        }
                        if (key.Contains("ÉTAGE ADRESSE DE DESTINATION"))
                        {
                            //delete ADRESSE DE DÉPART
                            textBox_Destination_address_floor.Text = value;
                        }
                        if (key.Contains("RÉFRIGÉRATEUR"))
                        {
                            if (!key.Contains("PETIT") && !key.Contains("GRAND"))// both previous ifs were false
                            {
                                //RÉFRIGÉRATEUR	1
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += "x RÉFRIGÉRATEUR; ";
                                    dVolume += n_items;
                                    dLoading_time += n_items * 0.15;
                                    dUnLoading_time += n_items * 0.1;
                                }
                            }
                            if (key.Contains("GRAND"))
                            {
                                //GRAND RÉFRIGÉRATEUR	1 
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items; // number of fridges
                                    s_inventory += "x GRAND RÉFRIGÉRATEUR; ";
                                    dVolume += n_items * 1.3;
                                    dLoading_time += n_items * 0.2;
                                    dUnLoading_time += n_items * 0.15;
                                }
                            }
                            if (key.Contains("PETIT"))
                            {
                                //PETIT RÉFRIGÉRATEUR 1
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += "x PETIT RÉFRIGÉRATEUR; ";
                                    dVolume += n_items * 0.5;
                                    dLoading_time += n_items * 0.15;
                                    dUnLoading_time += n_items * 0.1;
                                }
                            }
                        }// fridges
                        if (key.Contains("GROS CONGÉLATEUR"))
                        {
                            //GROS CONGÉLATEUR    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x GROS CONGÉLATEUR; ";

                                dVolume += n_items;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.12;
                            }
                        }
                        if (key.Contains("CONGÉLATEUR MOYEN"))
                        {
                            //CONGÉLATEUR MOYEN   1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CONGÉLATEUR MOYEN; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("CUISINIÈRES - FOUR/POÊLE"))
                        {
                            //CUISINIÈRES - FOUR / POÊLE    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CUISINIÈRES - FOUR / POÊLE; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("LAVE VAISSELLE"))
                        {
                            //LAVE VAISSELLE    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LAVE VAISSELLE; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("SÉCHEUSE") && !key.Contains("SUPERPOSÉES"))
                        {
                            //SÉCHEUSE    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SÉCHEUSE; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("LAVEUSE") && !key.Contains("SUPERPOSÉES"))
                        {
                            //LAVEUSE    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LAVEUSE; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("Sécheuse au dessus laveuse"))
                        {
                            //LAVEUSE - SECHEUSE SUPERPOSÉES ?	Sécheuse au dessus laveuse
                            s_inventory += " Sécheuse au dessus laveuse; ";
                            dLoading_time += 0.1;
                            dUnLoading_time += 0.1;
                        }
                        if (key.Contains("BASE DE LIT KING"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BASE DE LIT KING; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.2;
                                dUnLoading_time += n_items * 0.13;
                            }
                        }
                        if (key.Contains("BASE DE LIT QUEEN"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BASE DE LIT QUEEN; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.11;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("BASE DE LIT DOUBLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BASE DE LIT DOUBLE; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.11;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("BASE DE LIT SIMPLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BASE DE LIT SIMPLE; ";

                                dVolume += n_items * .25;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("MATELAS KING"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += 2 * n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x MATELAS KING; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("MATELAS QUEEN"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x MATELAS QUEEN; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("MATELAS DOUBLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x MATELAS DOUBLE; ";

                                dVolume += n_items * .35;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("MATELAS SIMPLE"))
                        {
                            Console.WriteLine(s_Lines[n_Line]);
                            //MATELAS SIMPLE(PETIT)
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x MATELAS SIMPLE(PETIT); ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("SOMMIER KING"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x SOMMIER KING; ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("SOMMIER SIMPLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SOMMIER SIMPLE; ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("SOMMIER QUEEN"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SOMMIER QUEEN; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("SOMMIER DOUBLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SOMMIER DOUBLE; ";

                                dVolume += n_items * .25;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("COMMODE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x COMMODE; ";
                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("TABLE DE CHEVET"))
                        {
                            //TABLE DE CHEVET 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TABLE DE CHEVET; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.07;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("(2 PORTES)"))
                        {
                            //ARMOIRE(2 PORTES)  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x ARMOIRE(2 PORTES); ";
                                dVolume += n_items * .8;
                                dLoading_time += n_items * 0.12;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("(1 PORTE)"))
                        {
                            //ARMOIRE(1 PORTE)  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x ARMOIRE(1 PORTE); ";
                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("BERCEAU"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BERCEAU; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.08;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("CAUSEUSE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CAUSEUSE(DIVAN 2 PLACES); ";

                                dVolume += n_items * 1.0;
                                dLoading_time += n_items * 0.12;
                                dUnLoading_time += n_items * 0.06;
                            }
                        }
                        if (key.Contains("CANAPÉ"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SOFA/CANAPÉ (3PLACES); ";

                                dVolume += n_items * 1.3;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.10;
                            }
                        }
                        if (key.Contains("FAUTEUIL"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x FAUTEUIL; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("MEUBLE TÉLÉ"))
                        {
                            if (key.Contains("GRAND"))
                            {
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x MEUBLE TÉLÉ(GRAND);  ";
                                    dVolume += n_items * 1.2;
                                    dLoading_time += n_items * 0.3;
                                    dUnLoading_time += n_items * 0.2;
                                }
                            }
                            if (key.Contains("MOYEN"))
                            {
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x MEUBLE TÉLÉ(MOYEN/ PETIT); ";
                                    dVolume += n_items * 0.4;
                                    dLoading_time += n_items * 0.1;
                                    dUnLoading_time += n_items * 0.05;
                                }
                            }
                        }

                        if (key.Contains("TÉLÉVISEUR"))
                        {
                            if (key.Contains("GRAND"))
                            {// TÉLÉVISEUR(GRAND) 2
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x TÉLÉVISEUR(GRAND);  ";
                                    dVolume += n_items * 0.3;
                                    dLoading_time += n_items * 0.1;
                                    dUnLoading_time += n_items * 0.1;
                                }
                            }
                            if (key.Contains("MOYEN"))
                            {
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x TÉLÉVISEUR (MOYEN/PETIT);  ";
                                    dVolume += n_items * 0.1;
                                    dLoading_time += n_items * 0.05;
                                    dUnLoading_time += n_items * 0.05;
                                }
                            }
                        }

                        if (key.Contains("TABLE DE CAFÉ, DE BOUT"))
                        {//TABLE DE CAFÉ, DE BOUT  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TABLE DE CAFÉ, DE BOUT; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("TABLES À MANGER OU DE TERRASSE"))
                        {//TABLES À MANGER  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TABLES À MANGER OU DE TERRASSE; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("CHAISES"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CHAISES; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("BIBILIOTHEQUE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BIBILIOTHEQUE; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("ARMOIRE DE DOSSIER"))
                        {
                            //ARMOIRE DE DOSSIER À TIROIR 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x ARMOIRE DE DOSSIER À TIROIR; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("DESSERTE, HUCHE, CABINETS"))
                        {
                            //DESSERTE, HUCHE, CABINETS   1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x DESSERTE, HUCHE, CABINETS; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("MIROIRS - CADRES"))
                        {
                            //MIROIRS - CADRES    2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x MIROIRS - CADRES; ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("GRAND TAPIS"))
                        {
                            //GRAND TAPIS 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x GRAND TAPIS; ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains("TAPIS ( PETIT OU MOYEN )"))
                        {
                            //TAPIS ( PETIT OU MOYEN )	1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TAPIS ( PETIT OU MOYEN ); ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("LAMPES ET ABAT-JOURS"))
                        {
                            //LAMPE 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LAMPES ET ABAT-JOURS; ";
                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("COFFRE FORT"))
                        {
                            if (key.Contains("Petit"))
                            {
                                s_inventory += " COFFRE FORT Petit; ";
                                dVolume += .4;
                                dLoading_time += 0.04;
                                dUnLoading_time += 0.03;
                            }
                            if (key.Contains("Moyen"))
                            {
                                s_inventory += "---- COFFRE FORT Moyen ( maximum 300 lbs, sinon 1h extra); ----";
                                dVolume += .6;
                                dLoading_time += 0.4;
                                dUnLoading_time += 0.2;
                            }
                            if (key.Contains("Grand"))
                            {
                                s_inventory += "---- COFFRE FORT Grand ( maximum 300 lbs, sinon 1h extra); ----";
                                dVolume += 1.2;
                                dLoading_time += 1.5;// 1 h exrtra
                                dUnLoading_time += .5;
                            }
                        }
                        if (key.Contains("PIANO"))
                        {
                            if (key.Contains("Petit"))
                            {
                                s_inventory += " PIANO Petit; ";
                                dVolume += .4;
                                dLoading_time += 0.04;
                                dUnLoading_time += 0.03;
                            }
                            if (key.Contains("Moyen"))
                            {
                                s_inventory += "---- PIANO Moyen ( maximum 300 lbs, sinon 1h extra); ----";
                                dVolume += .6;
                                dLoading_time += 1.4;
                                dUnLoading_time += 0.2;
                            }
                            if (key.Contains("Grand"))
                            {
                                s_inventory += "---- PIANO Grand ( maximum 300 lbs, sinon 2h extra); ----";
                                dVolume += 1.2;
                                dLoading_time += 2.5;// 2 h exrtra
                                dUnLoading_time += .5;
                            }
                        }
                        if (key.Contains("BARBECUE"))
                        {
                            //BARBECUE	2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BARBECUE; ";
                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.04;
                            }
                        }
                        if (key.Contains("BICYCLETTES / VÉLOS"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x VÉLO; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("VALISES"))
                        {
                            //VALISES	2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x VALISES; ";
                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("PNEUS"))
                        {
                            //PNEUS   13
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x PNEUS; ";

                                dVolume += n_items * .15;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("TAPIS ROULANT"))
                        {
                            //TAPIS ROULANT   1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TAPIS ROULANT; ";
                                dVolume += n_items * .8;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.15;
                            }
                        }
                        if (key.Contains("VÉLOS STATIONNAIRES"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x VÉLOS STATIONNAIRES; ";
                                dVolume += n_items;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains("TABLE DE BILLARD"))
                        {
                            //TABLE DE BILLARD    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += "\n---- " + n_items + " x TABLE DE BILLARD; ----\n";

                                dVolume += n_items * 15;
                                dLoading_time += n_items * 3;
                                dUnLoading_time += n_items * 3;
                            }
                        }
                        if (key.Contains("VOS BOITES (APPROXIMATIF)"))
                        {
                            //BOITES(APPROXIMATIF)   250
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " de vos BOITES(APPROXIMATIF);";

                                dVolume += n_items * .15;
                                dLoading_time += n_items * .015;
                                dUnLoading_time += n_items * .01;
                            }
                        }
                        if (key.Contains("BOITES GARDE-ROBE (4 FOURNIES)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                nWardrobe_boxes += n_items;
                                s_inventory += " x BOITE GARDE-ROBE(4 FOURNIES);";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * .075;
                                dUnLoading_time += n_items * .03;
                            }
                        }
                        if (key.Contains("PLUS DE PRÉCISIONS"))
                        {
                            //PLUS DE PRÉCISIONS 
                            s_Lines[n_Line] = value;
                            s_notes += "\nNotes client:\n ";
                            s_notes += s_Lines[n_Line] + " \n";
                        }
                        if (key.Contains("COMMENT AVEZ-VOUS"))
                        {
                            s_notes += " \n" + s_Lines[n_Line];
                            textBox_Destination_source.Text = value;
                        }
                        n_Line++;
                        n_items = 0;
                    }
                }// french form
                // English form
                if (Move_description.Text.Contains("STEP 1 - CUSTOMER INFORMATION"))
                {
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

                        if (key.Contains("LEGAL NAME"))
                        {
                            // delete FIRST NAME
                            s_client_name += value;
                            // add separator
                            s_client_name += ' ';
                        }
                        if (key.Contains("TITLE"))
                        {
                            //delete TITLE
                            string title_and_name = value;
                            title_and_name += " " + s_client_name;
                            s_client_name = title_and_name;

                        }
                        if (key.Contains("E-MAIL"))
                        {
                            //delete E-MAIL
                            s_client_email = value;
                        }
                        if (key.Contains("PHONE#"))
                        {
                            //delete PHONE
                            s_client_phn_number = value;
                        }
                        if (key.Contains("MOVING DATE"))
                        {
                            //delete DATED
                            s_moving_date = value;
                            label_flexible_date.Text = s_moving_date;
                            DateTime dt1 = new DateTime(int.Parse(s_moving_date.Substring(0, 4)), int.Parse(s_moving_date.Substring(5, 2)), int.Parse(s_moving_date.Substring(8, 2)));

                            monthCalendar1.SetDate(dt1);
                            monthCalendar2.SetDate(dt1);
                            monthCalendar3.SetDate(dt1);
                        }
                        if (key.Contains("FLEXIBLE DATE?"))
                        {
                            label_flexible_date.Text = value;
                        }
                        if (key.Contains("DEPARTURE ADDRESS + CITY"))
                        {
                            //delete DEPARTURE ADDRESS + CITY
                            textBox_Starting_address.Text = value;
                        }
                        if (key.Contains("DESTINATION ADDRESS + CITY"))
                        {
                            //delete DESTINATION ADDRESS + CITY
                            textBox_Destination_address.Text = value;
                        }
                        if (key.Contains("FLOOR at DEPARTURE ADDRESS"))
                        {
                            //FLOOR DEPARTURE ADDRESS
                            textBox_Starting_address_floor.Text = value;
                        }
                        if (key.Contains("FLOOR at DESTINATION ADDRESS"))
                        {
                            //delete FLOOR DESTINATION ADDRESS
                            textBox_Destination_address_floor.Text = value;
                        }
                        if (key.Contains("REFRIGERATOR"))
                        {
                            if (!key.Contains("SMALL") && !key.Contains("LARGE"))// both previous ifs were false
                            {
                                //REFRIGERATOR	1
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += "x REFRIGERATOR; ";
                                    dVolume += n_items;
                                    dLoading_time += n_items * 0.15;
                                    dUnLoading_time += n_items * 0.1;
                                }
                            }
                            if (key.Contains("LARGE"))
                            {
                                //LARGE REFRIGERATOR	1 
                                s_Lines[n_Line] = value;// delete "LARGE REFRIGERATOR"
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items; // number of LARGE REFRIGERATOR
                                    s_inventory += "x LARGE REFRIGERATOR; ";
                                    dVolume += n_items * 1.3;
                                    dLoading_time += n_items * 0.2;
                                    dUnLoading_time += n_items * 0.15;
                                }
                            }
                            if (key.Contains("SMALL"))
                            {
                                //SMALL REFRIGERATOR	1
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += "x SMALL REFRIGERATOR; ";
                                    dVolume += n_items * 0.5;
                                    dLoading_time += n_items * 0.15;
                                    dUnLoading_time += n_items * 0.1;
                                }
                            }
                        }// fridges
                        if (key.Contains("LARGE FREEZER"))
                        {
                            //LARGE FREEZER   1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LARGE FREEZER; ";

                                dVolume += n_items;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.12;
                            }
                        }
                        if (key.Contains("MEDIUM FREEZER"))
                        {
                            //MEDIUM FREEZER   1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x MEDIUM FREEZER; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("COOKERS - OVEN / STOVE"))
                        {
                            //COOKERS - OVEN / STOVE    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x COOKERS - OVEN / STOVE; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("DISHWASHER"))
                        {
                            //DISHWASHER    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x DISHWASHER; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("DRYER") && !key.Contains("STACKED WASHER - DRYER"))
                        {
                            //DRYER    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x DRYER; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("WASHER") && !key.Contains("STACKED WASHER - DRYER"))
                        {
                            //WASHER    1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x WASHER; ";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("Dryer above washer"))
                        {
                            s_inventory += " Dryer above washer; ";
                            dLoading_time += 0.1;
                            dUnLoading_time += 0.1;
                        }
                        if (key.Contains("KING BED BASE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x KING BED BASE; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.2;
                                dUnLoading_time += n_items * 0.13;
                            }
                        }
                        if (key.Contains("QUEEN BED BASE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x QUEEN BED BASE; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.11;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("DOUBLE BED BASE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x DOUBLE BED BASE; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.11;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("SINGLE BED BASE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SINGLE BED BASE; ";

                                dVolume += n_items * .25;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.07;
                            }
                        }
                        if (key.Contains("KING MATTRESS"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += 2 * n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x KING MATTRESS; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("QUEEN MATTRESS"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x QUEEN MATTRESS; ";

                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("DOUBLE MATTRESS"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {

                                s_inventory += n_items;
                                s_inventory += " x DOUBLE MATTRESS; ";

                                dVolume += n_items * .35;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("SINGLE MATTRESS (SMALL)"))
                        {
                            //SINGLE MATTRESS (SMALL)
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SINGLE MATTRESS (SMALL); ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("BOXSPRING KING"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BOXSPRING KING; ";
                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("BOXSPRING SINGLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BOXSPRING SINGLE; ";
                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("BOXSPRING QUEEN"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BOXSPRING QUEEN; ";
                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("BOXSPRING DOUBLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            nPlastic_bags += n_items;
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BOXSPRING DOUBLE; ";
                                dVolume += n_items * .25;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("COMMODE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x COMMODE; ";
                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("NIGHTSTAND"))
                        {
                            //TABLE DE CHEVET 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x NIGHTSTAND; ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.07;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("WARDROBE (2 DOORS)"))
                        {
                            //ARMOIRE(2 PORTES)  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x WARDROBE (2 DOORS); ";
                                dVolume += n_items * .8;
                                dLoading_time += n_items * 0.12;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("WARDROBE (1 DOOR)"))
                        {
                            //WARDROBE (1 DOOR)  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x WARDROBE (1 DOOR); ";

                                dVolume += n_items * .3;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("CRADLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CRADLE; ";
                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.08;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("LOVESEAT (2-SEATER SOFA)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LOVESEAT (2-SEATER SOFA); ";

                                dVolume += n_items * 1.0;
                                dLoading_time += n_items * 0.12;
                                dUnLoading_time += n_items * 0.06;
                            }
                        }
                        if (key.Contains("SOFA (3-SEATER)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SOFA (3-SEATER); ";
                                dVolume += n_items * 1.3;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.10;
                            }
                        }
                        if (key.Contains("ARMCHAIR"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x ARMCHAIR; ";
                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }

                        if (key.Contains("TV STAND"))
                        {
                            if (key.Contains("LARGE"))
                            {
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x TV STAND (LARGE); ";
                                    dVolume += n_items * 1.2;
                                    dLoading_time += n_items * 0.3;
                                    dUnLoading_time += n_items * 0.2;
                                }
                            }
                            if (key.Contains("MEDIUM/SMALL"))
                            {
                                s_Lines[n_Line] = value;
                                n_items = int.Parse(s_Lines[n_Line]);
                                if (n_items > 0)
                                {
                                    s_inventory += n_items;
                                    s_inventory += " x TV STAND (MEDIUM/SMALL); ";
                                    dVolume += n_items * 0.4;
                                    dLoading_time += n_items * 0.1;
                                    dUnLoading_time += n_items * 0.05;
                                }
                            }
                        }

                        if (key.Contains("TV (LARGE)"))
                        {// TÉLÉVISEUR(GRAND) 2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TV (LARGE);  ";
                                dVolume += n_items * 0.3;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains("TV (MEDIUM/SMALL)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TV (MEDIUM/SMALL);  ";
                                dVolume += n_items * 0.1;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }

                        if (key.Contains("COFFEE AND SIDE TABLES"))
                        {//COFFEE AND SIDE TABLES  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x COFFEE OR SIDE TABLES; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.05;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("DINING OR PATIO TABLES"))
                        {//DINING OR PATIO TABLES  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TABLES; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.05;
                            }
                        }
                        if (key.Contains("CHAIRS"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x CHAIRS; ";
                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("LIBRARY"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LIBRARY; ";
                                dVolume += n_items * .4;
                                dLoading_time += n_items * 0.03;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("DRAWER FOLDER CABINET"))
                        {
                            //DRAWER FOLDER CABINET 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x ARMOIRE DE DOSSIER À TIROIR; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.03;
                            }
                        }
                        if (key.Contains("DESSERT, HUCHE, CABINETS"))
                        {
                            //DESSERT, HUCHE, CABINETS  1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x DESSERT, HUCHE, CABINETS; ";
                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.08;
                            }
                        }
                        if (key.Contains("MIRRORS - FRAMES"))
                        {
                            //MIRRORS - FRAMES    2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x MIRRORS - FRAMES; ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("LARGE CARPET"))
                        {
                            //LARGE CARPET 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LARGE CARPET; ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains("SMALL - MEDIUM CARPET"))
                        {
                            //LARGE CARPET 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SMALL - MEDIUM CARPET; ";
                                dVolume += n_items * .1;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("LAMPS AND LAMP SHADES"))
                        {
                            //LAMPE 1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x LAMPS AND LAMP SHADES; ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("SAFE"))
                        {
                            if (key.Contains("Small"))
                            {
                                s_inventory += " Small SAFE; ";
                                dVolume += .4;
                                dLoading_time += 0.04;
                                dUnLoading_time += 0.03;
                            }
                            if (key.Contains("Average"))
                            {
                                s_inventory += "---- MEDIUM SAFE (maximum 300 lbs, else 1 hour extra); ----";
                                dVolume += .6;
                                dLoading_time += 0.4;
                                dUnLoading_time += 0.2;
                            }
                            if (key.Contains("Big"))
                            {
                                s_inventory += "---- BIG SAFE (maximum 300 lbs, else 1 hour extra); ----";
                                dVolume += 1.2;
                                dLoading_time += 1.5;// 1 h exrtra
                                dUnLoading_time += 0.5;
                            }
                        }
                        if (key.Contains("PIANO"))
                        {
                            if (key.Contains("Small"))
                            {
                                s_inventory += " SMALL PIANO; ";
                                dVolume += .4;
                                dLoading_time += 0.04;
                                dUnLoading_time += 0.03;
                            }
                            if (key.Contains("Average"))
                            {
                                s_inventory += "---- Average PIANO (maximum 300 lbs, else 1 hour extra); ----";
                                dVolume += .6;
                                dLoading_time += 0.4;
                                dUnLoading_time += 0.2;
                            }
                            if (key.Contains("Big"))
                            {
                                s_inventory += "---- Big PIANO ( maximum 300 lbs, else 1 hour extra); ----";
                                dVolume += 1.2;
                                dLoading_time += 1.5;// 1 h exrtra
                                dUnLoading_time += .5;
                            }
                        }
                        if (key.Contains("BARBECUE"))
                        {
                            //BARBECUE	2
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BARBECUE; ";
                                dVolume += n_items * .6;
                                dLoading_time += n_items * 0.04;
                                dUnLoading_time += n_items * 0.04;
                            }
                        }
                        if (key.Contains("BIKE") && !key.Contains("STATIONARY BIKES"))
                        {
                            //VÉLO	1
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BIKES; ";

                                dVolume += n_items * .5;
                                dLoading_time += n_items * 0.02;
                                dUnLoading_time += n_items * 0.02;
                            }
                        }
                        if (key.Contains("SUITCASES"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x SUITCASES; ";

                                dVolume += n_items * .2;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("TIRES"))
                        {
                            //PNEUS   13
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TIRES; ";

                                dVolume += n_items * .15;
                                dLoading_time += n_items * 0.01;
                                dUnLoading_time += n_items * 0.01;
                            }
                        }
                        if (key.Contains("TREADMILL"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x TREADMILL; ";
                                dVolume += n_items * .8;
                                dLoading_time += n_items * 0.15;
                                dUnLoading_time += n_items * 0.15;
                            }
                        }
                        if (key.Contains("STATIONARY BIKES"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x STATIONARY BIKES; ";
                                dVolume += n_items;
                                dLoading_time += n_items * 0.1;
                                dUnLoading_time += n_items * 0.1;
                            }
                        }
                        if (key.Contains("POOL TABLE"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += "\n---- " + n_items + " x POOL TABLES; ----\n";

                                dVolume += n_items * 15;
                                dLoading_time += n_items * 3;
                                dUnLoading_time += n_items * 3;
                            }
                        }
                        if (key.Contains("YOUR BOXES (APPROXIMATE)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                s_inventory += " x BOXES (APPROXIMATE);";
                                dVolume += n_items * .15;
                                dLoading_time += n_items * .015;
                                dUnLoading_time += n_items * .01;
                            }
                        }
                        if (key.Contains("WARDROBE BOXES (4 PROVIDED)"))
                        {
                            s_Lines[n_Line] = value;
                            n_items = int.Parse(s_Lines[n_Line]);
                            if (n_items > 0)
                            {
                                s_inventory += n_items;
                                nWardrobe_boxes += n_items;
                                s_inventory += " x WARDROBE BOX (4 PROVIDED);";

                                dVolume += n_items * .6;
                                dLoading_time += n_items * .075;
                                dUnLoading_time += n_items * .03;
                            }
                        }
                        if (key.Contains("MORE DETAILS"))
                        {
                            //PLUS DE PRÉCISIONS rien pour l\'instant
                            s_Lines[n_Line] = value;
                            s_notes += "\nMORE DETAILS: ";
                            s_notes += s_Lines[n_Line];
                        }
                        if (key.Contains("HOW DID YOU HEAR ABOUT US ?"))
                        {
                            s_notes += '\n' + s_Lines[n_Line];
                            textBox_Destination_source.Text = value;
                        }

                        n_Line++;
                        n_items = 0;
                    }
                }// English form

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
