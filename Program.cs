namespace ADS_03_luz_moreno_campos
{
    public class Program
    {
        static void Main(string[] args)
        {

            FileManager fileManager = null;
            AlienArtifact[] artifacts = null;
            InventoryManager inventory = null;
            int count = 0;

            try
            {

                string vaultPath = "galactic_vault.txt";
                string summaryPath = "expedition_summary.txt";

                fileManager = new FileManager(vaultPath, summaryPath);

                artifacts = fileManager.LoadVault(out count);

                inventory = new InventoryManager(artifacts, count, fileManager);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine("Program cannot continue without loading the vault.");
                return;
            }

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(" Galactic Vault Expedition");
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("1. Add Artifact");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Save and Exit");
                Console.WriteLine();
                Console.Write("Enter an option: ");

                string option = Console.ReadLine();
                Console.WriteLine();

            }

        }
    }
        
}