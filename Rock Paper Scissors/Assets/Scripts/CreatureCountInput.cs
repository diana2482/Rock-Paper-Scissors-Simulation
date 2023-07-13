using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreatureCountInput : MonoBehaviour
{
    [SerializeField] private InputField creatureCountInput;
    [SerializeField] private Text warningText; // Display a warning message

    public void OnButtonClicked(String scene)
    {
        int creatureCount;
        if (int.TryParse(creatureCountInput.text, out creatureCount))
        {
            if (creatureCount <= 30 && creatureCount > 0)
            {
                PlayerPrefs.SetInt("CreatureCount", creatureCount);
                SceneManager.LoadScene(scene); // Load the next scene
            }
            else
            {
                warningText.text = "Must be <= 30 or bigger than 0";
            }
        }
        else
        {
            warningText.text = "Please enter a valid number";
        }
    }
}