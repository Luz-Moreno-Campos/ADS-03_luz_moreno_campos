

namespace ADS_03_luz_moreno_campos
{
    public static class Decoder
    {
        private static readonly char[] Original = { 'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y', 'Z' };

        private static readonly char[] Mapped = { 'H','Z','A','U','Y','E','K','G','O','T','I','R','J','V','W','N','M','F','Q','S','D','B','X','L','C', 'P' };


        //Divided name decoding in small methods  for more clarity and easier debugging:
        //1.GetOriginalIndex method:  gets the index of the letter in the original array.
        //2. DecodeLetter method: uses the index to map chars and moves levels until it reaches the base case.
        //3. ReverseMapping method (DecodeLetter base case)
        //4.DecodeName method: decodes  full name using DecodeLetter method

        private static int GetOriginalIndex(char codeChar)

        {
            for (int i = 0; i < Original.Length; i++)
            {
                if (Original[i] == codeChar)
                {
                    return i;
                }
            }
            return -1;
        }

        private static char ReverseMapping(char baseChar)
        {
            int pos = GetOriginalIndex(baseChar);
            int mirrorPos = 25 - pos; // calculates the "mirror" character in the original alphabet
            return Original[mirrorPos];
        }


        private static char DecodeLetter(char encodedChar, int level)
        {
            if (level == 1)
            {
                return ReverseMapping(encodedChar);
            }

            int originalIndex = GetOriginalIndex(encodedChar);        
            char mappedChar = Mapped[originalIndex];

            return DecodeLetter(mappedChar, level - 1);
        }










    }
}
