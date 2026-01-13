using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int moveSpeed = 1;
    [SerializeField] private List<Coin> coinList;
    [SerializeField] private List<Transform> coinTowerList;
    [SerializeField] private float minDistance = 0.8f;
    private Vector3 playerTransform;
    [SerializeField] private TextMeshProUGUI coinText;
    private int noOfCoin;
    void Start()
    {
        noOfCoin = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
       DestroyCoinOnSpace();
       Towers();
    }

    private void Towers()
    {
        playerTransform = transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < coinTowerList.Count; i++)
            {
                if(coinTowerList[i] != null && (playerTransform - coinTowerList[i].position).magnitude < minDistance)
                {
                if(i == 0)
                    {
                        AddCoin();
                        AddCoin();
                        AddCoin();
                    }
                else if(i == 1)
                    {
                        AddCoin();
                        AddCoin();
                        AddCoin();
                        AddCoin();
                        AddCoin();
                    }
                }
            }
        }
    }

    private void AddCoin()
    {
        noOfCoin += 1;



        // shows coin on update
        coinText.text = noOfCoin.ToString();
    }

    private void DestroyCoinOnSpace()
    {
            foreach (Coin coin in coinList)
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                 if(coin != null)
            {
                playerTransform = transform.position;
                if((playerTransform - coin.transform.position).magnitude < minDistance)
                {
                    Debug.Log("Magnitude: "+(playerTransform - coin.transform.position).magnitude);
                    coin.DestroyCoin();
                    AddCoin();
                    Debug.Log("Number of Coins: " + noOfCoin);
                }
            }
            }
        }
        
    }
private void JustCheckingParams( int numbers, params string[] names)
    {
        
    }
    private void MovePlayer()
    {
         if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0,1,0) * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0,-1,0) * moveSpeed;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1,0,0) * moveSpeed;
        }
         else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1,0,0) * moveSpeed;
        }
    }
}
