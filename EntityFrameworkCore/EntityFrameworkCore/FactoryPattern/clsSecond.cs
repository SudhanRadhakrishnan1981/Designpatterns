namespace EntityFrameworkCore.FactoryPattern
{
    public class clsSecond : IGet
    {
        public string ConC(string s1, string s2)
        {
            string Final = "From Second: " + s1 + " and " + s2;
            return Final;
        }
    }
}
