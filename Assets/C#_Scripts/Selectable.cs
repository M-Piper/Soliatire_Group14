using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool faceUp = false;
    public bool inDeckPile = false;
    public bool top = false;
    public string suit;
    public string test;
    public int value;
    public int row;

    private string valueString;

    void Start()
    {
        if (CompareTag("Card"))
        {      
            test = transform.name[name.Length - 2].ToString();
            if (test == "b")
            {
                suit = "c";
            }
            if (test == "t")
            {
                suit = "h";
            }
            if (test == "e")
            {
                suit = "s";
            }
            if (test =="d")
            {
                suit = "d";
            }

            char c = transform.name[0];
            valueString = valueString + c.ToString();
            }
            if (valueString == "a")
            {
                value = 1;
            }
            if (valueString == "2")
            {
                value = 2;
            }
            if (valueString == "3")
            {
                value = 3;
            }
            if (valueString == "4")
            {
                value = 4;
            }
            if (valueString == "5")
            {
                value = 5;
            }
            if (valueString == "6")
            {
                value = 6;
            }
            if (valueString == "7")
            {
                value = 7;
            }
            if (valueString == "8")
            {
                value = 8;
            }
            if (valueString == "9")
            {
                value = 9;
            }
            if (valueString == "10")
            {
                value = 10;
            }
            if (valueString == "j")
            {
                value = 11;
            }
            if (valueString == "q")
            {
                value = 12;
            }
            if (valueString == "k")
            {
                value = 13;
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
