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
    //Variable de tipo sonido para contener el powerUp.
    [SerializeField]
    private AudioClip _audioClip;
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
        //TODO si baja de la base de la nave se destruye.
        if (this.gameObject.transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Con que colisionamos
        //Debug.Log("Choca con " + collision.name);
        //Creo un objeto de tipo clase Jugador y obtengo todos los m�todos(Componentes).
        Jugador jugador = collision.GetComponent<Jugador>();
        
        //Preguntamos si jugador no est� vac�o.
        if(jugador != null)
        {
            //Reproducimos el audio en la poscion de la c�mara o si tenemos buen equeipo de sonido en el objeto.
        AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 1f);

            //Preguntamos si hemos chocado con el powerup de triple disparo.
            if (powerUpID == 0)
            {
                //Mandamos ejecutar en Jugador el m�todo de triple disparo a true.
                jugador.TripleDisparoPowerupOn();
            }
            //Preguntamos si hemos chocado con el powerup de velocidad.
            else if (powerUpID == 1)
            {
                //Mandamos ejecutar en Jugador el m�todo de triple disparo a true.
                jugador.SuperVelocidadPowerupOn();
            }
            //Preguntamos si hemos chocado con el powerup de escudo.
            
            else if (powerUpID == 2)
            {
                //La animaci�n se hace al sprite hijo en el prefab del jugador.
                //En el prefab de jugador se a�ade como gameobject el hijo.
                //Para mostrar el sprite hijo o animaci�n, tenemos que modificarlo a activo.
                //Mandamos ejecutar en Jugador el m�todo de triple disparo a true.
                jugador.EscudoPowerupOn();
            }
        }
        
        //Destruimos el powerUp.
        Destroy(this.gameObject);
    }
}
