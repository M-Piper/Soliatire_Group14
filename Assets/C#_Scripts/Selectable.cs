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
            char c2 = transform.name[1];
            valueString = valueString + c.ToString() + c2.ToString();
            }
            if (valueString == "ac")
            {
                value = 1;
            }
            if (valueString == "2_")
            {
                value = 2;
            }
            if (valueString == "3_")
            {
                value = 3;
            }
            if (valueString == "4_")
            {
                value = 4;
            }
            if (valueString == "5_")
            {
                value = 5;
            }
            if (valueString == "6_")
            {
                value = 6;
            }
            if (valueString == "7_")
            {
                value = 7;
            }
            if (valueString == "8_")
            {
                value = 8;
            }
            if (valueString == "9_")
            {
                value = 9;
            }
            if (valueString == "10")
            {
                value = 10;
            }
            if (valueString == "ja")
            {
                value = 11;
            }
            if (valueString == "qu")
            {
                value = 12;
            }
            if (valueString == "ki")
            {
                value = 13;
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
