using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 3;
    [SerializeField] float minX = 4.6f;
    [SerializeField] float maxX = -4.6f;
    private void Start()
    {

    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        var platformPos = transform.position;
        platformPos += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
        platformPos.x = Mathf.Clamp(speed, minX, maxX);
        transform.position = platformPos;
    }
}
