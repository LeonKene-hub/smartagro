using System.Collections.ObjectModel;

namespace SmartAgro.ViewModels
{
    public class Categoria
    {
        public string Nome { get; set; }
        public int ID { get; set; }
        public string Icon { get; set; }
    }

    public class EditOrCreateViewModel
    {
        public ObservableCollection<Categoria> Categorias { get; private set; }

        public EditOrCreateViewModel()
        {
            Categorias = new ObservableCollection<Categoria>
            {
                new Categoria { Nome = "Tubérculo", ID = 1, Icon = "SolidIconCarrot" },
                new Categoria { Nome = "Cereal", ID = 2, Icon = "SolidIconWheatAwn" },
                new Categoria { Nome = "Fruto", ID = 3, Icon = "SolidIconAppleWhole" },
                new Categoria { Nome = "Verdura", ID = 4, Icon = "SolidIconPlantWilt" },
                new Categoria { Nome = "Raiz", ID = 5, Icon = "SolidIconSeedling" }
            };
        }
    }
}
