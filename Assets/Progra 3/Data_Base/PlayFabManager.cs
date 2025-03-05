using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Events;

public class PlayFabManager : MonoBehaviour
{
    [Header("PLAYFAB SETTINGS")]
    [SerializeField] private string titleID = "1C3E3";
    [SerializeField] private string secretKey = "C1K6MS4KCPD56NIEY7EI7B4H737BOO153ZFCJTD4YAO9PIXY55";

    [Header("Create Account Inputs")]
    [SerializeField] private TMP_InputField newUsernameInput;
    [SerializeField] private TMP_InputField setPasswordInput;

    [Header("Log In Inputs")]
    [SerializeField] private TMP_InputField usernameInput;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private UnityEvent onLogin;

    [Header("User Info")]
    [SerializeField] private TMP_Text userDisplayNameText;

    private string userDisplayName;

    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = titleID;
            PlayFabSettings.DeveloperSecretKey = secretKey;
        }
    }
    private void Update()
    {
            Cursor.lockState = CursorLockMode.None;
        
    }

    public void RegisterUser()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId) || string.IsNullOrEmpty(PlayFabSettings.DeveloperSecretKey))
        {
            PlayFabSettings.TitleId = titleID;
            PlayFabSettings.DeveloperSecretKey = secretKey;
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
    }

    public void GetDisplayName()
    {
        var request = new GetPlayerProfileRequest();
        PlayFabClientAPI.GetPlayerProfile(request,OnGetDisplayNameSucced,PlayfabErrorMessage);
    }

    private void OnGetDisplayNameSucced(GetPlayerProfileResult result)
    {
        userDisplayName = result.PlayerProfile.DisplayName;

        userDisplayNameText.text = userDisplayName;
    }

    private void PlayfabErrorMessage(PlayFabError error)
    {
        Debug.LogWarning(error.ErrorMessage);
    }

}
