using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffects : MonoBehaviour
{
    // Destruyo el objeto en el que estoy y le doy un tiempo de autodestrucci�n.
    void Start()
    {
        Destroy(this.gameObject, 4f);
    }

   
}
