using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que dota de acciones al agente. De manera general, realiza acciones que cambian su estado propio
// o el de su entorno/mundo.
// En este caso en particular, permite que el agente tenga movimiento.
public class Actuadores : MonoBehaviour {

	// Mueve (Translate) al objeto en la direccion hacia adelante con respecto a su vector de direccion (forward)
	public void MoverAdelante(){
        Vector3 move = new Vector3(0,0,3);
        transform.Translate(move * Time.deltaTime);
    }

    // Mueve (Translate) al objeto en la direccion hacia atrás con respecto a su vector de direccion (forward)
    public void MoverAtras() {
        Vector3 move = new Vector3(0,0,-1);
        transform.Translate(move * Time.deltaTime);
    }

	// Gira (Rotate) al objeto hacia la derecha con respecto a su posicion actual
	public void GirarDerecha(){
        Vector3 move = new Vector3(3, 0, 0);
        transform.Translate(move * Time.deltaTime);
    }

    // Gira (Rotate) al objeto hacia la izquierda con respecto a su posicion actual
    public void GirarIzquierda(){
        Vector3 move = new Vector3(-3, 0, 0);
        transform.Translate(move * Time.deltaTime);
    }

    // Aspira, borra, elimina o deja inactivo al gameObject basura dado como parámetro
    public void Aspirar(GameObject basura){
        basura.gameObject.SetActive(false);
	}

}
