using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsol
{
    public class ProgramC
    {
        static void Main(string[] args)
        {
            BusinessCompany bc = new BusinessCompany();
            var list = bc.GetListeCategorieDto();
            Console.WriteLine("length      : {0}", list.Count);
            foreach (var item in list)
            {
                Console.WriteLine("id          : {0}", item.id_cat);
                Console.WriteLine("Description : {0}", item.description_cat);
                Console.ReadLine();

            }
        }
    }
}
