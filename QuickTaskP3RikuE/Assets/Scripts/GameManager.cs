using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   

public class GameManager : MonoBehaviour
{
    public Button restartButton;
    private GameManager gameManager;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    public GameObject Player;
    public float yRange = -2f;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y <= yRange)
        {
           GameOver();
           Object.Destroy(Player);
        }

    }
    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
           gameManager.GameOver();
        }
        if (other.CompareTag("Player"))
        {
            GameOver();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
