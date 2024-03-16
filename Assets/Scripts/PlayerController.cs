using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask parabolicWeaponLayer;
    public LayerMask attractorWeaponLayer;
    public LayerMask explosiveWeaponLayer; 

    public ParabolicWeapon parabolicWeapon;
    public AtractorWeapon attractorWeapon;
    public ExplosiveWeapon explosiveWeapon;

    public Transform playerCamera;
    public float mouseSensitivity = 100f;

    private bool canShootParabolic = true;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetButtonDown("Fire1"))
        {
            if (canShootParabolic)
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward, 1f);
                foreach (Collider collider in colliders)
                {
                    if ((parabolicWeaponLayer & 1 << collider.gameObject.layer) != 0)
                    {
                        parabolicWeapon?.Shoot();
                        return;
                    }
                    else if ((attractorWeaponLayer & 1 << collider.gameObject.layer) != 0)
                    {
                        attractorWeapon?.Shoot();
                        return;
                    }
                    else if ((explosiveWeaponLayer & 1 << collider.gameObject.layer) != 0)
                    {
                        Debug.Log("disparando arma explosiva");
                        explosiveWeapon?.Shoot();
                        return;
                    }
                }
            }
        }
    }

    public void SetCanShootParabolic(bool canShoot)
    {
        canShootParabolic = canShoot;
    }
}





