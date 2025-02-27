using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using System;
using System.Collections;

public class PlayFabManager : MonoBehaviour
{
    [Header("PlayFab Settings")]
    [SerializeField] private string titleId = "3020F";
    [SerializeField] private string secretKey = "ERSDCC7P8IQQGMYBWCB5OWT83UHCOIRTJT1YFIOAI8ABA3HNRR";

    [Header("Inputs")]
    [SerializeField] private TMP_InputField newUsernameInput;
    [SerializeField] private TMP_InputField setPasswordInput;

    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = titleId;
            PlayFabSettings.DeveloperSecretKey = secretKey;

        }
    }
    private void Update()
    {
        //Cursor.lockState = CursorLockMode.None;
    }
    void RegistrerUsuer()
    {
        if (string.IsNullOrEmpty(newUsernameInput.text) || string.IsNullOrEmpty(setPasswordInput.text))
        {
            Debug.LogError("Username or password is empty");
            return;
        }

        var request = new RegisterPlayFabUserRequest() // Crea una solicitud a Playfab para registrar un usuario nuevo 
        {
            DisplayName = "", // nombre con la que aparecerá en el juego
            Username = newUsernameInput.text, // registro de usuario
            Password = setPasswordInput.text // contraseña
        };
        //PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, PlayfabErrorMessage);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserRequest result )
    {
        Debug.Log("User registered successfully");
    }
    private void PlayfabErrorMessage( PlayFabError error)
    {
        Debug.Log("Error registering user");
    }
}
