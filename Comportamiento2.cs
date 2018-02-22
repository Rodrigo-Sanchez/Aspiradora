using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento2 : MonoBehaviour
{

    private Actuadores actuador;
    private Sensores sensor;

    // Use this for initialization
    void Start()
    {
        actuador = GetComponent<Actuadores>();
        sensor = GetComponent<Sensores>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sensor.CercaDePared())
        {
            actuador.MoverAdelante();
        }

        if (sensor.CercaDeBasura())
        {
            //Vector posBasura = sensor.GetPosicionBasura();
            actuador.GirarDerecha();
            if (sensor.FrenteBasura())
            {
                actuador.MoverAdelante();
                if (sensor.TocandoBasura())
                {
                    actuador.Aspirar(sensor.GetBasura());
                }
            }
        }
        else
        {
            actuador.MoverAdelante();
        }

    }

}
