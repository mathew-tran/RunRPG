using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStore : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public void Load()
    {
        SceneManager.LoadScene("Shop");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
