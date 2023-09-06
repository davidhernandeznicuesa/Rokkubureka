using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Velocidad de bajada del powerup.
    [SerializeField]
    private float _speed;
    //Variable para asignar el tipo de PowerUp.
    [SerializeField]
    private int powerUpID; //0 = Diparo triple, 1 = Velocidad, 2 = escudo.

    void Start()
    {
        //Inicializar la velocidad.
        _speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Baje el powerUp.
        this.transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Con que colisionamos
        Debug.Log("Choca con " + collision.name);
        //Creo un objeto de tipo clase Jugador y obtengo todos los métodos(Componentes).
        Jugador jugador = collision.GetComponent<Jugador>();
        //Preguntamos si jugador no está vacío.
        if(jugador != null)
        {
            //Mandamos ejecutar en Jugador el método de triple disparo a true.
            jugador.TripleDisparoPowerupOn();

        }

    }
}
