using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    private gameLogic gamelogic;
    public GameObject slot1;
    public bool firstCardFlag;
    // Start is called before the first frame update
    void Start()
    {
        gamelogic = FindObjectOfType<gameLogic>();
        slot1 = this.gameObject; //to prevent slot1 being null
     //   firstCardFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit)
            {
                if (hit.collider.CompareTag("Deck"))
                {
                    Deck();
                }
                else if (hit.collider.CompareTag("Card"))
                {
                    Card(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Foundation"))
                {
                    Foundation(hit.collider.gameObject);
                }
                else if (hit.collider.CompareTag("Tableau"))
                {
                    Tableau(hit.collider.gameObject);

                }
            }
        }
    }

    void Deck()
    {
        print("clicked on Deck");
        gamelogic.DealFromDeck();
        slot1 = this.gameObject;
    }
    void Card(GameObject selected)
    {
        print("clicked on Card");

        //checks if card facedown
        if (!selected.GetComponent<Selectable>().faceUp)
        {
            if (!Blocked(selected)) //checks if the facedown card is blocked or not
            {
                //flip card over
                selected.GetComponent<Selectable>().faceUp = true;
                slot1 = this.gameObject;
            }
        }

        else if (selected.GetComponent<Selectable>().inDeckPile) //if card clicked is in the deck pile with trips
        {
            //if it is not blocked
            if (!Blocked(selected))
            {
                slot1 = selected;
            }

        }

        ///////////////////////

        else
        { 
            if (slot1 == this.gameObject) //this prevents slot1 being null
            {
              slot1 = selected;
            }
      

            //if there is already a card selected and second card clicked is different

            else if (slot1 != selected)
            {

                if (Stackable(selected))
                {
                    Stack(selected);
                }
                else
                {
                    //select new card
                    slot1 = selected;
                }
            }
            //else if the card is the same and time between clicks was X - send it to foundation
        }

    }
    void Foundation(GameObject selected)
    {
        print("clicked on Foundation");
        if (slot1.CompareTag("Card"))
        {
            //check if the card is an ace
            if (slot1.GetComponent<Selectable>().value == 1)
            {
                Stack(selected);
            }
        }

    }

    void Tableau(GameObject selected)
    {
        print("clicked on Tableau");

        if (slot1.CompareTag("Card"))
        {
            if (slot1.GetComponent<Selectable>().value == 13)
            {
                Stack(selected);
            }
        }
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        //compare to see if eligible for stacking

        if (!s2.inDeckPile)
        { //checks if the card potentially being moved is already in deck - this prevents it from being moved to the top

            if (s2.top == true) //if top pile must be stacked Ace to King in same suit
            {
                if (s1.suit == s2.suit || s1.value == 1 && s2.suit == null)
                {
                    if (s1.value == s2.value + 1)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else // if bottom pile then stack alternate colours from king to ace
            {
                if (s1.value == s2.value - 1)
                {
                    bool card1Red = true;
                    bool card2Red = true;

                    if (s1.suit == "c" || s1.suit == "s")
                    {
                        card1Red = false;
                    }

                    if (s2.suit == "c" || s2.suit == "s")
                    {
                        card2Red = false;
                    }
                    
                    if (card1Red == card2Red)
                    {
                        print("not stackable");
                        return false;
                    }
                    else
                    {
                        print("stackable"); //not in tutorial
                        return true; //not in tutorial
                    }
                }
                print("not stackable"); //not in tutorial
                return false; //not in tutorial
            }
        }
        print("not stackable");
        return false;
    }

    void Stack (GameObject selected)
    {
        //if selected card is on top of a kind or empty bottom stack the cards in the same place
        //otherwise, stack the cards fanned out (on y axis)
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        float yoffset = 0.3f;

        if (s2.top || (!s2.top && s1.value == 13)) //if recent is at the top OR recent selection is NOT at the top BUT value of the location it is going is 13, then stay in place with no offset)
        {
            yoffset = 0;
        }

        slot1.transform.position = new Vector3(selected.transform.position.x, selected.transform.position.y - yoffset, selected.transform.position.z - 0.01f);
        slot1.transform.parent = selected.transform; //moves whole column together

        if (s1.inDeckPile) // subtracts cards that are now in top pile from the deck so they cannot be duplicated by mistake
        {
            gamelogic.tripsOnDisplay.Remove(slot1.name);
        }
        else if (s1.top && s2.top && s1.value == 1) //lets cards move between top spots
        {
           gamelogic.topTab[s1.row].GetComponent<Selectable>().value = 0;
            gamelogic.topTab[s1.row].GetComponent<Selectable>().suit = null;
        }
        else if (s1.top) //tracks current value of top decks
        {
            gamelogic.topTab[s1.row].GetComponent<Selectable>().value = s1.value - 1;
        }
        else //remove card string from bottom list it was previously in
        {
            gamelogic.bottoms[s1.row].Remove(slot1.name);
        }

        s1.inDeckPile = false;
        s1.row = s2.row;

        if (s2.top)
        {
            gamelogic.topTab[s1.row].GetComponent<Selectable>().value = s1.value;
            gamelogic.topTab[s1.row].GetComponent<Selectable>().suit = s1.suit;
            s1.top = true;
        }
        else
        {
            s1.top = false;
        }

        slot1 = this.gameObject; //resets slot1 to null

    }

    bool Blocked(GameObject selected)
    {
        Selectable s2 = selected.GetComponent<Selectable>();
        if (s2.inDeckPile == true)
        {
            if (s2.name == gamelogic.tripsOnDisplay.Last())
            { 
                return false;
            }
            else 
            { 
                print(s2.name + "is blocked by " + gamelogic.tripsOnDisplay.Last());
                return true; 
            }
        }
        else
        {
            if (s2.name == gamelogic.bottoms[s2.row].Last())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
