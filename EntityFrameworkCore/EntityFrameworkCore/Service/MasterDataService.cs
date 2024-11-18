namespace EntityFrameworkCore.Service
{
    public class MasterDataService
    {

        public List<string> Countries { get; private set; }
        public List<string> Currencies { get; private set; }


        private static MasterDataService _instance;
        private static readonly object _instanceLock = new object();
        // Constructor
        private MasterDataService()
        {
            // Load master data when the service is created

            LoadMasterData();
        }

       public static MasterDataService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MasterDataService();
                        }
                    }
                }
                return _instance;
            }
        }


        // Method to load master data (e.g., from a database or configuration file)
        private List<string>  LoadCountriesData()
        {
            // Simulated data loading
           
               var ccon  = new List<string> { "United States", "Canada", "France", "Japan" };
                       // Currencies = new List<string> { "USD", "CAD", "EUR", "JPY" };
                return ccon;
                  
        }


        private void LoadMasterData()
        {
            // Simulated data loading
            // In a real application, you would likely load this from a database or external service
            if (Currencies == null)
            {
                lock (_instanceLock)
                {
                    if (Currencies == null)
                    {
                        Countries = new List<string> { "United States", "Canada", "France", "Japan" };
                        Currencies = new List<string> { "USD", "CAD", "EUR", "JPY" };
                    }

                }


            }
        }

        // Optional: method to refresh or reload master data if needed
        public void RefreshMasterData()
        {
            LoadMasterData();
        }
    }

}
