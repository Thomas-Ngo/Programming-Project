using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum SIDE { Left, Mid, Right }

public class Movement : MonoBehaviour
{
    private SIDE m_Side = SIDE.Mid;
    private Vector2 startTouch;
    float NewXPos = 0f;
    private bool SwipeLeft;
    private bool SwipeRight;
    public float XValue = 2;
    public float forwardSpeed = 5f;
    [SerializeField] private UnityEngine.CharacterController m_char;


    // Start is called before the first frame update
    void Start()
    {
        m_char = GetComponent<UnityEngine.CharacterController>();
    }

    // Update is called once per frame 
    void Update()
    {
        // Reset swipes
        SwipeLeft = false;
        SwipeRight = false;

        // Keyboard input
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            SwipeLeft = true;
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            SwipeRight = true;

        // Touch swipe
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                Vector2 endTouch = touch.position;
                Vector2 swipe = endTouch - startTouch;

                if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                {
                    if (swipe.x > 50f)
                        SwipeRight = true;
                    else if (swipe.x < -50f)
                        SwipeLeft = true;
                }
            }
        }

        // Lane switching
        if (SwipeLeft)
        {
            Debug.Log("left");
            if (m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Left;
            }
            else if (m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }

        else if (SwipeRight)
        {
            Debug.Log("right");
            if (m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Right;
            }
            else if (m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }
        }

        // Movement
        Vector3 move = Vector3.forward * forwardSpeed * Time.deltaTime;
        move += (NewXPos - transform.position.x) * Vector3.right;
        m_char.Move(move);
    }
}
