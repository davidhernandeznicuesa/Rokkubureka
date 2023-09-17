using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//TODO1 Ejercicio, hacer que se sumen los puntos.

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
            //Destruyo el asteroide cuando se sale de la pantalla.
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collaider: " + collision.name);
        //Si colisiona con el laser se destruye.
        if(collision.tag == "Laser")
        {
            //Destruimos el asteroide
            Destroy(this.gameObject);
        }
        //Si chocamos con el jugador
        else if(collision.tag == "NaveAtaque")
        {
            //Acceder a la clase del jugador para acceder a los métodos.
            Jugador jugador = collision.GetComponent<Jugador>();
            //Comprobamos si se ha cargado todos los métodos de jugador.
            if (jugador != null)
            {
                //Llamar al método que le quita una vida.
                jugador.Damage();
            }
            //Destruimos el asteroide.
            Destroy(this.gameObject);
        }
    }
}
