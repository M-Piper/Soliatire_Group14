using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class gameLogic : MonoBehaviour
{
    public Sprite[] theCardImages;
    
    public static string[] fourSuits = new string[] { "clubs", "diamonds", "hearts", "spades" };
    public static string[] suitValues = new string[] { "ace_of_", "2_of_", "3_of_", "4_of_", "5_of_", "6_of_", "7_of_", "8_of_", "9_of_", "10_of_", "jack_of_", "queen_of_", "king_of_"};


    public List<string> fulldeck;

    void Start()
    {
        dealCards();
        
    }

    
    void Update()
    {
        
    }

    public void dealCards()
    {
        fulldeck = createDeck();

        foreach (string card in fulldeck)
        {
            print(card);

        }
    }

    public static List<string> createDeck()
        {
        List<string> newDeck = new List<string>();
        foreach (string s in fourSuits)
        {
            foreach (string v in suitValues)
            {
                newDeck.Add(v + s);
            }
        }
        return newDeck; 
    }

    void Shuffle<X>(List<X> list)
    {
        //come up with method of shuffling

    }


}
