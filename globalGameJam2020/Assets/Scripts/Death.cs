using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    Image myImageComponent;
    public Sprite myFirstImage;
    // Start is called before the first frame update

    void Start() //Lets start by getting a reference to our image component.
    {
        gameObject.GetComponent<Image>().enabled = false;//Our image component is the one attached to this gameObject.
    }

    private void Update()
    {
        var isDead = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>().dying;
        if (isDead)
        {
            gameObject.GetComponent<Image>().enabled = true;
            myImageComponent = GetComponent<Image>();
            SetImage1();
        } 
    }

    public void SetImage1() //method to set our first image
    {
        myImageComponent.sprite = myFirstImage;
    }
}
