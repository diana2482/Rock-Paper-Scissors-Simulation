using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int rockCount;
    public int paperCount;
    public int scissorsCount;

    [SerializeField] private Text victoryText;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        StartCoroutine(ExecuteEveryThreeSeconds());
    }

    IEnumerator ExecuteEveryThreeSeconds()
    {
        while (true)
        {
            CountCreatures();
            CheckForVictory();
            yield return new WaitForSeconds(4);
        }
    }

    private void CountCreatures()
    {
        rockCount = FindObjectsOfType<Rock>().Length;
        scissorsCount = FindObjectsOfType<Scissors>().Length;
        paperCount = FindObjectsOfType<Paper>().Length;
    }

    private void CheckForVictory()
    {
        if (rockCount == 0 && scissorsCount == 0)
        {
            // Debug.Log("paper");
            victoryText.text = "Paper won!";
        }
        else if (paperCount == 0 && rockCount == 0)
        {
            // Debug.Log("scissors");
            victoryText.text = "Scissors won!";
        }
        else if (scissorsCount == 0 && paperCount == 0)
        {
            // Debug.Log("rock");
            victoryText.text = "Rock won!";
        }
    }
}