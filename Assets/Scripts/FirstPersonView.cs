using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FirstPersonView : MonoBehaviour
{
    public GameObject characterModelUI; // Modelo del personaje para mostrar en la esquina del UI
    public Animator characterAnimatorUI; // Animator del modelo del personaje en el UI

    public GameObject characterModelMain; // Modelo del personaje en la escena principal
    public Animator characterAnimatorMain; // Animator del modelo del personaje en la escena principal

    void Update()
    {
        // Sincronizar la animación del personaje en la esquina del UI con la animación seleccionada por el jugador
        if (characterAnimatorUI != null)
        {
            string selectedAnimation = PlayerPrefs.GetString("SelectedAnimation", "Idle");
            characterAnimatorUI.Play(selectedAnimation); // Reproduce la animación seleccionada

            // Si tienes un Animator para el personaje en la escena principal, también deberías sincronizarlo
            if (characterAnimatorMain != null)
            {
                characterAnimatorMain.Play(selectedAnimation);
            }
        }
    }
}
