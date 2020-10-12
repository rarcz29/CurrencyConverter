using CurrencyConverter.BusinessLogic;

namespace CurrencyConverter.Presentation
{
    public class UserInterface : IUserInterface
    {
        private readonly ICurrencyBusinessLogic _currencyBusinessLogic;

        public UserInterface(ICurrencyBusinessLogic currencyBusinessLogic)
        {
            _currencyBusinessLogic = currencyBusinessLogic;
        }

        public void Run()
        {
        }
    }
}
