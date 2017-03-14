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
                //List alle informationer om alle hotellerne 
                var ListAlleHoteller = from h in db.Hotel
                                       select h;

                foreach (var item in ListAlleHoteller)
                {
                    Console.WriteLine(item.Address + item.Hotel_No + item.Name);
                }

                //List alle informationer om alle kunderne
                var ListAlleKunder = from g in db.Guest
                                     select g;

                foreach (var item in ListAlleKunder)
                {
                    Console.WriteLine(item.Name + item.Address + item.Guest_No);
                }




                //List hotelnavn, adresse, samt værelsesinformation(nr, type, pris) om de værelser hotellet har. 
                var ListInfoVærelser = from h in db.Hotel
                                       join r in db.Room
                                       on h.Hotel_No equals r.Hotel_No
                                       select new { h.Name, h.Address, r.Room_No, r.Types, r.Price};

                foreach (var item in ListInfoVærelser)
                {
                    Console.WriteLine(item);
                }


                //List alle de reservationer hver enkelt værelse har.
                var ListAlleReservationer = from b in db.Booking
                                            join r in db.Room
                                            on b.Hotel_No equals r.Hotel_No
                                            select new { r.Room_No, b.Booking_id };

                foreach (var item in ListAlleReservationer)
                {
                    Console.WriteLine(item);
                }



                //Indsæt dig selv som gæst i Guest Tabellen.
                //db.Guest.Add(new Guest { Name = "Magnus", Address = "Lysalleen 508", });
                //db.SaveChanges();

                //Opret en reservation på hotellet “Lucky Star” på fredag
                db.Booking.Add(new Booking {
                    Booking_id = 0,
                    Hotel_No = 2,
                    Date_From = new DateTime (2017,03,17),
                    Date_To = new DateTime(2017,03,19),
                    Room_No = 1
                });

                db.SaveChanges();


                //Opret endnu en reservation på hotellet “Lucky Star” på lørdag
                db.Booking.Add(new Booking
                {
                    Booking_id = 0,
                    Hotel_No = 2,
                    Date_From = new DateTime(2017, 03, 19),
                    Date_To = new DateTime(2017, 03, 20),
                    Room_No = 1
                });

                db.SaveChanges();












            }

            Console.ReadLine();
        }
    }
}
