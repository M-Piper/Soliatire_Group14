using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class gameLogic : MonoBehaviour
{
    public Sprite[] theCardImages;
    public GameObject cardPrefab;

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
        shuffle(fulldeck);

        //temp test displays cards in console
        foreach (string card in fulldeck)
        {
            print(card);

        }
        //remove above test in sprint 2

        dealDeck();

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

    //shuffle accepts the list of 52 cards and then reorders them with the .Random function
    void shuffle<T>(List<T> list)
    {
        
        System.Random random = new System.Random();
        //count is counting through the list of 52 accepted into the method as list<T>
        int count = list.Count;
        
        //while loop to go through everything in the list (52 cards)
        while (count > 1)
        {
            //randomCard is taking one of the 52 values
            int randomCard = random.Next(count);
            
            //subtract from count value
            count--;

            //instantiating a new list
            T newShuffle = list[randomCard];


            //adding the current random card to the list
            list[randomCard] = list[count];
            
            //assigning the list as it stands to the newShuffle variable
            list[count] = newShuffle;
        }

    }

    //first attempt at deal - will display full deck in one line for now
    void dealDeck()
    {
        //shows the cards fanned out vertically
        float yOffset = 0;
        float zOffset = 0.03f;

        foreach (string card in fulldeck)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z - zOffset), Quaternion.identity); 

            newCard.name= card;

            //temporarily testing display of cards all face up
            newCard.GetComponent<Selectable>().faceUp = true;

            //adjusting offset so that the fan function continues for each card as the loop continues
            yOffset = yOffset + 0.3f;
            zOffset = zOffset + 0.03f;
        }

    }



}
