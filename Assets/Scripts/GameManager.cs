using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tiempo;
    // Variable que contenga el asteroide.
    [SerializeField]
    private GameObject _asteroide;
    //Variable que contenga al jugador.
    [SerializeField]
    private GameObject _jugadorPrefab;


    void Start()
    {
        //Inicio de la corrutina
        StartCoroutine(Asteroides());
        tiempo = 2f;
        //Creamos el jugador
        Instantiate(_jugadorPrefab, Vector3.zero, Quaternion.identity);
    }
    private void Update()
    {
        
    }
    // Para controlar el tiempo con la corrutina
    IEnumerator Asteroides()
    {
        //Creo un bucle que va a ir creando los asteroides.
        while (true)
        {
            //Creo el asteroide.
            Instantiate(_asteroide, new Vector3(Random.Range(-6.3f,6.3f), 5.8f, 0), Quaternion.identity);
            //Darle el tiempo entre uno y otro asteroide.
            yield return new WaitForSeconds(tiempo);
        }
    }
}
