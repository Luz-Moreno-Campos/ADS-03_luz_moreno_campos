

using System.Text;

namespace ADS_03_luz_moreno_campos
{
    public class InventoryManager
    {
        public AlienArtifact[] Artifacts { get; private set; }
        public int Count { get; private set; }

        public FileManager FileManager { get; private set; }

        public InventoryManager(AlienArtifact[] artifacts, int count, FileManager fileManager)
        {
            Artifacts = artifacts;   
            Count = count;
            FileManager = fileManager;

        }

        private void DecodeAllNames()
        {
            for (int i = 0; i < Count; i++)
            {
                AlienArtifact artifact = Artifacts[i];
                artifact.DecodedName = Decoder.DecodeName(artifact.EncodedName);
            }
        }

        private void SortByDecodedName()
        {
            for (int i = 1; i < Count; i++)
            {
                AlienArtifact current = Artifacts[i];
                int j = i - 1;

                while (j >= 0 && Artifacts[j].DecodedName.CompareTo(current.DecodedName) > 0)
                {
                    Artifacts[j + 1] = Artifacts[j];
                    j--;
                }

                Artifacts[j + 1] = current;
            }
        }

        private void OrderedInsertion(AlienArtifact newArtifact)
        {
          
            Artifacts = ArrayHelper.ResizeArray(Artifacts);

            int insertIndex = Count;

            for (int i = 0; i < Count; i++)
            {
                if (newArtifact.DecodedName.CompareTo(Artifacts[i].DecodedName) < 0)
                {
                    insertIndex = i;
                    break;
                }
            }

            ArrayHelper.ShiftRight(Artifacts, insertIndex, Count);
           
            Artifacts[insertIndex] = newArtifact;

            Count++;
        }


        public bool AddArtifact(string artifactPath)
        {
            if (artifactPath == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Artifact file path cannot be null.");
            }

            if (artifactPath.Trim() == "")
            {
                throw new ArgumentException(
                    message: "Artifact file path cannot be empty.",
                    paramName: null);
            }

           
            AlienArtifact newArtifact = FileManager.LoadArtifactFile(artifactPath);

            if (newArtifact == null)
            {
                throw new FormatException("Artifact file cannot be null.");
            }

           
            string decodedName = Decoder.DecodeName(newArtifact.EncodedName);
            newArtifact.DecodedName = decodedName;

            int index = ArrayHelper.BinarySearchByDecodedName(Artifacts, decodedName);

            if (index >= 0)
            {
              
                return false;
            }

         
            OrderedInsertion(newArtifact);

            return true;
        }

        public void ViewInventory()
        {
            Console.WriteLine("Galactic Vault Inventory");

            for (int i = 0; i < Count; i++)
            {
                AlienArtifact artifact = Artifacts[i];

                Console.WriteLine();
                Console.WriteLine("Encoded Name: " + artifact.EncodedName);
                Console.WriteLine("Decoded Name: " + artifact.DecodedName);
                Console.WriteLine("Planet: " + artifact.Planet);
                Console.WriteLine("Discovery Date: " + artifact.DiscoveryDate);
                Console.WriteLine("Storage Location: " + artifact.StorageLocation);
                Console.WriteLine("Description: " + artifact.Description);
            }

            Console.WriteLine();
        }




    }

}
