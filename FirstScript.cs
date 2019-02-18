using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SecondScript : MonoBehaviour
{
    public Vector3 joe2;
    public bool buttonDown = false;
    public string myKey = "d";
    public int instrument = 1;
    public int PIANO = 1;
    public int DRUM = 2;
    public string myAudioFile = "note.mp3";
    public bool instrumentKey = false;
    public string text;
    public Color miColor = Color.blue;
    public AudioSource[] sounds;
    public AudioSource audio1;
    public AudioSource audio2;
    public Color change;
    public ArrayList userinputs;
    public int playback = -1;
    public int noteTimeout = 0;
    public bool recordOn = false;

    // Use this for initialization
    void Start()
    {
        userinputs = new ArrayList();
        if(myKey == "p")

        change = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
        Vector3 joe2;
        joe2 = transform.position;
        joe2.z = 10f;
        //joe2 = new Vector3(10f, 10f, 15f);
        transform.position = joe2;

        sounds = GetComponents<AudioSource>();
        audio1 = sounds[0];
        audio2 = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
          string []keyList = { "1", "2", "3", "4", "5", "6", "q", "w", "e", "r", "t", "y", "space", "a","s","d","f","g","h","z","x","c","v","b","n"};
        for(int i=0;i<25;i++)
        {
            if (recordOn == true)
            {
                if (Input.GetKeyDown(keyList[i]))
                {
                    userinputs.Add(keyList[i]);
                    string song = "" + userinputs.Count + ": ";
                    for (int j = 0; j < userinputs.Count; j++)
                    {
                        song = song + userinputs[j] + " ";
                    }
                    print(song);
                }
            }
        }
       

        if (Input.GetKey("9"))
        {
            instrument = PIANO;
            if (myKey.Equals("9"))
            {
                buttonDown = true;

            }
            else
            {
                buttonDown = false;
            }
        }
        else if (Input.GetKey("0"))
        {
            instrument = DRUM;
            if (myKey.Equals("0"))
            {
                buttonDown = true;
            }
            else
            {
                buttonDown = false;
            }
        }
        else if(Input.GetKeyDown("p"))
        {
            if (recordOn)
            {
                playback = 0;
                noteTimeout = 0;
                recordOn = false;
                //buttonDown = true;
            }
            else
            {
                //buttonDown = false;
                recordOn = true;
                playback = -1;
                noteTimeout = -0;
            }
        }
        else if (Input.GetKey("o"))
        {
            for (int i = userinputs.Count - 1; i > -1; i--) {
                userinputs.RemoveAt(i);
            }
        }
        else if (Input.GetKey(myKey)) //doesn't run for 9,0 
        {
            buttonDown = !buttonDown;
        }

        bool drumit = false;

        if(playback > -1)
        {
            if(playback == userinputs.Count)
            {
                playback = 0;
                noteTimeout = 0;
                //recordOn = true;
            }
            else
            {
                if(noteTimeout > 25)
                {
                    if ( myKey.Equals(userinputs[playback]))
                    {
                        drumit = true;
                        buttonDown = true;

                        
                    }
                    //recordOn = false;
                    noteTimeout = 0;
                    playback++;
                }
                else
                {
                    noteTimeout++;
                }
            }
        }

        if (buttonDown)
        {
            Vector3 joe2;
            joe2 = transform.position;
            joe2.z = 12f;
            //joe2 = new Vector3(10f, 10f, 15f);
            transform.position = joe2;
            //gameObject.GetComponent<SpriteRenderer>().color = new Color((int)(Math.random()*50)+205,)
            gameObject.GetComponent<SpriteRenderer>().color = change;

            if(drumit == true || instrument == DRUM)
            {
                audio2.Play();
            }
            else if (instrument == PIANO)
            {
            
                audio1.Play(500);
            }
            if(myKey != "p")
                buttonDown = !buttonDown;
            
        }
        else
        {
            Vector3 joe2;
            joe2 = transform.position;
            joe2.z = 10f;
            //joe2 = new Vector3(10f, 10f, 10f);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            transform.position = joe2;
            if(myKey != "p")
                change = new Color(Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f), Random.Range(0.3f, 1.0f));

        }

    }
}
