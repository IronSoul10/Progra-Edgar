using TMPro;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private int targetCount;
    [SerializeField] private GameObject[] item;
    [SerializeField] public TextMeshProUGUI targetDestroy;
    // [SerializeField] public bool levelComplete = false;

    private void Start()
    {
    //    foreach (GameObject item in item)
    //    {
    //        item.SetActive(false);
    //    }
    }

    private void Update()
    {
       // UnlockItem();
    }

    public void IncrementTargetCount()
    {
        targetCount++;
        targetDestroy.text = targetCount.ToString();
    }

    void UnlockItem()
    {
        switch (targetCount)
        {
            case 5:
                item[0].SetActive(true);
                break;
            case 10:
                item[1].SetActive(true);
                break;
            case 15:
                item[2].SetActive(true);
                break;
            case 20:
                item[3].SetActive(true);
                break;
            case 25:
                item[4].SetActive(true);
                break;
            case 30:
                item[5].SetActive(true);
                break;
            case 35:
                item[6].SetActive(true);
                break;
            case 40:
                item[7].SetActive(true);
                break;
            case 45:
                //levelComplete = true;
                item[8].SetActive(true);
                break;
        }
    }
}
