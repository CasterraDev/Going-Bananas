using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ChangeLevel(string str)
    {
        SceneManager.LoadScene(str);
    }
}
