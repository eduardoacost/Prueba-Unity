using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject character; // Referencia al personaje
    public Button[] animationButtons; // Arreglo de botones para las animaciones
    public Button startButton; // Botón para iniciar el juego

    private Animator animator;
    private string[] animationNames = new string[3]; // Nombres de las animaciones asociadas a cada botón
    private string selectedAnimation; // Animación seleccionada por el jugador

    private void Start()
    {
        animator = character.GetComponent<Animator>();

        // Asignar eventos a los botones de animación
        for (int i = 0; i < animationButtons.Length; i++)
        {
            int index = i; // Variable local necesaria para evitar problemas de cierre
            animationButtons[i].onClick.AddListener(() => SelectAnimation(index));
        }

        // Deshabilitar el botón de inicio al inicio del juego
        startButton.interactable = false;

        // Asignar nombres de animaciones
        animationNames[0] = "House Dancing"; // Nombre de la animación para el primer botón
        animationNames[1] = "Macarena Dance"; // Nombre de la animación para el segundo botón
        animationNames[2] = "Wave Hip Hop Dance"; // Nombre de la animación para el tercer botón
    }

    // Método para seleccionar una animación
    public void SelectAnimation(int animationIndex)
    {
        // Obtener el nombre de la animación asociada al botón
        selectedAnimation = animationNames[animationIndex];

        // Cambiar la animación del personaje
        animator.Play(selectedAnimation);

        // Habilitar el botón de inicio
        startButton.interactable = true;
    }

    // Método para iniciar el juego (llamado desde el botón)
    public void StartGame()
    {
        // Si no se ha seleccionado ninguna animación, no hacer nada
        if (string.IsNullOrEmpty(selectedAnimation))
            return;

        // Guardar la animación seleccionada para la próxima escena
        PlayerPrefs.SetString("SelectedAnimation", selectedAnimation);

        SceneManager.LoadScene("Game");
    }
}
