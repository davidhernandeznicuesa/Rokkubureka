using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Asteroide : MonoBehaviour
{
    //Velocidad del asteroide.
    [SerializeField]
    private float _velocidad;
    //Variable para cargar el UIManager.
    private UIManager _uiManager;
    //Variable para prefab de la explosion
    [SerializeField]
    private GameObject _asteroideExplosion;

    void Start()
    {
        //Inicializamos el asteroide.
        _velocidad = 2.0f;
        //Cargamos los componentes del UIManager
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

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
            //Creamos la explosión.
            Instantiate(_asteroideExplosion, transform.position, Quaternion.identity);
            //Destruimos el asteroide
            Destroy(this.gameObject);
            //Comprobar si ha cargado el uiManager.
            if (_uiManager != null)
            {
                //Llamo al método de actualizar los puntos.
                _uiManager.UpdatePuntos();
            }
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
