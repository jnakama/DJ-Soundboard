using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public int color = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        print (color);
        if (Input.GetKeyDown("p"))
        {
            if (color==1)
            {


                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                color = color + 1;


            }
         //   else if(color ==2)
          //  {
         //       gameObject.GetComponent<SpriteRenderer>().color = Color.red;
         //       color = color + 1;
           // }
            else if (color==2)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                color = 1;
            }
         //   else if (color==4)
          //  {
         //       gameObject.GetComponent<SpriteRenderer>().color = Color.white;
         //       color = 1;
         //   }
        }
    }
}
