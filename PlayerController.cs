using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int lives;
    int level;
    public Text LifeCount;
    GameObject player; 

    /********************
    * START 
    ********************/
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lives = GlobalControl.lives;
        LifeCount.text = "Lives: " + lives.ToString();
        level = SceneManager.GetActiveScene().buildIndex;
    }

    /********************
     * COLLISION EVENTS
     ********************/
    private void OnCollisionEnter(Collision collision)
    {
        // Remove life and restart level when player falls off path
        if (collision.gameObject.tag == "Death")
        {
            lives -= 1;
            if (lives > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                SetLifeCounterText();
            }
            else
            {
                Destroy(player);
                SetLifeCounterText();
                SceneManager.LoadScene(0);
            }
        }

        // Add point and move to next level when player collects flag
        if (collision.gameObject.tag == "Finish")
        {
            level++;
            SetLifeCounterText();
            SceneManager.LoadScene(level);
        }
    }

    /********************
    * SAVE GAME DATA
    ********************/
    void SaveGameData()
    {
        GlobalControl.lives = lives;
    }

    /********************
    * SET LIFECOUNT TEXT
    ********************/
    void SetLifeCounterText()
    {
        if (lives > 0)
        {
            LifeCount.text = "Lives: " + lives.ToString();
        }
        else if (lives == 0)
        {
            LifeCount.text = "You ran out of lives. You'll have to start over.";
        }
    }

}
