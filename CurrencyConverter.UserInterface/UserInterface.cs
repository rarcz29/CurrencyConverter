using CurrencyConverter.DataAccess;

namespace CurrencyConverter.UserInterface
{
    class UserInterface
    {
        private CurrencyRepository _data = new CurrencyRepository();

        public void DoSomething()
        {
            var data = _data.GetAll();
            System.Console.WriteLine("asdf");
        }
    }
}
