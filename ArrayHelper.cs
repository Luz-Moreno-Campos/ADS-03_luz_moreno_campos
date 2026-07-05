

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


        //Method  for insertion sort
        public static void ShiftRight(AlienArtifact[] array, int startIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Array cannot be null.");
            }

            if (startIndex < 0 || startIndex >= array.Length - 1)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: null,
                    message: "Start index must be within a valid range for shifting.");
            }

            for (int i = count; i > startIndex; i--)
            {
                array[i] = array[i - 1];
            }
        }


        //Method to search for duplicates
        public static int BinarySearchByDecodedName(AlienArtifact[] array, string decodedName)
        {
            if (array == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Array cannot be null.");
            }

            if (decodedName == null)
            {
                throw new ArgumentNullException(
                    paramName: null,
                    message: "Decoded Name cannot be null.");
            }

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid= left + (right - left) / 2;
                string midDecodedName = array[mid].DecodedName;

                int comparison = midDecodedName.CompareTo(decodedName);

                if (comparison == 0)
                {
                    return mid; 
                }
                else if (comparison < 0)
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1; 
                }
            }

            return -1; 
        }



    }
}
