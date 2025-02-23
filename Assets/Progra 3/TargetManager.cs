using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private int targetCount;
    [SerializeField] private GameObject[] item;

    private void Start()
    {
        foreach (GameObject item in item)
        {
            item.SetActive(false);
        }
    }

    private void Update()
    {
        UnlockItem();
    }

    public void IncrementTargetCount()
    {
        targetCount++;
    }

    void UnlockItem()
    {
        switch (targetCount)
        {
            case 3:
                item[0].SetActive(true);
                break;
            case 6:
                item[1].SetActive(true);
                break;
            case 9:
                item[2].SetActive(true);
                break;
            case 12:
                item[3].SetActive(true);
                break;
            case 15:
                item[4].SetActive(true);
                break;
            case 18:
                item[5].SetActive(true);
                break;
            case 21:
                item[6].SetActive(true);
                break;
            case 24:
                item[7].SetActive(true);
                break;
            case 27:
                item[8].SetActive(true);
                break;
            case 30:
                item[9].SetActive(true);
                break;
        }
    }
}
