using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;
    public Text DieText;

    private void Start()
    {
        DieText.text = "";
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            DieText.text = "You Are Dead!";
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
