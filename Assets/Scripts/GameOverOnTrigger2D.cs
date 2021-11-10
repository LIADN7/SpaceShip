using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTagEnemy;
    [SerializeField] string triggeringTagHeart;
    [SerializeField] string GameOver;

    GameObject heart2;
    GameObject heart3;
    int hearts;
    void Start()
    {
        hearts = 3;
        heart2 = GameObject.FindWithTag("heart2");
        heart3 = GameObject.FindWithTag("heart3");
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == triggeringTagHeart && enabled)
        {
            

            if (hearts == 2)
            {
                hearts++;
                heart3.SetActive(true);
            }
            else if (hearts == 1)
            {
                hearts++;
                heart2.SetActive(true);
            }
            Destroy(other.gameObject);
        }
        
        if (other.tag == triggeringTagEnemy && enabled) {
            if (hearts == 3)
            {
                hearts--;
                heart3.SetActive(false);

                Destroy(other.gameObject);
            }
            else if (hearts == 2)
            {
                hearts--;
                heart2.SetActive(false);
                Destroy(other.gameObject);
            }
            else if(hearts == 1)
            {
                SceneManager.LoadScene(GameOver);
/*                #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                #endif*/

            }

        }
    }

}
