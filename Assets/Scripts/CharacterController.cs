using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    public int coinCount;
    private int totalCoin;   //total number of coin in scene
    

    public GameObject coinObject;
    public GameObject CoinCollected;


    // Start is called before the first frame update
    void Start()
    {
        CoinCollected.GetComponent<Text>().text = "Coins Collected: " + coinCount;

        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();

        //win
        if (coinCount == totalCoin)
        {
            print("You Win!");
            SceneManager.LoadScene("WinScene");
        }

        //lose
        if (transform.position.y < -5)
        {
            print("You Lose");
            SceneManager.LoadScene("LoseScene");
        }




    }

    private void PlayerControls()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin" )
        {
            coinCount++;
            CoinCollected.GetComponent<Text>().text = "Coins Collected :" + coinCount;

            Destroy(other.gameObject);     //destroy the triggered coin object
        }
    }
}
