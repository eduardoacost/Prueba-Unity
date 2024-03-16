using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData[] weaponDatas;

    void Start()
    {
        // Cargar los datos de arma desde los ScriptableObjects
        foreach (var weaponData in weaponDatas)
        {
            // Aquí puedes hacer lo que quieras con los datos de arma cargados
            Debug.Log("Arma cargada: " + weaponData.weaponName);
        }
    }
}
