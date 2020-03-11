using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu menu;
    public GameObject scorePanel;
    public Text scoreText;

    private void Awake()
    {
        if (menu == null)
        {
            menu = this;
        }
        else
        {
            Debug.Log("Menu is create");
        }
    }

    public void Open(int score)
    {
        scoreText.text = $"{score}";
        scorePanel.SetActive(true);
        Time.timeScale = 0;
    }


    public void Close()
    {   
        scorePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retry(int scene)
    {
        SceneManager.LoadSceneAsync(scene); 
    }
}
