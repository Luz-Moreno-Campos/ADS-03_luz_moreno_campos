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
                Console.WriteLine("Space Expedition - Alien Artifact Inventory");
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

                switch (option)
                {
                    case "1":
                    {
                        bool completed = false;
                        bool keepTrying = true;

                        string artifactFile = null;   

                        while (keepTrying)
                        {
                                
                            if (artifactFile == null)
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("Enter artifact file name with extension (e.g. artifact_omega.txt) or press 0 to return to the menu");
                                Console.WriteLine();
                                Console.Write("Enter file name: ");

                                artifactFile = Console.ReadLine();
                            }

                                
                            if (artifactFile == "0")
                            {
                                keepTrying = false;
                                break;
                            }

                            try
                            {
                                    
                                if (string.IsNullOrWhiteSpace(artifactFile))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Artifact file name cannot be empty.");
                                    Console.Write("Enter a new file name or press 0 to return to the menu:");

                                    artifactFile = Console.ReadLine();   
                                    continue;                            
                                }

                                if (!artifactFile.EndsWith(".txt"))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Artifact file must be a .txt file.");
                                    Console.Write("Enter a new file name or press 0 to return to the menu:");

                                    artifactFile = Console.ReadLine();   
                                    continue;
                                }

                                bool added = inventory.AddArtifact(artifactFile);

                                if (added)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Artifact added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Artifact already exists in the Galactic Vault.");
                                }

                                completed = true;
                                keepTrying = false;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Error: " + ex.Message);
                                Console.Write("Enter a new file name or press 0 to return to the menu:");

                                artifactFile = Console.ReadLine();   
                                continue;
                            }
                        }

                        if (completed)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press any key to go back to the menu");
                            Console.ReadKey();
                        }

                        break;
                    }

                    case "2":

                        try
                        {
                            Console.Clear();
                            inventory.ViewInventory();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Error: " + ex.Message);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Press any key to go back to the menu");
                        Console.ReadKey();
                        break;

                    case "3":
                        try
                        {
                            Console.Clear();
                            inventory.Save();
                            Console.WriteLine();
                            Console.WriteLine("Summary saved. Exiting alien artifact inventory.");
                            exit = true;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine("ERROR: " + ex.Message);
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("You entered an invalid option. Press any key  to go back to the menu");
                        Console.ReadKey();
                 
                        break;

                }

            }

        }

    }
        
}