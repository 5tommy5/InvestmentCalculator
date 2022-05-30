using InvestmentCalculator.Entities;

namespace InvestmentCalculator.Extension
{
    public static class InvestExtension
    {
        public static void Copy(this Investment self, Investment to)
        {
            self.AmountPerYear = to.AmountPerYear;
            self.APY = to.APY;
            self.Name = to.Name;
        }
    }
}
