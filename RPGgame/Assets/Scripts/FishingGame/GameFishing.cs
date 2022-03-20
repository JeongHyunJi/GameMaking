using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFishing : MonoBehaviour
{
    public static GameObject[] floats;
    public Rigidbody2D floatRigidbody; //���� ��
    public static bool isInPond = false; //������ �ִ��� �Ǵ�
    Vector2 localScale;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Pond.currentLevel == 1)
        {   floats = GameObject.FindGameObjectsWithTag("Player");
            floats[1].SetActive(false);
            floats[2].SetActive(false);
        }
        floatRigidbody = GetComponent<Rigidbody2D>();
        floatRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; //y�� ������ ����
        Time.timeScale = 0;
        //Move();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move() //fixedupdate ������ �����Ӹ��� update
    {
        if (transform.position.x > 4.5)
            direction = false;
        else if (transform.position.x < -5.5)
            direction = true;

        if (direction)
            GoRight();
        else
            GoLeft();
    }

    void GoRight()
    {
        localScale.x = 1f;
        floatRigidbody.velocity = new Vector2(GameLevel.speed, 0);
    }
    void GoLeft()
    {
        localScale.x = -1f;
        floatRigidbody.velocity = new Vector2(-GameLevel.speed, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Pond"))
        {
            isInPond = true;
        }
        else
            isInPond = false;
    }
}
