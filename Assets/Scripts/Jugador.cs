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
    //Variable de vidas.
    public int vidas ;

    //Variable para coger el laser prefab en Unity
    [SerializeField]
    private GameObject _laserPrefab;
    //Variable de tiempo entre disparos
    [SerializeField]
    private float _espacioEntreDisparos;
    //Variable que nos diga que ya puede disparar.
    [SerializeField]
    private float _puedesDisparar;
    //Variable de triple disparo.
    [SerializeField]
    private bool _tripleDisparo;
    //Variable de gameObject de prefab triple disparo.
    [SerializeField]
    private GameObject _tripleDisparoPrefab;

    //Variable de más velocidad.
    [SerializeField]
    private bool _MasVelocidad;

    //Variable para prefab de la explosion
    [SerializeField]
    private GameObject _naveExplosion;


    ////Variable de escudo.
    [SerializeField]
    private bool _escudo;
    ////Variable de gameObject de prefab triple disparo.
    [SerializeField]
    private GameObject _escudoHijo;
    //El no mostrar el escudo era porque no le había puesto el escudo hijo del jugador de dentro del prefab.

    //Variable de gameObject para coger métodos.
    private GameManager _gameManager;

    //Creo una variable de UIManager para acceder a ella.
    private UIManager _uiManager;

    //Variable de tipo sonido para contener el laser.
    private AudioSource _audioSource;

    
    private void Start()
    {
        this.transform.position = new Vector3(0, -3f, 0);
        velocidad = 5f;
        //Inicializamos las variables de disparo.
        _espacioEntreDisparos = 0.25f;
        _puedesDisparar = 0.0f;
        //Inicializamos las variables de powerups.
        _tripleDisparo = false;
        _MasVelocidad = false;
        _escudo = false;
        //Pongo el número de vidas.
        vidas = 3;
        //Cargo la clase de GameManager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Cargo UIManager y pregunto si está.  
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        ////Preguntamos si se ha cargado los componentes.
        if (_uiManager != null)
        {
            //llamamos al método de UImanager para mandarle las vidas
            _uiManager.UpdateVidas(vidas);
        }
        //Cojo el componente de sonido audioSource
        _audioSource = GetComponent<AudioSource>();
        
    }    
    void Update()
    {
        Movimiento();
        //Preguntamos si podemos disparar.
        if (Time.time > _puedesDisparar)
        {
            //Se coloca la tecla Zeta porque el space se bloquea con las fecha drcha y abajo
            if (Input.GetKeyDown(KeyCode.Space) || SimpleInput.GetButtonDown("Fire1"))
            {
                //Llamar a Disparo.
                Disparo();
                }   
            }
        }
    public void Movimiento()
    {
        ////Cargamos la variable con el eje horizontal.
        //horizontalInput = Input.GetAxis("Horizontal");
        ////Cargamos la variable con el eje vertical.
        //verticalInput = Input.GetAxis("Vertical");
        //Cargamos la variable con el eje horizontal.
        horizontalInput = SimpleInput.GetAxis("Horizontal");
        ////Cargamos la variable con el eje vertical.
        verticalInput = SimpleInput.GetAxis("Vertical");

        if (_MasVelocidad == true)
        {
            //Multiplicamos por la supervelocidad.
            this.transform.Translate(Vector3.right * velocidad * 3f * horizontalInput * Time.deltaTime);
            this.transform.Translate(Vector3.up * velocidad * 3f * verticalInput * Time.deltaTime);
        }
        else
        {
            //Le decimos que se traslade hacia la derecha por la velocidad que va a desplazarse
            //por la dirección hacia la que va, positiva derecha, negativa izquierda por el
            //tiempo que gestiona la uniformidad del movimiento.
            this.transform.Translate(Vector3.right * velocidad * horizontalInput * Time.deltaTime);
            //Le decimos que se traslade hacia la derecha por la velocidad que va a desplazarse
            //por la dirección hacia la que va, positiva derecha, negativa izquierda por el
            //tiempo que gestiona la uniformidad del movimiento.
            this.transform.Translate(Vector3.up * velocidad * verticalInput * Time.deltaTime);
        //Ponemos los límites de arriba y abajo preguntando cada límite por separado y lo reubicamos
        //en la posición de Y y mantenemos en la que esté en X.
        }
       //Arriba
        if (transform.position.y > 1.60f)
        {
            //posición x, le mantengo la posición y.
            transform.position = new Vector3(transform.position.x, 1.60f, 0);
        }
        else if (transform.position.y < -3.65f)
        {
            transform.position = new Vector3(transform.position.x, -3.65f, 0);
        }
        //Laterales
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
        //Preguntamos si podemos disparar.
        if (Time.time > _puedesDisparar)
        {
            //Reproducir el audio del disparo.
            _audioSource.Play();
             //Si no es triple disparo.
            if (_tripleDisparo == false)
            {
                print("Hola");
                //Crear el objeto(cojo el objeto,cojo la posición de la nave y le sumo un vector para que
                //se coloque y le pongo rotación a 0.
                Instantiate (_laserPrefab, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            }
            else
            {
               
                //Creamos el disparo triple.
                Instantiate(_tripleDisparoPrefab, transform.position + new Vector3(0, 0.65f, 0), Quaternion.identity);
            }     
            //Establecemos el nuevo valor del tiempo de disparo.
                _puedesDisparar = Time.time + _espacioEntreDisparos;
        }
    }
    //Creamos el método que activa el triple disparo.
    public void TripleDisparoPowerupOn()
    {
        //Hacemos que el powerup triple disparo se active.
        _tripleDisparo = true;
        // Llamamos a la coroutine y la inicializamos.
        StartCoroutine(TripleshotPowerRoutine());
    }
        // Tiempo de espera del triple disparo.
    public IEnumerator TripleshotPowerRoutine()
    {
        //Establece el nuevo tempo de espera.
        yield return new WaitForSeconds(5.0f);
        //Desactivamos el powerup.
        _tripleDisparo = false;
    }
    public void SuperVelocidadPowerupOn()
    {
        //Hacemos que el powerup super velocidad se active.
        _MasVelocidad = true;
        // Llamamos a la coroutine y la inicializamos.
        StartCoroutine(SuperVelocidadPowerRoutine());
    }
    // Tiempo de espera del triple disparo.
    public IEnumerator SuperVelocidadPowerRoutine()
    {
        //Establece el nuevo tempo de espera.
        yield return new WaitForSeconds(5.0f);
        //Desactivamos el powerup.
        _MasVelocidad = false;
    }

    public void EscudoPowerupOn()
    {
        //Hacemos que el powerup escudo se active.
        _escudo = true;
        //Activamos que sea visible el escudo.
        _escudoHijo.SetActive(true);
        // Llamamos a la coroutine y la inicializamos.
        StartCoroutine(EscudoPowerRoutine());
    }
    // Tiempo de espera del triple disparo.
    public IEnumerator EscudoPowerRoutine()
    {
        //Establece el nuevo tempo de espera.
        yield return new WaitForSeconds(5.0f);
        //Desactivamos el powerup.
        _escudo = false;
        //Desactivamos que sea visible el escudo.
        _escudoHijo.SetActive(false);
    }
    //Método para quitar las vidas.
    public void Damage()
    {
        //Preguntamos si el escudo está activado.
        if (_escudo == true)
        {
            //Desactivamos el escudo.
            _escudo = false;
            //Dejamos de ver el escudo.
            _escudoHijo.SetActive(false);
            //Termino el método.
            return;
        }
        //Quitamos una vida.
        vidas--;
        //Llamo al método de UpdateVidas y le mando las vidas que quedan.
        _uiManager.UpdateVidas(vidas);
        //Preguntamos si quedan vidas.
        if (vidas < 1)
        {
            //Vuelvo a estar en juego para crear una nueva vida.
            _gameManager.game = true;

            //Mostrar el título.
            _uiManager.MostrarTitulo();
            
            //Creamos la explosión.
            Instantiate(_naveExplosion, transform.position, Quaternion.identity);

            //Destruimos la nave.
            Destroy(this.gameObject);
        }
    }
}
