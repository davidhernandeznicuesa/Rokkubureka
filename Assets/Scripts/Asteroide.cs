using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    //Velocidad del asteroide.
    [SerializeField]
    private float _velocidad;
    void Start()
    {
        //Inicializamos el asteroide.
        _velocidad = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Movemos el asteroide.
        transform.Translate(Vector3.down * _velocidad * Time.deltaTime);
        if (transform.position.y < -5.4f)
        {
            //Destruyo el laser cuando se sale de la pantalla.
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collaider: " + collision.name);
        //Si colisiona con el laser se destruye.
        if(collision.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }
}
