using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInput : MonoBehaviour
{
    private gameLogic gamelogic;

    // Start is called before the first frame update
    void Start()
    {

        gamelogic = FindObjectOfType<gameLogic>();

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
                    Card();
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
    void Card()
    {
        print("clicked on Card");
    }
    void Foundation()
    {
        print("clicked on Foundation");
    }
    void Tableau()
    {
        print("clicked on Tableau");
    }
}
