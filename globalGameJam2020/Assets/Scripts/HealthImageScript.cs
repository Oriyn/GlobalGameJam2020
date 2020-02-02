using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthImageScript : MonoBehaviour
{

    Image myImageComponent;
    public Sprite myFirstImage;
    public Sprite mySecondImage;
    public Sprite myThirdImage;
    public Sprite myFourthImage;
    public Sprite deadHearts;
    // Update is called once per frame
    void Update()
    {
        int playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>().playerHealth;
        if (playerHealth == 4)
        {
            SetImage1();
        } else if (playerHealth == 3)
        {
            SetImage2();
        } else if (playerHealth == 2)
        {
            SetImage3();
        } else if (playerHealth == 1)
        {
            SetImage4();
        } else if (playerHealth <= 0)
        {
            SetDeadHearts();
        } 
        else
        {
            SetImage1();
        }
        
    }

    void Start() //Lets start by getting a reference to our image component.
    {
        myImageComponent = GetComponent<Image>(); //Our image component is the one attached to this gameObject.
    }

    public void SetImage1() //method to set our first image
    {
        myImageComponent.sprite = myFirstImage;
    }

    public void SetImage2()
    {
        myImageComponent.sprite = mySecondImage;
    }

    public void SetImage3()
    {
        myImageComponent.sprite = myThirdImage;
    }

    public void SetImage4()
    {
        myImageComponent.sprite = myFourthImage;
    }

    public void SetDeadHearts()
    {
        myImageComponent.sprite = deadHearts;
    }
}
