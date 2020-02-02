using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class PartUpdate : MonoBehaviour
{

    Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        myText.text = "Collect all the parts";
    }

    // Update is called once per frame
    void Update()
    {
        bool isRocketRepairing = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>().isRocketRepairing;
        bool isRocketReady = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>().isRocketReady;
        int partsCollected = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>().itemCount;
        if (partsCollected >= 3)
        {
            myText.text = "Go repair your rocket";
        }
        if (isRocketRepairing)
        {
            myText.text = "Repairing Rocket....";
        }
        if (isRocketReady)
        {
            myText.text = "Jump in your rocket!";
        }
    }
}
