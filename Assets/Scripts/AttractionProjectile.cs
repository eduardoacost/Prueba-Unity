using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionProjectile : MonoBehaviour
{
    public float attractionRadius = 5f; // Radio de atracción
    public float attractionForce = 10f; // Fuerza de atracción
    public LayerMask attractableLayers; // Capas de objetos atractables
    public float speed = 10f; // Velocidad del proyectil de atracción
    public float destroyDelay = 2f;

     void Start()
    {
        // Programar la destrucción del proyectil después de un retraso
        Invoke("DestroyProjectile", destroyDelay);
    }

    void Update()
    {
        // Mover el proyectil de atracción hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Detectar objetos cercanos dentro del radio de atracción
        Collider[] colliders = Physics.OverlapSphere(transform.position, attractionRadius, attractableLayers);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Calcular la dirección de atracción hacia el proyectil
                Vector3 direction = (transform.position - collider.transform.position).normalized;

                // Aplicar una fuerza de atracción al objeto
                rb.AddForce(direction * attractionForce, ForceMode.Force);

                // Rotar el objeto hacia el proyectil
                Quaternion targetRotation = Quaternion.LookRotation(transform.position - collider.transform.position);
                collider.transform.rotation = Quaternion.Slerp(collider.transform.rotation, targetRotation, Time.deltaTime);
            }
        }
    }
    void DestroyProjectile()
    {
        // Destruir el proyectil
        Destroy(gameObject);
    }
}


