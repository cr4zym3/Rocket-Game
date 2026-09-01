using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject explosion;
    public int itemIndex;

    void OnTriggerEnter2D(Collider2D collision)
    {
        InventoryManager inventory = collision.gameObject.GetComponent<InventoryManager>();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && inventory != null)
        {
            if (inventory.item1 == -1 || inventory.item2 == -1 || inventory.item3 == -1)
            {
                if (inventory.item1 == -1)
                {
                    inventory.item1 = itemIndex;
                    inventory.slots[0].texture = inventory.items[itemIndex];
                }
                else if (inventory.item2 == -1)
                {
                    inventory.item2 = itemIndex;
                    inventory.slots[1].texture = inventory.items[itemIndex];
                }
                else if (inventory.item3 == -1)
                {
                    inventory.item3 = itemIndex;
                    inventory.slots[2].texture = inventory.items[itemIndex];
                }
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
