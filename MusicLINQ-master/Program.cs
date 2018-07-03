using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //=========================================================
            //Solve all of the prompts below using various LINQ queries
            //=========================================================

            //=========================================================
            //There is only one artist in this collection from Mount 
            //Vernon. What is their name and age?
            //=========================================================
            List<Artist> art = Artists.Where(str => str.Hometown == "Mount Vernon").ToList();
            System.Console.WriteLine(art[0].ArtistName + " " + art[0].Age);

            
            //=========================================================
            //Who is the youngest artist in our collection of artists?
            //=========================================================
            List<Artist> art2 = Artists.OrderBy(a=>a.Age).ToList();
            System.Console.WriteLine(art2[0].ArtistName);
            //=========================================================
            //Display all artists with 'William' somewhere in their 
            //real name        
            //=========================================================
            List<Artist> art3 = Artists.Where(q => q.RealName.Contains("%William%")).ToList();
            System.Console.WriteLine(art3);
            foreach (var item in art3)
            {
                System.Console.WriteLine(item.RealName);
            }
            //=========================================================
            //Display all groups with names less than 8 characters
            //=========================================================
            List<Group> art4 = Groups.Where(g =>g.GroupName.Length < 8).ToList();
            foreach (var item in art3)
            {
                System.Console.WriteLine(item.RealName);
            }
            //=========================================================
            //Display the 3 oldest artists from Atlanta
            //=========================================================
            List<Artist> art5 = Artists.OrderByDescending(a => a.Age).ToList();
            for(int i = 0; i < 2;i++){
                System.Console.WriteLine(art5[i]);
            }
            //=========================================================
            //(Optional) Display the Group Name of all groups that have 
            //at least one member not from New York City
            //=========================================================

            //=========================================================
            //(Optional) Display the artist names of all members of the 
            //group 'Wu-Tang Clan'
            //=========================================================
            //var wutang = from group in Groups
                         
        }
    }
}
