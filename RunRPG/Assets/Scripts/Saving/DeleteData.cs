using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeleteData : MonoBehaviour {

	public void Delete()
    {
        GameControl.GameControlMaster.Delete();
        SceneManager.LoadScene("MainMenu");
    }
}
