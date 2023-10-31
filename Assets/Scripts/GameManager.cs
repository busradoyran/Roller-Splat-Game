using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] grounds;
    public float groundNum;
    private int currentLevel;
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        groundNum = grounds.Length;
    }

    public void LevelUpdate()
    {
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }
}
