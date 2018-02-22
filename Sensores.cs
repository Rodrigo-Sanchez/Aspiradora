using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que percibe el mundo a su alrededor y brinda información al respecto.
// Para este caso en particular nos brinda información (true/false) sobre qué tan cerca
// se encuentra el agente de otros objetos en el mundo.
public class Sensores : MonoBehaviour {

    // Variables auxiliares para recordar si hay colisiones
    public bool isTouchingBasura = false;
    private bool isTouchingPared = false;
    private bool isInFrontOfBasura = false;
    private bool isInFrontOfPared = false;
    private GameObject basura;

    private VisionController radar; // Componente (script) externo
    public float rayDistance; // Longitud de rayo/linea para "mirar" al frente

    // Inicialización: Obtener el componente (script) del gameObject "Vision"
    void Start() {
        radar = GameObject.Find("Vision").gameObject.GetComponent<VisionController>();
    }

    // En cada frame lanzar un rayo/linea para verificar qué objeto está frente al agente
    void FixedUpdate() {
        RaycastHit raycastHit; // Auxiliar que almacena la información del contacto con el rayo
        if (Physics.Raycast(transform.position, transform.forward, out raycastHit, rayDistance)) {
            if (raycastHit.collider.gameObject.CompareTag("Basura"))
                isInFrontOfBasura = true;
            if (raycastHit.collider.gameObject.CompareTag("Pared"))
                isInFrontOfPared = true;
        } else {
            isInFrontOfBasura = false;
            isInFrontOfPared = false;
        }
    }

    // En cada frame dibujar una linea de color para representar lo que el agente está viendo al frente
    void Update() {
        Debug.DrawLine(transform.position, transform.position + transform.forward * rayDistance, Color.green);
    }

    // Los siguientes métodos verifican las posibles colisiones del agente (el cubo que representa la aspiradora) 
    // con otros objetos tales como las basuras y paredes.
    // Recordar que los métodos "OnCollision" funcionan con objetos sólidos (como paredes)
    // y los métodos "OnTrigger" funcionan con objetos no-solidos (como las basuras)
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Basura"))
            isTouchingBasura = true;
    }

    void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Basura"))
            isTouchingBasura = true;
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Basura"))
        {
            isTouchingBasura = false;
            basura = null;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Basura"))
        {
            isTouchingBasura = true;
            basura = other.gameObject;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Basura"))
            isTouchingBasura = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Basura"))
            isTouchingBasura = false;
    }

    // Los siguientes métodos son públicos y su intención es brindar información:
    public bool TocandoBasura() {
        return isTouchingBasura;
    }

    public bool TocandoPared() {
        return isTouchingPared;
    }

    public bool FrenteBasura() {
        return isInFrontOfBasura;
    }

    public bool FrentePared() {
        return isInFrontOfPared;
    }

    // Estos últimos métodos obtienen la información pública de otros scripts:
    public bool CercaDeBasura() {
        return radar.CercaBasura();
    }

    public bool CercaDePared() {
        return radar.CercaPared();
    }

    public Vector3 GetPosicionBasura()
    {
        if (basura != null)
        {
            return basura.transform.position;
        }
        return Vector3.zero;
    }

    public GameObject GetBasura()
    {
        return basura;
    }
}
