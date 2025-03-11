using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayFabManager : MonoBehaviour
{
    [Header("PLAYFAB SETTINGS")]
    [SerializeField] private string titleID = "3020F";
    [SerializeField]
    private string secretKey = "ERSDCC7P8IQQGMYBWCB5OWT83UHCOIRTJT1YFIOAI8ABA3HNRR"
;

    [Header("Create Account Inputs")]
    [SerializeField] private TMP_InputField newUsernameInput;
    [SerializeField] private TMP_InputField setPasswordInput;

    [Header("Log In Inputs")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private UnityEvent onLogin;

    [Header("User Info")]
    [SerializeField] private TMP_Text userDisplayNameText;

    //Profile Display
    private readonly float profilePicWidth = 100;
    private readonly float profilePicHeigth = 100;
    private readonly Sprite usserProfilePictureSprite;


    private string userDisplayName;

    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId) || string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
        {
            PlayFabSettings.TitleId = titleID;
            PlayFabSettings.DeveloperSecretKey = secretKey;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RegisterUser()
    {
        if (string.IsNullOrEmpty(newUsernameInput.text) || string.IsNullOrEmpty(setPasswordInput.text))
        {
            Debug.LogWarning("Alguno de los campos esta vacion");
            return;
        }

        var request = new RegisterPlayFabUserRequest()
        {
            DisplayName = newUsernameInput.text,
            Username = newUsernameInput.text,
            Password = setPasswordInput.text,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSucces, PlayfabErrorMessage);


    }

    private void OnRegisterSucces(RegisterPlayFabUserResult result)
    {
        Debug.Log("USUARIO REGISTRADO CORRECTAMENTE");
    }

    public void LogInUser()
    {
        if (string.IsNullOrEmpty(usernameInput.text) || string.IsNullOrEmpty(passwordInput.text))
        {
            Debug.LogWarning("ALGUNO DE LOS CAMPOS ESTA VACIO");
            return;
        }

        var request = new LoginWithPlayFabRequest()
        {
            Username = usernameInput.text,
            Password = passwordInput.text,
        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSucces, PlayfabErrorMessage);
    }

    private void OnLoginSucces(LoginResult result)
    {
        Debug.Log("SESION INICIADA CORRECTAMENTE");
        onLogin?.Invoke();
    }

    public void GetPlayerProfile()
    {
        var request = new GetPlayerProfileRequest()
        {
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true,
            }
        };
        PlayFabClientAPI.GetPlayerProfile(request, OnGetDisplayNameSucces, PlayfabErrorMessage);
    }

    private void OnGetDisplayNameSucces(GetPlayerProfileResult result)
    {
        userDisplayName = result.PlayerProfile.DisplayName;

        userDisplayNameText.text += userDisplayName;

        string url = result.PlayerProfile.AvatarUrl;
        Debug.Log($"{url}");

    }

    private void PlayfabErrorMessage(PlayFabError error)
    {
        Debug.LogWarning(error.ErrorMessage);
    }

}
