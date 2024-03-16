using System.Collections;
using System.Collections.Generic;
// ExplosiveProjectile.cs
using UnityEngine;

public class ExplosiveProjectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil de explosión
    public float lifeTime = 5f; // Tiempo de vida del proyectil antes de ser destruido
    public float explosionForce = 10f; // Fuerza de la explosión
    public float explosionRadius = 5f; // Radio de la explosión
    public LayerMask affectedLayers; // Capas de objetos afectados por la explosión

    private void Start()
    {
        // Destruir el proyectil después de cierto tiempo para evitar que se acumulen en la escena
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        // Mover el proyectil hacia adelante en su dirección de movimiento
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Realizar la explosión al colisionar
        Explode();
    }

    private void Explode()
    {
        // Detectar objetos afectados por la explosión
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, affectedLayers);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aplicar una fuerza explosiva al objeto
                Vector3 explosionDirection = collider.transform.position - transform.position;
                rb.AddForce(explosionDirection.normalized * explosionForce, ForceMode.Impulse);
            }
        }

        // Destruir el proyectil después de la explosión
        Destroy(gameObject);
    }
}

