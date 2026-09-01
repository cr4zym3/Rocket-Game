using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject broken;

    public void ExplodeAsteroid()
    {
        broken.SetActive(true);
        gameObject.SetActive(false);
    }
}
