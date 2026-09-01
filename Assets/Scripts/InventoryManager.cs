using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Texture2D empty;
    public Texture2D[] items;
    public RawImage[] slots;

    public float item1;
    public float item2;
    public float item3;

    private void Start()
    {
        item1 = -1;
        item2 = -1;
        item3 = -1;
    }
}