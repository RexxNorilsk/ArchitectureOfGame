public class ControllerCollection
{
    private SaveController _saveController;
    private LoadController _loadController;
    private DataController _dataController;
    private LanguageController _languageController;

    public SaveController SaveController { get => _saveController; }
    public LoadController LoadController { get => _loadController; }
    public DataController DataController { get => _dataController; }
    public LanguageController LanguageController { get => _languageController; }

    public ControllerCollection(){
        ProgramOptions programOptions = ProgramOptions.GetCorrect();
        _saveController = new SaveController(programOptions.PathToSave);
        _saveController.LoadOptions();
        _loadController = new LoadController(programOptions.PathsToAssetBundles);
        _dataController = new DataController(programOptions.DataBaseFolder);
        _languageController = new LanguageController(programOptions.Language);
    }

}
