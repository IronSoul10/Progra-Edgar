using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trampa : MonoBehaviour
{
    [SerializeField] Transform respawn;
    [SerializeField] float radio;
    [SerializeField] LayerMask layer;
    [SerializeField] CharacterController characterController;
    VidaPlayer player;

    private void Update()
    {
        if (Deteccion())
        {
            
            characterController.enabled = false;
            transform.position = respawn.position;
            characterController.enabled = true;

        }
    }

    bool Deteccion()
    {
        return Physics.CheckSphere(transform.position, radio, layer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
