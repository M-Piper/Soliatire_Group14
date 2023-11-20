using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    private gameLogic gamelogic;
    public GameObject slot1;
    // Start is called before the first frame update
    void Start()
    {

        gamelogic = FindObjectOfType<gameLogic>();
        slot1 = this.gameObject; //to prevent slot1 being null
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
                    Foundation();
                }
                else if (hit.collider.CompareTag("Tableau"))
                {
                    Tableau();

                }
            }
        }
    }

    void Deck()
    {
        print("clicked on Deck");
        gamelogic.DealFromDeck();
    }
    void Card(GameObject selected)
    {
        print("clicked on Card");
        slot1 = selected;
        //if card facedown and useable, flip

        //if card is in deck pile with trips and not blocked, select it

        if (slot1 = this.gameObject) //this prevents slot1 being null
        {
            slot1 = selected;
        }

        //if there is already a card selected and second card clicked is different

        else if (slot1 != selected)
        {
            //AND if the second card is opposite suit and higher, then stack
        slot1=selected;
        }
            //else new card selected
        //else if the card is the same and time between clicks was X - send it to foundation
    
    }
    void Foundation()
    {
        print("clicked on Foundation");
    }
    void Tableau()
    {
        print("clicked on Tableau");
    }

    bool Stackable(GameObject selected)
    {
        Selectable s1 = slot1.GetComponent<Selectable>();
        Selectable s2 = selected.GetComponent<Selectable>();
        //compare to see if eligible for stacking
        return false;
    }
}
