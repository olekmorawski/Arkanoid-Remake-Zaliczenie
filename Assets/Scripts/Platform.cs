using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 3;
    [SerializeField] private Vector2 _bounds;
    private void Start()
    {

    }

    private void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        if (direction > 0f)
        {
            direction = 1f;
        }
        else if (direction < 0f)
        {
            direction = -1f;
        }
      //  else direction = 0f;
        float movement = direction * speed * Time.deltaTime;
        Vector3 position = transform.position;
        if (transform.position.x + movement < _bounds.x)
        {
            position.x = _bounds.x;
        }
        else if (transform.position.x + movement > _bounds.y)
        {
            position.x = _bounds.y;
        }
        else
        {
            position.x += movement;
        }

        transform.position = position;
    }

}
