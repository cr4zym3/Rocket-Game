using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarExplosion : MonoBehaviour
{

    void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, 1);
    }
}
