using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Biblioteca para meter botones canvas.
using UnityEngine.SceneManagement;


public class CargarEscene : MonoBehaviour
{
    //Carga escenas
    public void Cargarescena(string NombreEscena)
    {
        SceneManager.LoadScene(NombreEscena);
    }
    //Cierra aplicación.
    public void CerrarAplicacion()
    {
        Application.Quit();
    }
}
