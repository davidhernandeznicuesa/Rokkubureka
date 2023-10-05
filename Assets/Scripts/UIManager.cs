using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// biblioteca para acceder a Image.
using UnityEngine.UI;

// Poner el script en el objeto canvas.
public class UIManager : MonoBehaviour
{
    
    //Crear una imagen que crea un canvas en Unity
    [SerializeField]
    private Sprite[] vidas;
    //Dimensionar en Unity el array.
    //Colocar en la imagen el sprite de la vida que queremos mostrar.
    //Variable de tipo imagen y cargo la imagen en Unity.
    [SerializeField]
    private Image _imagenQueQueda;
    //Variable para meter el texto del Canvas
    //Utilizar el Text de Legacy.
    [SerializeField]
    private Text _puntosText;
    //Variable de puntos
    public int puntos;
    //Varible tipo imagen para el titulo.
    [SerializeField]
    private GameObject _titulo;
    //Varible tipo imagen para el titulo.
    [SerializeField]
    private GameObject _fondo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateVidas(int vidasQuedan)
    {
        //Seleccionamos la imagen que se va a mostrar del array con el n�mero de las vidas que nos trae.
        //Y lo cargamos en la imagen del canvas.
        _imagenQueQueda.sprite = vidas[vidasQuedan];
    }
    //M�todo para actualizar los puntos.
    public void UpdatePuntos() 
    {
        //Sumar puntos.
        puntos += 10;
        //Comprobar si hemos cargado el UIManager.
        if (_puntosText != null)
        {
            //Mostrar los puntos en el canvas.
            _puntosText.text = "Puntos: " + puntos;
        }
    }
    //M�todo para mostrar la pantalla.
    public void MostrarTitulo()
    {
        //Mostrar imagen.
        _titulo.SetActive(true);
        _fondo.SetActive(true);
    }
    //M�todo para ocultar la pantalla.
    public void OcultarTitulo()
    {
        //Oculta imagen.
       _titulo.SetActive(false);
        _fondo.SetActive(false);
    }
    
}
