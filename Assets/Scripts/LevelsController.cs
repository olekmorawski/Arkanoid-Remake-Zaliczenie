using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsController : MonoBehaviour
{

    public void Level1Button()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Level2Button()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3Button()
    {
        SceneManager.LoadScene("Level3");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}