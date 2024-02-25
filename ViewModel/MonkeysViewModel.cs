using MonkeyFinder.Services;
using System.Linq.Expressions;
namespace MonkeyFinder.ViewModel;


public partial class MonkeysViewModel : BaseViewModel
{
    MonkeyService monkeyService;

    public ObservableCollection<Monkey> Monkeys { get; } = new();
    public MonkeysViewModel(MonkeyService monkeyService)
    {
        //Title = "Monkey Finder";
        this.monkeyService = monkeyService;

    }

    async Task GetMonkeysAsync() 
    {
        if (IsBussy)
            return;

        try
        {
            IsBussy = true;
            var monkeys = await monkeyService.GetMonkeys();
            if(monkeys.Count != 0)
            monkeys.Clear();

            foreach(var monkey in monkeys)
            {
                Monkeys.Add(monkey);
            }
            
        }catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("error", $"Unable to get Monkeys {ex.Message}", "Ok");
        }
        finally
        {
            IsBussy = false;

        }
    }

}
