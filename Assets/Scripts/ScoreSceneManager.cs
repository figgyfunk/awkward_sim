using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneManager : MonoBehaviour {

    public float waggleTimer;
    public float maxWaggle;
    public float minWaggle;
    public float shiftAmount;
    public Image bar;
    private playerManager player;
    private Sprite face;
    private bool left = true;
    private bool displayed = false;
    private float locX;
   
	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player").GetComponent<playerManager>();
        face = player.getFace();
        int final = player.chooseSprite();
        locX = ((Mathf.Abs(maxWaggle) + Mathf.Abs(minWaggle)) / player.faces.Length) * final;
        locX = 0f;

	}

    private void Update()
    {
        if(waggleTimer > 0)
        {
            if (left)
            {
                bar.gameObject.transform.Translate(-Vector3.right * Time.deltaTime * shiftAmount);
            }

            else
            {
                bar.gameObject.transform.Translate(Vector3.right * Time.deltaTime * shiftAmount);
            }

            if(bar.gameObject.transform.localPosition.x <= minWaggle)
            {
                left = false;
            }

            if(bar.gameObject.transform.localPosition.x >= maxWaggle)
            {
                left = true;
            }
            waggleTimer -= Time.deltaTime;
        }

        if( waggleTimer <= 0 && !displayed)
        {

            if(bar.transform.localPosition.x > locX)
            {
                bar.gameObject.transform.Translate(-Vector3.right * Time.deltaTime * shiftAmount);
            }

            else
            {
                bar.gameObject.transform.Translate( Vector3.right * Time.deltaTime * shiftAmount);
            }

            if(Mathf.Abs(bar.transform.localPosition.x - locX) < 1)
            {
                displayed = true;
                //do the face part here.
            }
        }

    }
}
