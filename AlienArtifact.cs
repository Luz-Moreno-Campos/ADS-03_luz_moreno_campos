

namespace ADS_03_luz_moreno_campos
{
    public class AlienArtifact
    {
        //Wrote it in camelCase because it is a private const, which I will use to validate description in description setter.
        private const int maxDescriptionLength = 200;

        public string EncodedName { get; private set; }
        public string DecodedName { get; private set; }
        public string Planet { get; private set; }

        //Used string for DiscoveryDate because the dates are not valid, but fictional galactic cycles.
        public string DiscoveryDate { get; private set; }
        public string StorageLocation { get; private set; }

        // I chose to validate the description in the setter instead of the constructor for stronger encapsulation.
        private string _description;
        public string Description
        {

            get { return _description; }
            private set
            {
                if (value.Length > maxDescriptionLength)
                {
                    throw new ArgumentOutOfRangeException(
                             paramName: null,
                             message: $"Description exceeds maximum length of {maxDescriptionLength} characters.");
                }

                _description = value;
            }
        }

        public AlienArtifact(
          string encodedName,
          string decodedName,
          string planet,
          string discoveryDate,
          string storageLocation,
          string description)
        {
            EncodedName = encodedName;
            DecodedName = decodedName;
            Planet = planet;
            DiscoveryDate = discoveryDate;
            StorageLocation = storageLocation;
            Description = description;
        }
    }
}
