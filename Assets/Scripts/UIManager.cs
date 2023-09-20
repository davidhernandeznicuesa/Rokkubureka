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



//TODO1
    //En Unity crear text y anclamos

    //public Text puntos;
    //TODO1
    

    //Método de actualizar las vidas pasando las que quedan por parametros.

    //Método para actualizar los puntos.
    //Método para mostrar la pantalla.
    //Método para ocultar la pantalla.


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
        //Seleccionamos la imagen que se va a mostrar del array con el número de las vidas que nos trae.
        //Y lo cargamos en la imagen del canvas.
        _imagenQueQueda.sprite = vidas[vidasQuedan];
    }
}
