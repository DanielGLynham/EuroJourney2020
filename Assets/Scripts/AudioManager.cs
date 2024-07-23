using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private BTNManager btnm;
    public AudioSource efxSource;                   //This will be what plays the sound effects
    public AudioSource musicSource;                 //This will be what plays the music if we have any
    public static AudioManager instance = null;     //Allows scripts to call audioManager
    public float lowPitchRange = .95f;              //High pitch 
    public float highPitchRange = 1.05f;            //Low pitch
    public AudioClip kicking, btnPress, cheering, cheeringShort, crowdGroaning, diceRoll;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);                    //Makes sure there is only one instance of SoundManager

        DontDestroyOnLoad(gameObject);

    }
    private void Start()
    {
        btnm = this.gameObject.GetComponent<BTNManager>();
    }
    public void PlaySingle(AudioClip clip)
    {
        if(!btnm.GetSoundsOff())
        {
            //Debug.Log("Played clip");
            efxSource.clip = clip;
            efxSource.Play();
        }
    }
    public void PlaySingle(int i)
    {
        if (!btnm.GetSoundsOff())
        {
            AudioClip clip;
            switch (i)
            {
                case 0:
                    clip = kicking;
                    break;
                case 1:
                    clip = btnPress;
                    break;
                case 2:
                    clip = cheering;
                    break;
                case 3:
                    clip = cheeringShort;
                    break;
                case 4:
                    clip = crowdGroaning;
                    break;
                case 5:
                    clip = diceRoll;
                    break;
                default:
                    clip = btnPress;
                    break;
            }
            efxSource.clip = clip;
            efxSource.Play();
        }
    }
}
    
