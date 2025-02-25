using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : BasicScreen
{
    [SerializeField] private AvatarManager avatarManager;

    [SerializeField] private Button Tasks;
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button[] _achievementsButton;
    [SerializeField] private Button PlayerPopup;

    [SerializeField] private Image _firstAchieve;
    [SerializeField] private Sprite _doneAchieve;
    [SerializeField] private GameObject _achievementPopup;
    [SerializeField] private GameObject[] _achievementPopups;
    [SerializeField] private Button[] _achievementPopupButton;

    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _playerName;

    private TextManager _textManager = new TextManager();

    private void Start()
    {

        Tasks.onClick.AddListener(TasksPressed);
        HomeButton.onClick.AddListener(Home);
        PlayerPopup.onClick.AddListener(ProfilePressed);

        for (int i = 0; i < _achievementsButton.Length; i++)
        {
            int index = i;
            _achievementsButton[index].onClick.AddListener(() => OpenAchievePopup(index));

        }
        for (int i = 0; i < _achievementPopupButton.Length; i++)
        {
            int index = i;
            _achievementPopupButton[index].onClick.AddListener(ClosePopups);

        }
    }

    private void OnDestroy()
    {
        Tasks.onClick.RemoveListener(TasksPressed);
        HomeButton.onClick.RemoveListener(Home);
        PlayerPopup.onClick.RemoveListener(ProfilePressed);

        for (int i = 0; i < _achievementsButton.Length; i++)
        {
            int index = i;
            _achievementsButton[index].onClick.RemoveListener(() => OpenAchievePopup(index));

        }
        for (int i = 0; i < _achievementPopupButton.Length; i++)
        {
            int index = i;
            _achievementPopupButton[index].onClick.RemoveListener(ClosePopups);

        }
    }
    private void ProfilePressed()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Profile);
    }
    public override void ResetScreen()
    {
        _achievementPopup.SetActive(false);
        foreach (var achievePopup in _achievementPopups)
        {
            achievePopup.SetActive(false);
        }
    }

    public override void SetScreen()
    {
        avatarManager.SetSavedPicture();
        SetText();

        if(SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.FirstAchieve))
        {
            _firstAchieve.sprite = _doneAchieve;
        }
    }

    private void SetText()
    {
        int coins = ResourcesManager.Instance.GetResource(ResourceTypes.Coins);
        _textManager.SetText(coins, _coins, true);

        string name = "User Name";
        if (SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.Name))
        {
            name = SaveManager.PlayerPrefs.LoadString(GameSaveKeys.Name);
        }
        _textManager.SetText(name, _playerName, false, "Welcome\n");

    }
   

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    private void TasksPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Tasks);
    }

    private void OpenAchievePopup(int index)
    {

        ClosePopups();
        _achievementPopup.SetActive(true);
        _achievementPopups[index].SetActive(true);
    }

    private void ClosePopups()
    {
        _achievementPopup.SetActive(false);
        foreach (var achievePopup in _achievementPopups)
        {
            achievePopup.SetActive(false);
        }
    }
}
