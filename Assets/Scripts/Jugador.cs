using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jugador : MonoBehaviour
{
    //Creación de variable para capturar los ejes de movimiento, en este caso horizontal.
    public float horizontalInput;
    //Creación de variable para capturar los ejes de movimiento, en este caso vertical.
    public float verticalInput;
    //Creación de variable de velocidad. 
    public float velocidad;
    //Variable para coger el laser prefab en Unity
    [SerializeField]
    private GameObject _laserPrefab;
    //Variable de tiempo entre disparos
    [SerializeField]
    private float _EspacioEntreDisparos;
    //Variable que nos diga que ya puede disparar.
    [SerializeField]
    private float _PuedesDisparar;
    //Variable de triple disparo.
    [SerializeField]
    private bool _TripleDisparo;
    //Variable de gameObject de prefab triple disparo.
    [SerializeField]
    private GameObject _TripleDisparoPrefab;

    //Variable de más velocidad.
    [SerializeField]
    private bool _MasVelocidad;
    //Variable de escudo.
    [SerializeField]
    private bool _Escudo;
    private void Start()
    {
        this.transform.position = new Vector3(0, -3f, 0);
        velocidad = 5f;
        //Inicializamos las variables de disparo.
        _EspacioEntreDisparos = 0.25f;
        _PuedesDisparar = 0.0f;
        //Inicializamos las variables de powerups.
        _TripleDisparo = false;
        _MasVelocidad = false;
        _Escudo = false;
    }    
    void Update()
    {
        Movimiento();
        //Preguntamos si podemos disparar.
        if(Time.time > _PuedesDisparar)
        {
            //Se coloca la tecla Zeta porque el space se bloquea con las fecha drcha y abajo
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                //Llamar a Disparo.
                Disparo();
            }   
        }
    }
    public void Movimiento()
    {
        //Cargamos la variable con el eje horizontal.
        horizontalInput = Input.GetAxis("Horizontal");
        //Le decimos que se traslade hacia la derecha por la velocidad que va a desplazarse
        //por la dirección hacia la que va, positiva derecha, negativa izquierda por el
        //tiempo que gestiona la uniformidad del movimiento.
       this.transform.Translate(Vector3.right*velocidad*horizontalInput*Time.deltaTime);
        //Cargamos la variable con el eje vertical.
        verticalInput = Input.GetAxis("Vertical");
        //Le decimos que se traslade hacia la derecha por la velocidad que va a desplazarse
        //por la dirección hacia la que va, positiva derecha, negativa izquierda por el
        //tiempo que gestiona la uniformidad del movimiento.
        this.transform.Translate(Vector3.up * velocidad * verticalInput * Time.deltaTime);
        //Ponemos los límites de arriba y abajo preguntando cada límite por separado y lo reubicamos
        //en la posición de Y y mantenemos en la que esté en X.
        if (transform.position.y > 1.60f)
        {
            transform.position = new Vector3(transform.position.x, 1.60f, 0);
        }
        else if (transform.position.y < -3.65f)
        {
            transform.position = new Vector3(transform.position.x, -3.65f, 0);
        }
        if (transform.position.x > 6.60f)
        {
            transform.position = new Vector3( 6.60f, transform.position.y, 0);
        }
        else if (transform.position.x < -6.6f)
        {
            transform.position = new Vector3( -6.6f, transform.position.y, 0);
        }
    }
    public void Disparo()
    {
        //Si no es triple disparo.
        if (_TripleDisparo == false)
        {
                //El Debug se utiliza para comprobar si se entra en la línea.
                //Debug.Log("Hola");
                //Crear el objeto(cojo el objeto,cojo la posición de la nave y le sumo un vector para que
                //se coloque y le pongo rotación a 0.
                Instantiate (_laserPrefab, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
                //Establecemos el nuevo valor del tiempo de disparo.
                _PuedesDisparar = Time.time + _EspacioEntreDisparos;
        }
        else
        {
            //Creamos el disparo triple.
            Instantiate(_TripleDisparoPrefab, this.transform.position, Quaternion.identity);
        }         
    }
    //Creamos el método que activa el triple disparo.
    public void TripleDisparoPowerupOn()
    {
        //Hacemos que el powerup triple disparo se active
        _TripleDisparo = true;
    }
}
