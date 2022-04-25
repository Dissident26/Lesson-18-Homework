namespace ClassLibrary
{
    public static class Arithmetics
    {
        public static int GetAllPositivesCount(int[] intArray)
        {
            return intArray.Where(i => i > 0).Count();
        }

        public static double GetAvaragePositive(int[] intArray)
        {
            return intArray.Where(i => i > 0).Average();
        }
    }
}