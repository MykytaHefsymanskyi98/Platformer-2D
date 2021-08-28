using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour
{
    //conf param
    [SerializeField] int playerHealth = 3;
    [SerializeField] Text currentCoinAmmountText;
    [SerializeField] GameObject playerAppearPoint;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject consistentObjects;
    [Header("Images")]
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Image image3;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite spriteRed;
    //references
    Player player;

    //states
    int currentCoinAmmount = 0;
    float gameSpeed = 1f;
    bool pauseOn = false;
    int startingPlayerHealth = 3;

    private void Awake()
    {
        GameManagerSingleton();
    }

    void Start()
    {    
        currentCoinAmmountText.text = currentCoinAmmount.ToString();
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    private void Update()
    {   
        
        Pause();

    }

    //Player processes
    public void PlayerGetHit()
    {
        playerHealth--;
        ShowPlayerHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }

    public void ProcessPlayerDamageLevel()
    {
        player = FindObjectOfType<Player>();
        if (playerHealth > 1)
        {
            PlayerGetHit();
        }
        else
        {
            RestartGame();
        }
    }

    void ShowPlayerHealth()
    {
        if (playerHealth < 1)
        {
            image1.GetComponent<Image>().sprite = sprite1;
        }
        else if (playerHealth == 1)
        {
            image2.GetComponent<Image>().sprite = sprite1;
        }
        else if (playerHealth == 2)
        {
            image3.GetComponent<Image>().sprite = sprite1;
        }
    }

    //Score processing
    public void CoinPlus()
    {
        currentCoinAmmount++;
        currentCoinAmmountText.text = currentCoinAmmount.ToString();
    }

    public int CurrentScore()
    {
        return currentCoinAmmount;
    }

    //SceneLoading processing
    public void RestartGame()
    {
        playerHealth--;
        ShowPlayerHealth();
        StartCoroutine(WaitAndLoadCoroutine());      
    }

    IEnumerator WaitAndLoadCoroutine()
    {       
        player.GetComponent<Animator>().SetBool("gotHit", true);
        player.SetIsAlive(false);
        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        ShowGameOverMenu();
    }

    void GameManagerSingleton()
    {
        int gameManagerCount = FindObjectsOfType<GameManagement>().Length;
        if(gameManagerCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyGameManager()
    {
        Destroy(this.gameObject);
    }

    private void ShowGameOverMenu()
    {
        Time.timeScale = 0f;
        gameOverCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Time.timeScale = gameSpeed;
        gameOverCanvas.SetActive(false);
        Cursor.visible = false;
        playerHealth = startingPlayerHealth;
        image1.GetComponent<Image>().sprite = spriteRed;
        image2.GetComponent<Image>().sprite = spriteRed;
        image3.GetComponent<Image>().sprite = spriteRed;
        currentCoinAmmount = 0;
        currentCoinAmmountText.text = currentCoinAmmount.ToString();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void LoadMainMenu()
    {
        gameOverCanvas.SetActive(false);
        DestroyGameManager();
        FindObjectOfType<ConsistantObjects>().DestroyConsistentObjects();
        Time.timeScale = gameSpeed;
        SceneManager.LoadScene(0);
    }

    //Pause processing
    private void Pause()
    {
        if (Input.GetButtonDown("Cancel") && SceneManager.GetActiveScene().name != "Last Level" && !pauseOn)
        {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        Cursor.visible = true;
        pauseOn = true;
        }
        else if(Input.GetButtonDown("Cancel") && pauseOn)
        {
            PauseOff();
        }
           
    }

    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = gameSpeed;
        Cursor.visible = false;
        pauseOn = false;
    }

     void PauseOff()
    {
            pauseCanvas.SetActive(false);
            Time.timeScale = gameSpeed;
            Cursor.visible = false;
            pauseOn = false;  
    }
}
