using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateCardValue : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private gameLogic gamelogic;
    private playerInput userInput;

    void Start()
    {
        List<string> deck = gameLogic.createDeck();
        gamelogic = FindObjectOfType<gameLogic>();
        userInput = FindObjectOfType<playerInput>();

        int i = 0;
        foreach (string card in deck)
        {
            Console.WriteLine(cardFace);
            Console.WriteLine(gamelogic.theCardImages[i]);

            if (this.name == card)
            {
                cardFace = gamelogic.theCardImages[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
      if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
      else
      {
            spriteRenderer.sprite = cardBack;
      }

      if (userInput.slot1)
      {
          if (name == userInput.slot1.name)
          {
                //spriteRenderer.color = Color.yellow;
                //spriteRenderer.color = new Color(0.5f, 0.2f, 0.8f, 1f); //purple
                //spriteRenderer.color = new Color(1.0f, 0.5412f, 0.5412f, 1.0f); //dark pink
                //spriteRenderer.color = new Color(1.0f, 0.667f, 0.4667f, 1f); //orange-pink
                spriteRenderer.color = new Color(1.0f, 0.7176f, 0.7176f, 1f); //light-pink //the winner!!
            }
            else
          {
              spriteRenderer.color = Color.white;
          }
        }
    }
}

