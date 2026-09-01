using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPlatform : MonoBehaviour
{
    public Interact interact;
    public bool locked = true;
    public InventoryManager inventory;

    void Start()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact.canInteract && locked)
        {
            if (inventory.item1 == 0 || inventory.item2 == 0 || inventory.item3 == 0)
            {
                if (inventory.item1 == 0)
                {
                    inventory.slots[0].texture = inventory.empty;
                    inventory.item1 = -1;
                }
                else if (inventory.item2 == 0)
                {
                    inventory.slots[1].texture = inventory.empty;
                    inventory.item2 = -1;
                }
                else if (inventory.item3 == 0)
                {
                    inventory.slots[2].texture = inventory.empty;
                    inventory.item3 = -1;
                }
                Destroy(interact.gameObject);
                gameObject.SetActive(false);
                locked = false;
            }
        }
    }
}
