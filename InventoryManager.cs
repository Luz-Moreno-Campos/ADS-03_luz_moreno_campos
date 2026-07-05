

namespace ADS_03_luz_moreno_campos
{
    public class InventoryManager
    {
        public AlienArtifact[] Artifacts { get; private set; }
        public int Count { get; private set; }

        public InventoryManager(AlienArtifact[] artifacts, int count)
        {
            Artifacts = artifacts;   
            Count = count;           
 
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


    }

}
