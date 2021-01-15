using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public Transform blocksParrent;
    public static Level instance;
    public string levelname;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void CheckBlocks()
    {
        if (blocksParrent.childCount == 0)
        {
            SceneManager.LoadScene(levelname);
        }
    }


}
