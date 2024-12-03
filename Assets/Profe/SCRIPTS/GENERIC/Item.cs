using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Profe
{
    public class Item : MonoBehaviour, IInteractable
    {
        [SerializeField] private SOItem item;
        private InventoryHandler inventory;

        private void Start()
        {
            inventory = FindObjectOfType<InventoryHandler>();
        }

        public void Interact()
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }

    } 
}
