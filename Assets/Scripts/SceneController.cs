using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public enum Type
    {
        save, load
    }
    public Type type;
    void Start()
    {
        switch (type)
        {
            case Type.save:
                PlayerPrefs.SetString("Level",SceneManager.GetActiveScene().name);
                break;
            case Type.load:
                SceneManager.LoadScene(PlayerPrefs.GetString("Level","Level01"));
                break;
        }
        
    }

}
