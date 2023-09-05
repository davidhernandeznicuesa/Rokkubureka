using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    //Variable privada de forma serializada para que se pueda ver y modificar solo en Unity.
    [SerializeField]
    private float speed;
    private GameManager gameManager;
   
    void Start()
    {
        speed = 10.0f;
    }
    
    void Update()
    {
        //Crear el movimiento del laser.
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
        //Pregunto si ha superado el límite de pantalla.
        if(transform.position.y > 5.4f)
        {
            //Destruyo el laser cuando se sale de la pantalla.
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collaider: " + collision.name);
        //Si hemos colisionado con el asteroide.
        if (collision.tag == "Asteroide")
        {
            Destroy(gameObject);
        }
    }
}
