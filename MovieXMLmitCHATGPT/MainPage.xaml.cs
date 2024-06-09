using MovieXMLmitCHATGPT.ViewModels;

namespace MovieXMLmitCHATGPT
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.BindingContext = mainViewModel;
        }

        
    }

}
