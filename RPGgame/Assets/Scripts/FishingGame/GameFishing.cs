using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFishing : MonoBehaviour
{
    
    public Rigidbody2D floatRigidbody; //���� ��
    public static bool isInPond = false; //������ �ִ��� �Ǵ�
    Vector2 localScale;
    float width = 9f;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        floatRigidbody = GetComponent<Rigidbody2D>();
        floatRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; //y�� ������ ����
    }

    private void FixedUpdate() //������ �����Ӹ��� update
    {
        if (transform.position.x > width)
            direction = false;
        else if (transform.position.x < -width)
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
        if (other.tag.Equals("GameController"))
        {
            isInPond = true;
        }
        else
            isInPond = false;
    }
}
