using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float endX;
    public GameObject shooter;
    private float nextX;

    // Update is called once per frame
    void Start()
    {
        transform.position = shooter.transform.position;
    }
    void Update()
    {
        nextX = Mathf.MoveTowards(transform.position.x, endX, speed * Time.deltaTime);
        Vector2 movePosition = new Vector2(nextX, transform.position.y);
        transform.position = movePosition;
    }
}