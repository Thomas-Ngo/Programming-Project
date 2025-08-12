using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public enum SIDE { Left, Mid, Right }

public class Movement : MonoBehaviour
{
    public SIDE m_Side = SIDE.Mid;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public float XValue;
    [SerializeField] private UnityEngine.CharacterController m_char;


    // Start is called before the first frame update
    void Start()
    {
        m_char = GetComponent<UnityEngine.CharacterController>();
        // transform.position = new Vector3(35.51f, 1.42f, 0.22f);
    }

    // Update is called once per frame
    void Update()
    {
        SwipeLeft = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        SwipeRight = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);

        if (SwipeLeft)
        {
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

        m_char.Move((NewXPos - transform.position.z) * Vector3.forward);

    }
}
