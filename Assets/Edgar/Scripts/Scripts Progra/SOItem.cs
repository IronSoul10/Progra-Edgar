using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Create New Item")]
public class SOItem : ScriptableObject
{

    public GameObject itemPrefab;
    public Sprite sprite;
    public new string name;
    public string description;
    public string cantidad;

}




