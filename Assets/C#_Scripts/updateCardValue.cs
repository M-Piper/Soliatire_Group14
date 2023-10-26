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

    void Start()
    {
        List<string> deck = gameLogic.createDeck();
        gamelogic = FindObjectOfType<gameLogic>();

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
    }
}

