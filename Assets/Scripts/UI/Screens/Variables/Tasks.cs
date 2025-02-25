using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tasks : BasicScreen
{
    [SerializeField] private AvatarManager avatarManager;

    [SerializeField] private Button Achievements;
    [SerializeField] private Button HomeButton;
    [SerializeField] private Button _taskReward;
    [SerializeField] private Button PlayerPopup;

    [SerializeField] private Sprite _defaultTaskButton;
    [SerializeField] private Sprite _doneTaskButton;
    [SerializeField] private Sprite _claimedTaskButton;

    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _playerName;

    private TextManager _textManager = new TextManager();

    private void Start()
    {
        _taskReward.onClick.AddListener(TaskButtonPressed);
        Achievements.onClick.AddListener(AchievementsPressed);
        HomeButton.onClick.AddListener(Home);
        PlayerPopup.onClick.AddListener(ProfilePressed);
    }

    private void OnDestroy()
    {
        _taskReward.onClick.RemoveListener(TaskButtonPressed);
        Achievements.onClick.RemoveListener(AchievementsPressed);
        HomeButton.onClick.RemoveListener(Home);
        PlayerPopup.onClick.RemoveListener(ProfilePressed);
    }
    private void ProfilePressed()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Profile);
    }
    public override void ResetScreen()
    {
        _taskReward.interactable = false;
        _taskReward.GetComponent<Image>().sprite = _defaultTaskButton;
    }

    public override void SetScreen()
    {
        avatarManager.SetSavedPicture();
        SetText();
        SetTasks();
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

    private void SetTasks()
    {
        int firstTask = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.FirstTask);

        if (firstTask == 0)
        {
            _taskReward.interactable = false;
            _taskReward.GetComponent<Image>().sprite = _defaultTaskButton;
        }
        else if(firstTask == 1)
        {
            _taskReward.interactable = true;
            _taskReward.GetComponent<Image>().sprite = _doneTaskButton;
        }
        else
        {
            _taskReward.interactable = false;
            _taskReward.GetComponent<Image>().sprite = _claimedTaskButton;
        }
    }

    private void Home()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.MainMenu);
    }
    private void AchievementsPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Achievements);
    }
    private void TaskButtonPressed()
    {
        SaveManager.PlayerPrefs.SaveInt(GameSaveKeys.FirstTask, 2);
        ResourcesManager.Instance.ModifyResource(ResourceTypes.Coins, 50); 
        _taskReward.interactable = false;
        _taskReward.GetComponent<Image>().sprite = _claimedTaskButton;
        SetText();
    }
}
