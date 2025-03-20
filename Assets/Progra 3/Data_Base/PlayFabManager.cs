using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    [Header("PLAYFAB SETTINGS")]
    [SerializeField] private string titleID = "3020F";
    [SerializeField]
    private string secretKey = "ERSDCC7P8IQQGMYBWCB5OWT83UHCOIRTJT1YFIOAI8ABA3HNRR";

    [Header("Create Account Inputs")]
    [SerializeField] private TMP_InputField newUsernameInput;
    [SerializeField] private TMP_InputField setPasswordInput;

    [Header("Log In Inputs")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private UnityEvent onLogin;

    [Header("User Info")]
    [SerializeField] private TMP_Text userDisplayNameText;
    [SerializeField] private Image userProfilePicture;

    //Image Profile
    private Texture2D avatarTexture;
    private Sprite avatarSprite;
    private float avatarWidth = 100;
    private float avatarHeight = 100;

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
        GetPlayerProfile(); // Obtiene el perfil del jugador después de iniciar sesión
    }

    public void GetPlayerProfile()
    {
        var request = new GetPlayerProfileRequest()
        {
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowAvatarUrl = true,
                ShowDisplayName = true
            }
        };
        PlayFabClientAPI.GetPlayerProfile(request, OnGetProfileInfoSucces, PlayfabErrorMessage);
    }

    private IEnumerator ShowAvatar(string avatarUrl)
    {
        // Verifica si la URL es válida
        if (string.IsNullOrEmpty(avatarUrl))
        {
            Debug.LogWarning("URL de avatar no válida: " + avatarUrl);
            yield break;
        }

        UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(avatarUrl);


        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            avatarTexture = ((DownloadHandlerTexture)webRequest.downloadHandler).texture;
            avatarSprite = Sprite.Create(avatarTexture, new Rect(0, 0, avatarTexture.width, avatarTexture.height), new Vector2(0.5f, 0.5f));
            userProfilePicture.sprite = avatarSprite;
            userProfilePicture.rectTransform.sizeDelta = new Vector2(avatarWidth, avatarHeight); // Establece el tamaño de la imagen a 100x100 píxeles
            Debug.Log("Avatar obtenido correctamente de la API.");
        }
        else
        {
            Debug.Log("Error al obtener el avatar: " + webRequest.error);
        }
    }

    private void OnGetProfileInfoSucces(GetPlayerProfileResult result) // Consigue la informacion del usuario
    {
        userDisplayName = result.PlayerProfile.DisplayName;
        userDisplayNameText.text = userDisplayName;

        string avatarUrl = result.PlayerProfile.AvatarUrl;
        Debug.Log("Descargando Avatar URL: " + avatarUrl); // Imprime la URL en la consola para depuración
        StartCoroutine(ShowAvatar(avatarUrl));
    }

    public void UpdateLeaderBoard(string leaderboard, int value)
    {
        var request = new UpdatePlayerStatisticsRequest()
        {
            Statistics = new List<StatisticUpdate>()
            {
                new StatisticUpdate()
                {
                    StatisticName = leaderboard,
                    Value = value
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderUpdateSuccess, PlayfabErrorMessage);
    }

    private void OnLeaderUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Se actualizo el leaderboard correctamente");
    }
    private void PlayfabErrorMessage(PlayFabError error)
    {
        Debug.LogWarning(error.ErrorMessage);
    }
}
