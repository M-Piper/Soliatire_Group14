using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class gameLogic : MonoBehaviour
{
    public Sprite[] theCardImages;
    public GameObject cardPrefab;
    public GameObject[] bottomTab;
    public GameObject[] topTab;

    public static string[] fourSuits = new string[] { "clubs", "diamonds", "hearts", "spades" };
    public static string[] suitValues = new string[] { "ace_of_", "2_of_", "3_of_", "4_of_", "5_of_", "6_of_", "7_of_", "8_of_", "9_of_", "10_of_", "jack_of_", "queen_of_", "king_of_"};
    public List<string>[] bottoms;
    public List<string>[] tops;

    private List<string> bottom0 = new List<string>();
    private List<string> bottom1 = new List<string>();
    private List<string> bottom2 = new List<string>();
    private List<string> bottom3 = new List<string>();
    private List<string> bottom4 = new List<string>();
    private List<string> bottom5 = new List<string>();
    private List<string> bottom6 = new List<string>();

    public List<string> fulldeck;

    void Start()
    {   //instantiate a list of strings for each of the tableau's 7 spots)
        bottoms = new List<string>[] { bottom0, bottom1, bottom2, bottom3, bottom4, bottom5, bottom6 };
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
        //above is just for testing purposes

        SolitaireSort();
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
        //this loop creates an integer so that values can be displayed correctly in each of the 7 'bottom tab' or Tableau locations
        for (int i = 0; i < 7; i++)
        {
            //shows the cards fanned out vertically
            float yOffset = 0;
            float zOffset = 0.03f;

            //loops through each of the 7 tableau (or 'bottom') locations
            //in sprint 1 this looped through the whole deck and displayed it all in one long column (for testing) by looping through 'full deck'
            foreach (string card in bottoms[i])
            {
                //bottomTab[i] identifies each of the 7 bottom positions
                //offset variable indicate offsetting so that cards appear fanned out (rather than stacked so you only see the top card)
                GameObject newCard = Instantiate(cardPrefab, new Vector3(bottomTab[i].transform.position.x, bottomTab[i].transform.position.y - yOffset, bottomTab[i].transform.position.z - zOffset), Quaternion.identity, bottomTab[i].transform);
                newCard.name = card;

                //temporarily testing display of cards all face up
                newCard.GetComponent<Selectable>().faceUp = true;

                //adjusting offset so that the fan function continues for each card as the loop continues
                yOffset = yOffset + 0.3f;
                zOffset = zOffset + 0.03f;
            }
        }
    }

    //nested loops walk through the shuffled deck and sort them into each of the 7 tableau spots ('bottom position' variables)
    void SolitaireSort()
    {
        //loops through 0 to 6 and saves value as 'i'
        for (int i = 0; i < 7; i++)
        {
            //for each instance of the i loop, a sub-loop counts from the current value of i to 7
            //the loop and subloops are to ensure each of the tableau (or 'bottom position') have the correct number of cards
            //it is taking the last card from the deck and adding it - this works fine because the deck is already shuffled
            //the card is also removed from the fulldeck array so that it is not dealt a second time by mistake
            for (int j = i; j < 7; j++)
            {
                bottoms[j].Add(fulldeck.Last<string>());
                createDeck().RemoveAt(fulldeck.Count - 1);
            }
        }
    }
}
