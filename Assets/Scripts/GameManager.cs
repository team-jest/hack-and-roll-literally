﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player1Prefab;

    [SerializeField]
    private GameObject player2Prefab;

    public GameObject startPoint1;
    public GameObject startPoint2;

    private GameObject player1;
    private GameObject player2;

    [SerializeField]
    private GameObject spawnPoint1;

    [SerializeField]
    private GameObject spawnPoint2;

    public float countdownDuration;



    // Start is called before the first frame update
    void Start()
    {
        InitialisePlayers(); //players movement are disabled

        // Start countdown
        //StartCountdown(); // not done

        // When countdown end enable player movement
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for game end conditions
    }

    void InitialisePlayers()
    {
        player1 = Instantiate(player1Prefab, startPoint1.transform.position, Quaternion.identity);
        player2 = Instantiate(player2Prefab, startPoint2.transform.position, Quaternion.identity);
    }

    void StartCountdown()
    {
        //start animation to count down
        //wait for animation to end
    }

    void StartGame()
    {
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
    }

    public void EndGame(int id) 
    {
        if (id == 1)
        {
            //start winner1 animation
            Debug.Log("Player1 won!");
        } else if (id == 2)
        {
            //start winner2 animation
            Debug.Log("Player2 won!");
        } else
        {
            throw new System.Exception("Error, neither player1 or 2 won.");
        }

        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(3);

        // change scene back to before game start
        SceneManager.LoadScene("Start Menu");
    }

}
