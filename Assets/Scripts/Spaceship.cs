using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public Interact interact;
    public InventoryManager inventory;
    public DropPart drop;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact.canInteract)
        {
            if (inventory.item1 > 0 && inventory.item1 <= 4)
            {
                drop.DropItem((int)inventory.item1);
                inventory.slots[0].texture = inventory.empty;
                inventory.item1 = -1;

            }
            else if (inventory.item2 > 0 && inventory.item2 <= 4)
            {
                drop.DropItem((int)inventory.item2);
                inventory.slots[1].texture = inventory.empty;
                inventory.item2 = -1;
            }
            else if (inventory.item3 > 0 && inventory.item3 <= 4)
            {
                drop.DropItem((int)inventory.item3);
                inventory.slots[2].texture = inventory.empty;
                inventory.item3 = -1;
            }
        }
    }
}
