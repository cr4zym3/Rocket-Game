using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public RawImage heart1;
    public RawImage heart2;
    public RawImage heart3;
    public Texture2D full;
    public Texture2D half;
    public Texture2D empty;

    public void UpdateHealth(float health)
    {
        if (health == 6)
        {
            heart3.texture = full;
        }
        else if (health == 5)
        {
            heart3.texture = half;
        }
        else if (health == 4)
        {
            heart3.texture = empty;
        }
        else if (health == 3)
        {
            heart2.texture = half;
        }
        else if (health == 2)
        {
            heart2.texture = empty;
        }
        else if (health == 1)
        {
            heart1.texture = half;
        }
        else if (health == 0)
        {
            heart1.texture = empty;
        }
    }
}
