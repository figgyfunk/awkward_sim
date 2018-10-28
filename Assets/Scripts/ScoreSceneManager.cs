using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSceneManager : MonoBehaviour {

    public AudioClip song;
    public float defaultValue;
    public float waggleTimer;
    public float maxWaggle;
    public float minWaggle;
    public float shiftAmount;
    public Slider rightSlider;
    public Slider leftSlider;
    private playerManager player;
    public Image face;
    private bool left = true;
    private bool displayed = false;
    private int final;
    private bool centered = false;
    private float converted;
    private int i;
    private musicManager music;
    
   
	// Use this for initialization
	void Start ()
    {
        music = GameObject.Find("MusicManager").GetComponent<musicManager>();
        music.pause();
        music.setSong(song);
        music.play();
        player = GameObject.Find("Player").GetComponent<playerManager>();
        face.sprite = player.getFace();
        final = player.chooseSprite();
        if(final == 3)
        {
            converted = .5f;
        }
        else if(final == 4)
        {
            converted = 1f;
        }
        else if(final == 1)
        {
            converted = .5f;
        }
        else if(final == 0)
        {
            converted = 1f;
        }
 

	}

    private void Update()
    {
        if(waggleTimer > 0)
        {
            if (left && rightSlider.value == 0)
            {
                leftSlider.value += Time.deltaTime;
                if (leftSlider.value == 1) { left = false; }
            }
            else if (left)
            {
                rightSlider.value -= Time.deltaTime;
            }
            else if( !left && leftSlider.value != 0)
            {
                leftSlider.value -= Time.deltaTime;
            }

            else
            {
                rightSlider.value += Time.deltaTime;
                if(rightSlider.value == 1)
                {
                    left = true;
                }
            }
            waggleTimer -= Time.deltaTime;
        }

        if( waggleTimer <= 0 && !displayed)
        {
            if(rightSlider.value != 0 && !centered)
            {
                rightSlider.value -= Time.deltaTime;
            }
            if(leftSlider.value != 0 && !centered)
            {
                leftSlider.value -= Time.deltaTime;
            }

            if (leftSlider.value == 0 && rightSlider.value == 0)
            {

                centered = true;
            }
            if (centered)
            {
                if (final > 2)
                {
                    if (leftSlider.value < converted)
                    {
                        leftSlider.value += Time.deltaTime;
                    }
                    else
                    {
                        displayed = true;
                        face.gameObject.SetActive(true); 
                    }
                }
                else if (final < 2)
                {
                    if (rightSlider.value < converted)
                    {
                        rightSlider.value += Time.deltaTime;
                    }
                    else
                    {
                        displayed = true;
                        face.gameObject.SetActive(true);
                    }
                }
                else
                {
                    displayed = true;
                    face.gameObject.SetActive(true);
                }
            }
                
        }
        

    }
}
