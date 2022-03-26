using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToFishingGame()
    {
        SceneManager.LoadScene("GameFishing");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Hearts.heart != 0)
        {
            Debug.Log(other.gameObject);
            if (other.gameObject.CompareTag("treants"))
                SceneManager.LoadScene("GameShooting");
            else if (other.gameObject.CompareTag("moles"))
                SceneManager.LoadScene("GameDodugi");
        }
        else
            Debug.Log("��Ʈ�� 0���Դϴ�. ������ �� �� �����ϴ�.");
    }
}
