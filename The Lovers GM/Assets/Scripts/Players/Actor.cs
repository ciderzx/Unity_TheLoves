using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public enum ActorState
    {
        H,
        D
    }

    public ActorState state;

    public bool canMove;

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private bool onGround; // 땅에 닿았는지
    private bool jumpDelaying; // 점프 딜레이 중인지
    private bool hasFrontObstacle; // 앞에 장애물이 있는지

    private int horizontalDir = 1; // value : 1, -1
    private int verticalDir = 1; // value : 1, -1

    [Header("Setting")]
    public float moveSpeed;
    public float jumpPower;
    public float jumpDelay;

    [Space]

    [Range(0f, 10f)] // [ 플레이어 -- (Ray) --> 땅 ] Ray 길이
    public float onGroundDuration;
    [Range(0f, 10f)] // [ 플레이어 -- (Ray) --> 벽 ] Ray 길이
    public float hasFrontDuration;

    [Space]
   
    public int maxJumpCount = 1;
    private int currentJumpCount;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        canMove = CanMove();

        CheckOnGround();
        CheckFrontObstacle();
    }

    /// <summary>
    /// 땅에 닿았는지 레이 쏴서 확인
    /// </summary>
    private void CheckOnGround()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down * verticalDir, onGroundDuration, ~layerMask);

        if (hit)
        {
            currentJumpCount = maxJumpCount;
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    /// <summary>
    /// 앞에 장애물이 있는지 레이 쏴서 확인.
    /// </summary>
    private void CheckFrontObstacle()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ignore Raycast");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * horizontalDir, hasFrontDuration, ~layerMask);

        if (hit)
        {
            hasFrontObstacle = true;
        }
        else
        {
            hasFrontObstacle = false;
        }
    }

    public void TryTurnHorizontal()
    {
        transform.Rotate(new Vector3(0, 180, 0));
        horizontalDir *= -1;
    }

    public void TryTurnVertical()
    {
        transform.Rotate(new Vector3(0, 180, 180));
        rigidbody.gravityScale *= -1;
        verticalDir *= -1;
    }

    public void TryMove(Vector3 moveVector)
    {
        if (!CanMove())
        {
            animator.SetBool("Movement", false);
            return;
        }
        animator.SetBool("Movement", true);

        moveVector.Normalize();
        transform.position += moveVector * horizontalDir * moveSpeed * Time.deltaTime;
    }

    public void TryJump()
    {
        if (!CanJump()) return;

        currentJumpCount--;

        rigidbody.AddForce(Vector2.up * verticalDir * jumpPower, ForceMode2D.Impulse);
        StartCoroutine(JumpDelayCoroutine());
    }

    private IEnumerator JumpDelayCoroutine()
    {
        jumpDelaying = true;
        yield return new WaitForSeconds(jumpDelay);
        jumpDelaying = false;
    }

    #region Validation Check

    private bool CanJump()
    {
        if (TimeManager.Instance.GetPause()) return false;
        if (!onGround && currentJumpCount <= 1) return false;
        if (jumpDelaying) return false;

        return true;
    }

    private bool CanMove()
    {
        if (TimeManager.Instance.GetPause()) return false;
        if (hasFrontObstacle && state == ActorState.H) return false;

        return true;
    }

    #endregion
}
