using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.InterviewQuestion
{
    public class CriderCard : IComparable
    {
        public string Name
        {
            get;
            set;
        }
        public int CartdDiscount
        {
            get;
            set;
        }

        public int CompareTo(object obj)
        {
            if (!(obj is CriderCard))
            {
                throw new ArgumentException("Compared Object is not of car");
            }
            CriderCard criderCard = obj as CriderCard;
            return Name.CompareTo(criderCard.Name);
        }
    }

    public class CridetCardComparer : IComparable<Cridet>
    {
        public enum SortBy
        {
            Name,
            CartdDiscount
        }
        public SortBy compareField = SortBy.Name;
        public int Compare(Cridet x, Cridet y)
        {
            switch (compareField)
            {
                case SortBy.Name:
                    return x.Name.CompareTo(y.Name);
                    break;
                case SortBy.CartdDiscount:
                    return x.CartdDiscount.CompareTo(y.CartdDiscount);
                    break;
                default:
                    break;
            }
            return x.Name.CompareTo(y.Name);
        }

        public int CompareTo(Cridet? other)
        {
            throw new NotImplementedException();
        }
    }


    public class Cridet
    {
        public string Name { get; set; }
        public int CartdDiscount { get; set; }
    }
}
