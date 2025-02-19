using UnityEngine;

public class Paddle: MonoBehaviour
{
    public GameObject ball;
    public Ball ballcontrol;
    BoxCollider2D collider;
    SpriteRenderer sr;
    bool isInsideRed;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        //Ball ballcontrol = ball.GetComponent<Ball>();
    }

    void Update()
    {
        // Mouse is in "screen-space" by default (coordinates of your monitor)
        Vector3 BallPosition = ball.transform.localPosition;

        // Convert it to "world-space" to match the coordinates of your game objects!
        //BallPosition = Camera.main.ScreenToWorldPoint(BallPosition);

        // x & y are the centre of our rectangle (game object)
        float x = transform.position.x;
        float y = transform.position.y;
        float hw = collider.size.x * transform.localScale.x * 0.5f;
        float hh = collider.size.y * transform.localScale.y * 0.5f;

        // Use min & max values to do your point-rectangle test against the mouse!
        float xMin = x - hw;
        float xMax = x + hw;
        float yMin = y - hh;
        float yMax = y + hh;

        // Check our math by rendering lines!
        Debug.DrawLine(new Vector3(xMin, yMin), new Vector3(xMin, yMax), Color.red);
        Debug.DrawLine(new Vector3(xMax, yMin), new Vector3(xMax, yMax), Color.yellow);
        Debug.DrawLine(new Vector3(xMin, yMin), new Vector3(xMax, yMin), Color.blue);
        Debug.DrawLine(new Vector3(xMin, yMax), new Vector3(xMax, yMax), Color.green);

        // Homework 5:
        // Compare mouse.x and mouse.y to rectangle min & max to determine whether there's collision.
        // Colour red if collision, otherwise colour green!
        if(BallPosition.x > xMax)
        {
            isInsideRed = false;
        }
        else if(BallPosition.x < xMin) 
        {
            isInsideRed = false;
        }
        else if(BallPosition.y > yMax)
        {
            isInsideRed = false;
        }
        else if(BallPosition.y < yMin)
        {
            isInsideRed = false;
        }
        else
        {
            isInsideRed = true;
        }

        if (isInsideRed)
        {
            //sr.color = Color.red;
            ballcontrol.ChangeDirection();
        }
        else
        {
            //sr.color = Color.white;
        }
    }
}
