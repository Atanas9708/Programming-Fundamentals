using System;

namespace _01.Thea_the_Photographer
{
    public class TheaThePhotographer
    {
        public static void Main()
        {
            var picturesTaken = long.Parse(Console.ReadLine());
            var filterTime = long.Parse(Console.ReadLine());
            var goodPictures = double.Parse(Console.ReadLine()) / 100;
            var uploadTime = long.Parse(Console.ReadLine());

            var usefulPics = Math.Ceiling(picturesTaken * goodPictures);
            var totalPics = picturesTaken * filterTime;
            var filteredPics = usefulPics * uploadTime;

            var totalTime = Math.Ceiling(totalPics + filteredPics);
            var sumTime = TimeSpan.FromSeconds(totalTime);

            var startingTime = new TimeSpan();
            startingTime += sumTime;
            
            Console.WriteLine("{0:d\\:hh\\:mm\\:ss}", startingTime);
        }
    }
}