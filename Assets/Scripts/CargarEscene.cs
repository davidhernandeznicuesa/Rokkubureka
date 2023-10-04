using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Biblioteca para meter botones canvas.
using UnityEngine.SceneManagement;


public class CargarEscene : MonoBehaviour
{

   public void Cargarescena()
    {
        SceneManager.LoadScene(1);
    }
}
