using System.ComponentModel;
using System.Linq;
using SportidentLapCounter.DataTypes;
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

        public void SortTeams()
        {
                Model.Teams = new BindingList<Team>(
                    Model.Teams
                    .OrderByDescending(x => x.Laps)
                    .ThenBy(x => x.LatestPunchTime)
                    .ThenBy(x => x.Number)
                    .ToList());
        }

        public void PersistModel()
        {
            PersistenceService.Save(Model);
        }
    }
}