using System.Numerics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADS_03_luz_moreno_campos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                AlienArtifact testArtifact = new AlienArtifact(
                    "XJ-22",
                    "Stellar Compass",
                    "Nebulon V",
                    "Galacti Cycle 14.77",
                    "Sector 9 Vault",
                    @"An elongated crystalline structure composed of rare extraterrestrial 
                    minerals not found in any known planetary system.Internal scans reveal a 
                    complex lattice capable of storing vast amounts of encoded data.The artifact 
                    shows signs of self‑repair, indicating it may possess autonomous regenerative properties."
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
