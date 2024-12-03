using System;
using UnityEngine;



/// <summary>
/// El inventario debe de funcionar de manera que, cada vez que lo abres crea N instancias de un item, basado
/// en cuantos objetos tienes en el inventario. Y en ellos se muestra la informacion de dicho objeto
/// 
/// ACTIVIDAD
/// Se necesita saber cuantos objetos de el inventario ya fueron instanciados.
/// Se necesita limitar de momento la cantidad de objetos instanciados a 8
/// 
/// En caso que la primera vez que abres el inventario tienes 2 objetos. Se van a instanciar
/// 2 items en el canvas. Despues de eso necesitas empezar a contar desde 2 y no otra vez desde 0.
/// </summary>
/// 

namespace Edgar.Inventory
{
    public class UIHandler1 : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryCanvas;
        [SerializeField] private GameObject uiItemPrefab;
        [SerializeField] private GameObject displayArea;
        [SerializeField] private Page[] pages = new Page[3]; // 24 items

        int addedItem; // agregado para llevar conteo de items nuevos

        public int actualPage = 0;
        private int maxItemsPerPage = 8;
        private InventoryHandler inventoryRef;
        public bool inventoryOpened = false;

        private void Awake()
        {
            inventoryRef = FindAnyObjectByType<InventoryHandler>();

            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].items = new GameObject[maxItemsPerPage];
                pages[i].itemsDeployed = 0;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.I)) // Abrir inventario
            {
                OpenInventory();
            }
        }

        private void OpenInventory()
        {
            inventoryOpened = !inventoryOpened;
            inventoryCanvas.SetActive(inventoryOpened);

            if (inventoryRef.inventory.Count <= 0) // Revisa si hay cosas en el inventario
            {
                // Si no hay nada, aqui termina
                return;
            }
            else
            {
                AddItems(); 
                HideAllItems();
                ShowItems(actualPage);
            }
        }

        private void AddItems()
        {
            // mientras haya items no instanciados en el inventario y no se haya alcanzado el límite de paginas
            while (addedItem < inventoryRef.inventory.Count && actualPage < pages.Length)
            {
                GameObject item = Instantiate(uiItemPrefab); // Crear un item en el canvas
                item.transform.SetParent(displayArea.transform); // Emparentarlo al área de visualización
                item.transform.localScale = Vector3.one; // Establecer la escala a 1
                item.GetComponent<ItemUI>().SetItemInfo(inventoryRef.inventory[addedItem]); // Asignar la información del item actual del inventario al componente ItemUI del item instanciado

                // Si la pag actual es menor al maximo de paguinas (hay espacio disponible en la pagina actual para agregar un nuevo) item
                if (pages[actualPage].itemsDeployed < maxItemsPerPage)
                {
                    // Guarda el item en la posición del arreglo de items de la pagina actual
                    pages[actualPage].items[pages[actualPage].itemsDeployed] = item;
                    // Incrementa el contador de items en la pagina actual
                    pages[actualPage].itemsDeployed++;
                    // Incrementa el contador de items instanciados
                    addedItem++;
                }
                else if (actualPage < pages.Length - 1)// Si la pagina actual esta llena y hay mas páginas disponibles, moverse a la siguiente página
                {

                    actualPage++; // Incrementar el contador de pag actual para pasar a la siguiente pag
                    pages[actualPage].itemsDeployed = 0; // Reinicia el contador de items para la nueva pag
                }
            }
        }

        [ContextMenu("Show Items in Page")]
        private void ShowItems()
        {
            for (int i = 0; i < pages[actualPage].itemsDeployed; i++)
            {
                pages[actualPage].items[i].SetActive(true);
            }
        }

        [ContextMenu("Hide Items in Page")]
        private void HideItems()
        {
            for (int i = 0; i < pages[actualPage].itemsDeployed; i++)
            {
                pages[actualPage].items[i].SetActive(false);
            }
        }

        // Este metodo ahorita me lo guardo para cuando tenga el boton de cambiar pagina
        private void ShowItems(int page)
        {
            for (int i = 0; i < pages[page].itemsDeployed; i++)
            {
                pages[page].items[i].SetActive(true);
            }
        }

        // Este metodo ahorita me lo guardo para cuando tenga el boton de cambiar pagina
        private void HideItems(int page)
        {
            for (int i = 0; i < pages[page].itemsDeployed; i++)
            {
                pages[page].items[i].SetActive(false);
            }
        }

        [ContextMenu("Hide All Items")]
        private void HideAllItems()
        {
            for (int page = 0; page <= actualPage; page++) // Este for recorre las paginas
            {
                Debug.Log(page);
                for (int item = 0; item < pages[page].itemsDeployed; item++)
                {
                    Debug.Log(item);
                    pages[page].items[item].SetActive(false);
                }
                Debug.Log("Siguiente pagina");
            }
        }
    }
}

[Serializable]
public struct Page
{
    public int itemsDeployed;
    public GameObject[] items; // en este arreglo me guarda los 8 items que pertenecen a esa pagina
}






