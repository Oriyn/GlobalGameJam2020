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
    }

    // Update is called once per frame
    void Update()
    {
        int partsCollected = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterScript>().itemCount;
        myText.text = "Parts Collected: " + partsCollected + "/3";

        
    }
}
