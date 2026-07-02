

namespace ADS_03_luz_moreno_campos
{
    public static class ArrayHelper
    {
        //Method to resize array when new artifacts are added
        public static AlienArtifact[] ResizeArray(AlienArtifact[] original)
        {
            if (original == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Array cannot be null.");
            }

            AlienArtifact[] bigger = new AlienArtifact[original.Length * 2];

            for (int i = 0; i < original.Length; i++)
            {
                bigger[i] = original[i];
            }

            return bigger;
        }


    }
}
