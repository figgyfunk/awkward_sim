using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour {

	public void normal(int scene)
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<playerManager>().happy = 0;
        player.GetComponent<playerManager>().sad = 0;
        player.GetComponent<playerManager>().disgust = 0;
        player.GetComponent<playerManager>().envy = 0;
        player.GetComponent<playerManager>().consequence = 0;
        player.GetComponent<playerManager>().angry = 0;

        SceneManager.LoadScene(scene);
    }

    public void plus(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
