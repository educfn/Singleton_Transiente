using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Singleton_Transiente
{

    //TODO: Mudar esta 'View' para apresentar as paginas 'DesvioPadrao', 'MediaMovel' e 'Moda' em uma MasterDetailPage onde o usuario podera selecionar uma dessa paginas.
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Calculos.MediaMovel();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
