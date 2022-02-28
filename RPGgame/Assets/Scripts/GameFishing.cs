using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFishing : MonoBehaviour
{
    private Rigidbody2D floatRigidbody; //���� ��
    Vector2 localScale;
    float width = 5f;
    //float gaugebar = transform.localScale.y;
    public float lowSpeed = 3f; //���� �ӵ� ����
    public float midSpeed = 5f;
    public float highSpeed = 8f;
    public float speed;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        floatRigidbody = GetComponent<Rigidbody2D>();
        speed = lowSpeed;
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
    //private void OnTriggerStay2D(Collider2D gaugebar)
    //{
    //    floatRigidbody
    //}
    
    void GoRight()
    {
        localScale.x = 1f;
        floatRigidbody.velocity = new Vector2(speed, 0);
    }
    void GoLeft()
    {
        localScale.x = -1f;
        floatRigidbody.velocity = new Vector2(-speed, 0);
    }
}
