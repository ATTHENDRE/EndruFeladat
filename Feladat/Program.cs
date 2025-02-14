using System.Runtime.Serialization;

namespace Feladat
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<karakter> karakterek = [];
			Beolv("karakterek.txt", karakterek);

			foreach (var item in karakterek)
			{
                Console.WriteLine(item.ToString());
            }

			Console.WriteLine("--------------------------------------");
			Max(karakterek);
			Console.WriteLine("--------------------------------------");
			Osszes(karakterek);
			Console.WriteLine("--------------------------------------");
			Eros(karakterek);


		}

		static void Beolv(string filenev, List<karakter> karakterek)
		{
			StreamReader sr = new(filenev);

			string[] sorok = File.ReadAllLines(filenev);

			sr.ReadLine();

			while (!sr.EndOfStream)
			{
				string sor = sr.ReadLine();
				string[] szavak = sor.Split(';');

				karakter karakter = new(szavak[0], Convert.ToInt16(szavak[1]), Convert.ToInt16(szavak[2]), Convert.ToInt16(szavak[3]));
				karakterek.Add(karakter);

			}
        }


		static void Max(List<karakter> karakterek)
		{
			karakter maxKarak = karakterek[0];
            foreach (var item in karakterek)
            {
				if (item.Eletero > maxKarak.Eletero)
				{
					maxKarak = item;
				}
            }
            Console.WriteLine("A legtöbb Életerővel rendelkező karakter: ");
			Console.WriteLine($"{maxKarak.Name}, {maxKarak.Szint} / {maxKarak.Eletero} / {maxKarak.Ero}");

        }

		static void Osszes(List<karakter> karakterek)
		{
			int osszes = 0;
			foreach (var item in karakterek) 
			{
				osszes += item.Szint;
				
			}
			double atlagSzint = osszes / karakterek.Count;


			Console.WriteLine($"Az átlag szint: {atlagSzint}");

        }

		static void Eros(List<karakter> karakterek)
		{
			//for (int i = 0; i < karakterek.Count-1; i++)
			//{
   //             for (int j = 0; j < karakterek.Count; j++)
   //             {
			//		if (karakterek[i].Ero > karakterek[j].Ero)
			//		{
			//			karakter csere = karakterek[i];
			//			karakterek[i] = karakterek[j];
			//			karakterek [j] = csere;
			//		}
   //             }
   //         }

			


            for (int i = karakterek.Count-1; i < 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (karakterek[j].Ero > karakterek[j+1].Ero)
                    {
						karakter csere = karakterek[j];
						karakterek[j] = karakterek[j+1];
						karakterek[j+1] = csere;
					}
                }
            }

			foreach (var item in karakterek)
			{ Console.WriteLine(item.Ero); }

		}
		
	}
}
