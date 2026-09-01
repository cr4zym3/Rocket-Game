using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPart : MonoBehaviour
{
    public GameObject dropItem;
    public Transform dropSpot;
    public Sprite[] parts;

    public void DropItem(int itemIndex)
    {
        GameObject newItem = Instantiate(dropItem, dropSpot.position, dropSpot.rotation);
        newItem.GetComponent<SpriteRenderer>().sprite = parts[itemIndex];
        Destroy(newItem, 1f);
    }
}
