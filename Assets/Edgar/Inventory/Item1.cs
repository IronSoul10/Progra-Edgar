using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Item1 : MonoBehaviour, IInteractable
    {
        [SerializeField] private SOItem item;
        private InventoryHandler1 inventory;

        private void Start()
        {
            inventory = FindObjectOfType<InventoryHandler1>();
        }

        public void Interact()
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }

    }

