using SportidentLapCounter.Services;

namespace SportidentLapCounter.Controls.MainForm
{
    public class MainFormPresenter
    {
        public MainFormModel Model;
        private PersistenceService _persistenceService;
        private PersistenceService PersistenceService => _persistenceService ?? (_persistenceService = new PersistenceService());

        public MainFormPresenter()
        {
            Model = PersistenceService.Load();
        }

        public void PersistModel()
        {
            PersistenceService.Save(Model);
        }
    }
}
