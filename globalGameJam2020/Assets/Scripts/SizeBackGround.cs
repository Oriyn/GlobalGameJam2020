using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeBackGround : MonoBehaviour
{
    Image myImageComponent;
    public Sprite myFirstImage;
    // Start is called before the first frame update

    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            gameObject.GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
        }
    }

    public void SetImage1() //method to set our first image
    {
        myImageComponent.sprite = myFirstImage;
    }
}
