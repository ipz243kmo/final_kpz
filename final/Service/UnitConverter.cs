
namespace RecipeFinder.Services
{
    public static class UnitConverter
    {
      
        private const double GramsInOunce = 28.3495;
        private const double MlInCup = 250.0;

        public static double GramsToOunces(double grams) => grams / GramsInOunce;

        public static double OuncesToGrams(double ounces) => ounces * GramsInOunce;

        public static double MlToCups(double ml) => ml / MlInCup;

       
        public static double ScaleAmount(double originalAmount, int originalServings, int targetServings)
        {
            if (originalServings <= 0) return originalAmount;
            return (originalAmount / originalServings) * targetServings;
        }
    }
}