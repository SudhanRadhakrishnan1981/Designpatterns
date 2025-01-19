using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.AbstractClass
{
    public abstract class CridetcardCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CridetcardId { get; set; }
        public string CridetcardName { get; set; }
        public string CridetcardDescription { get; set; }
        public string CartdType { get; set; }

        public void Enquiry()
        {

            Console.WriteLine("Message from CridetcardCustomer.");

        }
        public abstract decimal CridetcardDiscount();

    }

   
}
