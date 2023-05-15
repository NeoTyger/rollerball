using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    
    public Transform puntoInicial;
    public Transform punto2;
    public Transform punto3;
    public Transform puntoFinal;
    public float velocidadMovimiento = 7.0f;

    private bool haciaDestino = true;
    private Transform[] puntos;
    private int puntoActual = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        puntos = new Transform[] { puntoInicial, punto2, punto3, puntoFinal };
        transform.position = puntoInicial.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((puntos[puntoActual].position - transform.position).normalized * velocidadMovimiento * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, puntos[puntoActual].position) < 0.1f)
        {
            puntoActual++;
            if (puntoActual >= puntos.Length)
            {
                puntoActual = 0;
            }
        }
    }
}
