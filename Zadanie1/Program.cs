using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Alicja Anszpergier 
//Dobromir Kata 176555

namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataFiller dataFiller = new ConstDataFiller();

            DataFiller dataFiller = new RandomDataFiller()
            {
                NumberOfBooks = 10,
                NumberOfBookStates = 10,
                NumberOfBookReaders = 10,
                NumberOfEvents = 10
            };

            DataContext dataContext = new DataContext();

            DataRepository dataRepository = new DataRepository(dataFiller)
            {
                Data = dataContext
            };
            dataRepository.Fill();


            Console.ReadKey();
        }
    }
}
