using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    public bool hasKey;

    public void Interact()
    {

        if (hasKey)
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No tienes la llave");
        }
    }

}
