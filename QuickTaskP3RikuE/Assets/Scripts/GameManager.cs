using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;   
using UnityEngine.Audio;
public class GameManager : MonoBehaviour
{
    public Button restartButton;
    private GameManager gameManager;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;
    public GameObject Player;
    public float yRange = -2f;
    public GameObject EndPoint;
    public AudioSource audioSource;
    public AudioClip Sound;
    public RawImage backgroundImage;
    public float xRange = .2f;
    public GameObject targetImage;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundImage = GetComponent<RawImage>();
        Sound = GetComponent<AudioClip>();
         
    }


    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y <= yRange)
        {
           GameOver();
           
        }
        if (Player.transform.position.x >= xRange)
        {
            GameOver();
            targetImage.SetActive(true);
           
           
        }


    }
    public void PlaySound(AudioClip Clip)
    {
        audioSource.PlayOneShot(Clip);
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
