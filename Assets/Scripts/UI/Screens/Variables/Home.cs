using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : BasicScreen
{
    [SerializeField] private AvatarManager avatarManager;

    [SerializeField] private Button Tasks;
    [SerializeField] private Button Achievements;
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button PlayerPopup;

    [SerializeField] private TMP_Text _coins;
    [SerializeField] private TMP_Text _playerName;
    [SerializeField] private TMP_Text _levelText;

    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private List<TMP_Text> _levelTexts;

    private TextManager _textManager = new TextManager();

    private int _currentLevel;  

    private void Start()
    {
       
        Tasks.onClick.AddListener(TasksPressed);
        Achievements.onClick.AddListener(AwardsPressed);
        PlayButton.onClick.AddListener(PlayPressed);
        PlayerPopup.onClick.AddListener(ProfilePressed);
    }

    private void OnDestroy()
    {
        Tasks.onClick.RemoveListener(TasksPressed);
        Achievements.onClick.RemoveListener(AwardsPressed);
        PlayButton.onClick.RemoveListener(PlayPressed);
        PlayerPopup.onClick.RemoveListener(ProfilePressed);
    }

    public override void ResetScreen()
    {
        
    }

    public override void SetScreen()
    {
        PlayButton.interactable = true;
        avatarManager.SetSavedPicture();
        foreach (var level in _levels)
        {
            level.SetActive(true);
        }
        _currentLevel = SaveManager.PlayerPrefs.LoadInt(GameSaveKeys.CurrentLevel);
        SetText();
        SetLevel();
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
    private void SetLevel()
    {
        _textManager.SetText((_currentLevel + 1), _levelText, false, "Level ");
        if (_currentLevel == 10)
        {
            PlayButton.interactable = false;
            _textManager.SetText("Levels done!", _levelText);
            foreach (var level in _levels)
            {
                level.SetActive(false);
            }
        }
        if (_currentLevel == 9)
        {
            _levels[3].SetActive(false);
            _levels[2].SetActive(false);
            _levels[1].SetActive(false);
        }
        if (_currentLevel == 8)
        {
            _levels[3].SetActive(false);
            _levels[2].SetActive(false);

        }
        if (_currentLevel == 7)
        {
            _levels[3].SetActive(false);

        }

        int currentLevel = _currentLevel;
        foreach(var levelText in _levelTexts)
        {
            currentLevel++;
            levelText.text = currentLevel.ToString();
        }
    }

    private void AwardsPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Achievements);
    }
    private void TasksPressed()
    {
        UIManager.Instance.ShowScreen(ScreenTypes.Tasks);
    }

    private void PlayPressed()
    {
        SceneManager.LoadScene(_currentLevel+1);
    }

    private void ProfilePressed()
    {
        UIManager.Instance.ShowPopup(PopupTypes.Profile);
    }
}
