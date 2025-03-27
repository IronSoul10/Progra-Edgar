using UnityEngine;

public class Target : MonoBehaviour
{
    private TargetManager targetManager;


    private void Start()
    {
        targetManager = FindFirstObjectByType<TargetManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            targetManager.IncrementTargetCount();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
