using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Singletron : MonoBehaviour
{
    // Singleton instance
    public static Singletron instance;

    // Array of interactable game objects
    public GameObject[] interativos;

    // Array of lanes
    private float[] lanes = new float[3] { -7f, 0f, 7f };

    // Text displaying the score
    public TMP_Text pontuacaoText;

    // Canvas for game over UI
    // Score
    public int score = 0;
    public GameObject Restart;

    void Awake()
    {
        Restart.SetActive(false);

        // Ensure only one instance of the Singleton exists
        if (instance == null)
        {
            instance = this;
            // Make the GameObject persist across scenes
         

        }
        else
        {
            // If another instance already exists and it's not this one, destroy this one
            if (instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        // Set GameOverCanvas to inactive if it's not already
        
    }

    void Start()
    {
        // Start spawning 
        InvokeRepeating(nameof(InstanciarObjetos), 0.5f, 1f);
    }

    // Method to spawn objects
    public void InstanciarObjetos()
    {
        int index = Random.Range(0, interativos.Length);
        int randX = Random.Range(0, lanes.Length);
        GameObject selecionado = interativos[index];
        Vector3 newPos = new Vector3(lanes[randX], transform.position.y, transform.position.z);
        Instantiate(selecionado, newPos, Quaternion.identity);
    }

    // Method to handle game over
    public void GameOver()
    {
        // Set time scale to 0 to pause the game
        Time.timeScale = 0f;
        // Show game over canvas
        Restart.SetActive(true);

    }

    // Method to restart the game
    public void RestartGame()
    {
        // Reset the score
        score = 0;
        pontuacaoText.text = score.ToString();
        SceneManager.LoadScene(0);
        // Reset the time scale
        Time.timeScale = 1f;

        // Deactivate the game over canvas if it exists

        // Reload the first scene
        
    }



    // Method to update the score
    public void UpdateScore()
    {
        score++;
        pontuacaoText.text = score.ToString();
    }
}
