﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BasketballApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BasketballTeam> allTeams = new List<BasketballTeam>();
        List<BasketballTeam> Conferences = new List<BasketballTeam>();
        List<BasketballTeam> Games = new List<BasketballTeam>();
        List<BasketballTeam> Awards = new List<BasketballTeam>();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Teamslbx_Loaded(object sender, RoutedEventArgs e)
        {
            Conferencecmbx.ItemsSource = Enum.GetNames(typeof(Conference));


            //create teams
            BasketballTeam firstteam = new BasketballTeam("Houston Rockets -", "Russell Westbrook , James Harden", 5, Conference.Western, "rockets.png");
            BasketballTeam secondteam = new BasketballTeam("Los Angeles Lakers - ", "Lebron James , Anthony Davis", 1, Conference.Western, "lakers.png");
            BasketballTeam thirdteam = new BasketballTeam("Boston Celtics - ", "Jayson Tatum , Kemba Walker", 3, Conference.Eastern, "celtics.png");
            BasketballTeam fourthteam = new BasketballTeam("Detroit Pistons -", "Blake Griffin , Derrick Rose", 9, Conference.Eastern, "pistons.png");
            BasketballTeam fifthteam = new BasketballTeam("Golden State Warriors -", "Stephen Curry , Klay Thompson", 10, Conference.Western, "warriors.png");
            BasketballTeam sixthteam = new BasketballTeam("Miami Heat -", "Jimmy Butler , Hassan Whiteside", 7, Conference.Eastern, "heat.png");
            BasketballTeam seventhteam = new BasketballTeam("Los Angeles Clippers -", "Kawhi Leonard , Paul George", 2, Conference.Western, "clippers.png");
            BasketballTeam eigthteam = new BasketballTeam("Philadelphia 76ers -", "Joel Embiid , Ben Simmons",4 , Conference.Eastern, "76ers.png");
            BasketballTeam ninthteam = new BasketballTeam("Milwaukee Bucks -", "Giannis Antetokoumpo , Khris Middleton", 6, Conference.Eastern, "bucks.jpg");
            BasketballTeam tenthteam = new BasketballTeam("Utah Jazz -", "Donovan Mitchell , Rudy Gobert", 8, Conference.Western, "jazz.png");
            




            //add to list 
            allTeams.Add(firstteam);
            allTeams.Add(secondteam);
            allTeams.Add(thirdteam);
            allTeams.Add(fourthteam);
            allTeams.Add(fifthteam);
            allTeams.Add(sixthteam);
            allTeams.Add(seventhteam);
            allTeams.Add(eigthteam);
            allTeams.Add(ninthteam);
            allTeams.Add(tenthteam);


            //source 
            Teamslbx.ItemsSource = allTeams;

            allTeams.Sort();

            //populate fixtures
            gameslbdisplay.ItemsSource = GetFixture();

        }

        //responds to changes to combo box
        private void Conferencecmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //get what was selected
            string selected = Conferencecmbx.SelectedItem as string;


            //check not null
            if (selected != null)
            {
                //take action
                if (selected.Equals("Eastern"))
                    Teamslbx.ItemsSource = allTeams.Where(t => t.Conference.Equals(Conference.Eastern));
                else
                    Teamslbx.ItemsSource = allTeams.Where(t => t.Conference.Equals(Conference.Western));

            }




            /* imgLogo.Source = new BitmapImage(new Uri());*///may not need the ../../

        }

        private void Teamslbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BasketballTeam selected = Teamslbx.SelectedItem as BasketballTeam;

            if (selected != null)
            {
                //take action

                standingTbx.Text = selected.Standing.ToString();
                var uri = new Uri("pack://application:,,,/images/" + selected.TeamImage);
                imgLogo.Source = new BitmapImage(uri);
            }
        }



        private string[] GetFixture()
        {
            //string s1 = "lakers vs bulls may 25th";
            //string s2 = "lakers vs raptors may 26th";


            string[] teams = new string[] { "Lakers", "Bucks", "Jazz", "Rockets", "Clippers", "76ers", "Heat", "Warriors", "Celtics", "Pistons" };

            string[] fixtures = new string[10];

            Random gen = new Random();



            string fixture;

            for (int i = 0; i< 10; i++)
            {
                string team1 = teams[gen.Next(0, 10)];
                string team2 = teams[gen.Next(0, 10)];


                if (team1.Equals(team2))
                {
                    //need new team
                    do
                    {
                        team2 = teams[gen.Next(0, 3)];
                    } while (team1.Equals(team2));
                }


                DateTime fixtureDate = DateTime.Now.AddDays(gen.Next(30));

                fixture = $"{team1} vs {team2} {fixtureDate.ToShortDateString()}";

                fixtures[i] = fixture;



            }


            return fixtures;

        }


    private Random gen = new Random();
    DateTime RandomDay()
    {
        DateTime start = new DateTime(1995, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }

        private void awardslbdisplay_Loaded(object sender, RoutedEventArgs e)
        {
            BasketballTeam mvp1 = new BasketballTeam("Lebron James ", "29 points per game", "/images/mvp.png");
            //BasketballTeam mvp2 = new BasketballTeam("James Harden ", "32 points per game", "/images/james.png");
            //BasketballTeam mvp3 = new BasketballTeam("Russell Westbrook ", "23 points per game", "/images/russ.png");
            //BasketballTeam mvp4 = new BasketballTeam("Michael Jordan ", "43 points per game", "/images/mike.png");
            //BasketballTeam mvp5 = new BasketballTeam("Shaquille O'Neal ", "30 points per game", "/images/shaq.png");

            Awards.Add(mvp1);
            //Awards.Add(mvp2);
            //Awards.Add(mvp3);
            //Awards.Add(mvp4);
            //Awards.Add(mvp5);

            awardslbdisplay.ItemsSource = Awards;
        }
    }
}
