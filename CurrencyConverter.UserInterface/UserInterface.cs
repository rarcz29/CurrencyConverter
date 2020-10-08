using CurrencyConverter.DataAccess;

namespace CurrencyConverter.UserInterface
{
    class UserInterface
    {
        private DataRepository _data = new DataRepository();

        public void DoSomething()
        {
            var data = _data.GetAll();
            System.Console.WriteLine("asdf");
        }
    }
}
