using System.Linq;

namespace InvestmentCalculator.Services
{
    public class Calculator
    {
        private readonly ApplicationContext _db;
        public Calculator(ApplicationContext db)
        {
            _db = db;
        }

        public string Calculate(int years)
        {
            var investments = _db.Investments.ToList();

            var res = 0.0;

            var entered = 0.0;

            foreach(var invest in investments)
            {
                var toAdd = invest.AmountPerYear;
                entered += invest.AmountPerYear;

                for(var i = 0; i < years; i++)
                {
                    toAdd = toAdd * invest.APY;

                    toAdd += invest.AmountPerYear;
                    entered += invest.AmountPerYear;

                }

                res += toAdd;
            }

            return $" Total invested: {entered} \n Total earned: {res - entered} \n Total money: {res}" ;
        }
    }
}
