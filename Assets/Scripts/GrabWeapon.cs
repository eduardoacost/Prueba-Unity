using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    public Transform puntoDeConexion; // Punto de conexión en el personaje para colocar el arma
    private GameObject armaEnMano; // Referencia al arma actual en la mano

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Armas"))
        {
            Debug.Log("Colisión detectada con un arma.");

            // Guarda una referencia al arma actual en la mano
            if (armaEnMano != null)
            {
                Destroy(armaEnMano); // Destruye el arma actual en la mano
            }

            // Activa el arma en el personaje
            ActivarArmaEnPersonaje(other.gameObject);
        }
    }

    void ActivarArmaEnPersonaje(GameObject nuevaArma)
    {
        // Crea una instancia de la nueva arma y la coloca en la posición correcta de la mano del personaje
        armaEnMano = Instantiate(nuevaArma, puntoDeConexion.position, puntoDeConexion.rotation);
        // Asigna el personaje como padre del arma para que se mueva con él
        armaEnMano.transform.parent = puntoDeConexion;
    }
}

