using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactPopUp : MonoBehaviour
{
    public GameObject popupPanel;
    public Text factText; // A reference to the text component on the popup panel
    private string[] facts; // An array of placeholder text string sentences
    private int index; // An index to keep track of the current fact



    private void Start()
    {
        // Ensure the popup panel is initially hidden
        popupPanel.SetActive(false);

        // Get a reference to the button component and add a click event listener
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ShowPopUp);

        // Initialize the facts array with some dummy sentences
        facts = new string[]
        {
            "Solitaire is also known as Patience in some countries, including the United Kingdom.",
            "The game is often played with a standard deck of 52 playing cards.",
            "Solitaire is a single-player game, making it a great way to pass the time alone.",
            "There are many variations of Solitaire, with the most popular one being Klondike.",
            "Microsoft Windows included Solitaire in their operating systems to help people learn how to use a computer mouse.",
            "Solitaire can improve your concentration and problem-solving skills.",
            "The goal of Solitaire is to arrange all the cards in a specific order or suit.",
            "The game can be traced back to 18th-century France.",
            "Solitaire became popular in the United States during the 19th century.",
            "Some people believe that Napoleon Bonaparte played Solitaire during his exile on the island of Saint Helena.",
            "Playing cards have been around for over 1,000 years, with origins in ancient China.",
            "The first playing cards were likely made from materials like paper, wood, or bamboo.",
            "Playing cards were introduced to Europe in the late 14th century through trade with Asia.",
            "The four suits in a deck of cards (hearts, diamonds, clubs, and spades) are believed to represent the four seasons.",
            "The joker card was created in the United States and is not found in traditional European decks.",
            "Playing cards were originally hand-painted and quite expensive. They became more affordable with the invention of printing.",
            "In the 19th century, cards were used for fortune-telling and as a form of entertainment at social gatherings.",
            "The Ace of Spades is often considered the most powerful card in a deck, known as the 'death card.''",
            "Each king in a deck of cards represents a historical figure: King of Hearts is Charlemagne, King of Diamonds is Julius Caesar, King of Clubs is Alexander the Great, and King of Spades is King David from the Bible.",
            "The world's largest playing card was created in 2010 in the United States, measuring 25 feet by 37 feet.",
        };

        // Initialize the index to zero
        index = 0;

        // Find the Text component on the popup panel
        factText = popupPanel.GetComponentInChildren<Text>();
    }

    private void ShowPopUp()
    {
        // Toggle the visibility of the popup panel
        popupPanel.SetActive(!popupPanel.activeSelf);

        // Check if the factText and the facts are not null
        if (factText != null && facts != null)
        {
            // Update the text on the popup panel with the current fact
            factText.text = facts[index];

            // Increment the index and wrap it around if it exceeds the array length
            index = (index + 1) % facts.Length;
        }
        else
        {
            // Print an error message to the console
            Debug.LogError("factText or facts is null");
        }
    }
}
