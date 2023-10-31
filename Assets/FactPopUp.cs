using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactPopUp : MonoBehaviour
{
    public GameObject popupPanel;

    private void Start()
    {
        // Ensure the popup panel is initially hidden
        popupPanel.SetActive(false);

        // Get a reference to the button component and add a click event listener
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ShowPopUp);
    }

    private void ShowPopUp()
    {
        // Toggle the visibility of the popup panel
        popupPanel.SetActive(!popupPanel.activeSelf);
    }
}

