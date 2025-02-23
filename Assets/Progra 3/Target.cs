using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetManager targetManager;

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
