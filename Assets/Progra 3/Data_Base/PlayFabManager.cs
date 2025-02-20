using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.ProfilesModels;

public class PlayFabManager : MonoBehaviour
{
    [Header("PlayFab Settings")]
    [SerializeField] private string titleId = "3020F";
    [SerializeField] private string secretKey = "ERSDCC7P8IQQGMYBWCB5OWT83UHCOIRTJT1YFIOAI8ABA3HNRR";
    private void Start()
    {
        if(string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
           PlayFabSettings.TitleId = titleId;
           PlayFabSettings.DeveloperSecretKey = secretKey;

        }
    }
    private void Update()
    {
        
    }
}
