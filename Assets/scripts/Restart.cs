using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

    //public GameObject win;

    public void PlayerRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //win.SetActive(false);
    }

}
