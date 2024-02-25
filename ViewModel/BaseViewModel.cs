namespace MonkeyFinder.ViewModel;

[INotifyPropertyChanged]
public partial class BaseViewModel 
{
   public event PropertyChangedEventHandler PropertyChanged;
    bool isBussy;
    string title;

    public BaseViewModel()
    { 
      // etProperty(ref title, "Title");
    }
    public bool IsBussy
    {
        get => isBussy;

        set
        {
            if (isBussy == value)
                return;

            isBussy = value;

           // OnPropertyChanged(nameof(IsBussy));
            //OnPropertyChanged(nameof(isNotBussy));
        }

    }

    public string Title
    {
        get => title;
        set
        {
            if (title == value) return;

            title = value;
            //OnPropertyChanged(nameof(Title));
        }
    }

    public bool isNotBussy => !IsBussy;


    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
