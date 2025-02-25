
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : BasicPopup
{
    [SerializeField] private AvatarManager avatarManager;

    [SerializeField] private TMP_InputField _name;
    [SerializeField] private Button _avatar;
    [SerializeField] private Button _save;

    [SerializeField] private TMP_Text[] _names;

    private void Start()
    {
        _avatar.onClick.AddListener(avatarManager.PickFromGallery);
        _save.onClick.AddListener(CloseAndSave);
    }

    private void OnDestroy()
    {
        _avatar.onClick.RemoveListener(avatarManager.PickFromGallery);
        _save.onClick.RemoveListener(CloseAndSave);
    }

    public override void ResetPopup()
    {
    }

    public override void SetPopup()
    {
        avatarManager.SetSavedPicture();
        if (SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.Name))
        {
            _name.text = SaveManager.PlayerPrefs.LoadString(GameSaveKeys.Name);
        }
        else
        {
            _name.text = "User Name";
        }
    }

    public void CloseAndSave()
    {
        SaveManager.PlayerPrefs.SaveString(GameSaveKeys.Name, _name.text);

        string name = "User Name";
        if (SaveManager.PlayerPrefs.IsSaved(GameSaveKeys.Name))
        {
            name = SaveManager.PlayerPrefs.LoadString(GameSaveKeys.Name);
        }
        foreach (var nameText in _names)
        {
            nameText.text = "Welcome\n" + name;
        }

        UIManager.Instance.HidePopup(_popupType);
    }
}
