using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static bool canMove;

    private Actor actor;
    private Vector2 horizontalDir = Vector2.right;

    private Button jumpButton;

    private void Awake()
    {
        try
        {
            actor = GetComponent<Actor>();
        }
        catch(NullReferenceException e)
        {
            Debug.LogError(e.ToString());
        }

        jumpButton = GameObject.FindGameObjectWithTag(Constants.Tag.JUMP_BUTTON).GetComponent<Button>();
        jumpButton.onClick.AddListener(() => Jump());
    }

    private void Update()
    {
        Move();

        InputControl();

    }

    private void InputControl()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            actor.TryTurnHorizontal();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            actor.TryTurnVertical();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }

#if UNITY_ANDROID
        try
        {
            if (Input.touchCount == 1)
            {
                if(EventSystem.current.IsPointerOverGameObject(0) == false)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        actor.TryTurnHorizontal();
                    }
                }
                
            }
        }
        catch(ArgumentException e)
        {
            
        }
        
#endif
    }

    private void Move()
    {
        canMove = actor.canMove;
        actor.TryMove(horizontalDir);
    }

    private void Jump()
    {
        actor.TryJump();
    }

    private void ChangeHDirection()
    {
        horizontalDir *= Vector2.left;
    }
}
