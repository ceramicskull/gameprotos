using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Text score;
    public Text distance;
    private float startTimeScale;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        startTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GameOver()
    {
        score.text = distance.text;
        Time.timeScale = 0;

        
    }
    void Retry(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = startTimeScale;

    }
}
