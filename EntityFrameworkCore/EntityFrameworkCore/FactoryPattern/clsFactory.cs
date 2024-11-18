namespace EntityFrameworkCore.FactoryPattern
{
    public class clsFactory
    {
        static public IGet CreateandReturnObj(int cChoice)
        {
            IGet ObjSelector = null;

            switch (cChoice)
            {
                case 1:
                    ObjSelector = new clsFirst();
                    break;
                case 2:
                    ObjSelector = new clsSecond();
                    break;
                default:
                    ObjSelector = new clsFirst();
                    break;
            }
            return ObjSelector;

        }
    }
}
