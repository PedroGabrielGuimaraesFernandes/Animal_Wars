using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovController : MonoBehaviour
{
    private Animator objAnim;
    private int movementIndex;
    [Header("Distância do movimento")]
    public float moveDistance = 1f;
    [Header("Velocidade doemovimento")]
    public float moveSpeed = 5f;
    [Header("Ponto de referencia para o movimento")]
    public Transform movePoint;
    [Header("Mascara que define o layer dos coliders q impedem movimento")]
    public LayerMask obstructionMask;
    private bool obstacleX;
    private bool obstacleY;

    // Start is called before the first frame update
    void Start()
    {
        objAnim = GetComponentInChildren<Animator>();
        movementIndex = Animator.StringToHash("Movement");
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0), .2f, obstructionMask))
                {                   
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    obstacleX = false;
                }
                else
                {
                    obstacleX = true;
                }
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0), .2f, obstructionMask))
                {
                    movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    obstacleY = false;
                }
                else
                {
                    obstacleY = true;
                }

            }
            objAnim.SetBool(movementIndex, false);
        }
        else
        {
            objAnim.SetBool(movementIndex, true);
        }
    }

    private void OnDrawGizmos()
    {
        if (obstacleX) {
            Gizmos.color = Color.red;
            Vector3 tempx = movePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
            Gizmos.DrawSphere(tempx, .2f);
        }

        if (obstacleY) {
            Gizmos.color = Color.red;
            Vector3 tempy = movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
            Gizmos.DrawSphere(tempy, .2f);
        }
    }
}
