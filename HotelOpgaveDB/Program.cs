using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgaveDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HotelContext())
            {
                var ListAlleHoteller = from h in db.Hotel
                                       select h;

                foreach (var item in ListAlleHoteller)
                {
                    Console.WriteLine(item.Address + item.Hotel_No + item.Name);
                }



                var ListAlleKunder = from g in db.Guest
                                     select g;

                foreach (var item in ListAlleKunder)
                {
                    Console.WriteLine(item.Address + item.Guest_No + item.Name);
                }




            }

            Console.ReadLine();
        }
    }
}
