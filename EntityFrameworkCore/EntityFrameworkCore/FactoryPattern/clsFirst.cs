namespace EntityFrameworkCore.FactoryPattern
{
    public class clsFirst : IGet
    {
        public string ConC(string s1, string s2)
        {
            string Final = "From First: " + s1 + " and " + s2;
            return Final;
        }
    }
}
