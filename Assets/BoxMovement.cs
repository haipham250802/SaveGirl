using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BoxMovement : MonoBehaviour
{
    BoxController _boxController;
    [SerializeField] BoxElement _boxElement;
    public float speed = 2f;                         // tốc độ di chuyển
    public bool IsCanMove;
    public bool IsDetectObstacle;
    private Vector3 _posStart;
    Transform obstacle;
    public LayerMask targetLayer; // Lớp layer để kiểm tra va chạm (bạn có thể tùy chọn)
    PosHandler posHandler;


    private void Start()
    {
        _boxController = _boxElement.BoxController;
        _posStart = transform.localPosition;
        posHandler = GameplayController.Ins.PosHandler;
    }
    private void OnMouseDown()
    {
        IsCanMove = true;
        obstacle = IsObjectInDirection(_boxController.TypeDirBox);

    }
    void Update()
    {
        if (!IsCanMove) return;
        if (GetTarget())
        {
            Debug.Log("a");
            IsCanMove = false;
            MoveToTarget();
        }
        else
        {
            Vector3 moveVector = GetDirectionVector(_boxController.TypeDirBox);
            transform.position += moveVector * speed * Time.deltaTime;
            if (obstacle)
            {
                if (Vector2.Distance(transform.position, obstacle.transform.position) < 0.5f)
                {
                    if (obstacle.GetComponent<BoxMovement>()._boxElement.BoxController)
                        obstacle.GetComponent<BoxMovement>()._boxElement.BoxController.Shake();
                    IsCanMove = false;
                    transform.localPosition = _posStart;
                }
            }
        }
    }

    Vector3 GetDirectionVector(TypeDirBox dir)
    {
        switch (dir)
        {
            case TypeDirBox.Top: return Vector3.up;
            case TypeDirBox.Bottom: return Vector3.down;
            case TypeDirBox.Right: return Vector3.right;
            case TypeDirBox.Left: return Vector3.left;
            default: return Vector3.zero;
        }
    }

    public Transform IsObjectInDirection(TypeDirBox direction)
    {
        Vector2 dirVector = GetDirectionVector(direction);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dirVector, Mathf.Infinity, targetLayer);

        // Gỡ dòng này nếu không cần debug
        Debug.DrawRay(transform.position, dirVector * Mathf.Infinity, Color.red);
        if (hit.collider != null)
        {
            IsDetectObstacle = true;
            return hit.collider.transform;
        }
        return null;
    }
    private Transform GetTarget()
    {
        return GameplayController.Ins.PosHandler.GetSlotEmpty();
    }
    public void MoveToTarget()
    {
        Vector3[] arr = new Vector3[6];
        if (GetTarget())
        {
            switch (_boxElement.BoxController.TypeDirBox)
            {
                case TypeDirBox.Top:
                    break;
                case TypeDirBox.Bottom:
                    arr = GetArrBottom();
                    break;
                case TypeDirBox.Right:
                    arr = new Vector3[5];
                    arr = GetArrRight();
                    break;
                case TypeDirBox.Left:
                    arr = new Vector3[5];
                    arr = GetArrLeft();
                    break;
                default:
                    break;
            }

            transform.DOPath(arr, 2, PathType.CatmullRom, PathMode.TopDown2D);
            GetTarget().GetComponent<PosBoxController>().BoxController = _boxElement.BoxController;
        }
    }

    private Vector3[] GetArrLeft()
    {
        Vector3[] arr = new Vector3[5];
        arr[0] = transform.position;
        if (transform.position.x < 0)
        {
            arr[1] = new Vector2(posHandler.PosLeftTop.position.x, transform.position.y);
            arr[2] = posHandler.PosLeftTop.position;
            arr[3] = new Vector2(GetTarget().position.x, posHandler.PosLeftTop.position.y);
            arr[4] = GetTarget().position;
        }
        return arr;
    }
    private Vector3[] GetArrRight()
    {
        Vector3[] arr = new Vector3[5];

        arr[0] = transform.position;
        if (transform.position.x > 0)
        {
            arr[1] = new Vector2(posHandler.PosRightTop.position.x, transform.position.y);
            arr[2] = posHandler.PosRightTop.position;
            arr[3] = new Vector2(GetTarget().position.x, posHandler.PosRightTop.position.y);
            arr[4] = GetTarget().position;
        }
        return arr;
    }


    private Vector3[] GetArrBottom()
    {
        Vector3[] arr = new Vector3[6];

        arr[0] = transform.position;
        if (transform.position.x < 0)
        {
            arr[1] = new Vector2(transform.position.x, posHandler.PosLeftBottom.position.y);
            arr[2] = posHandler.PosLeftBottom.position;
            arr[3] = posHandler.PosLeftTop.position;
            arr[4] = new Vector2(GetTarget().position.x, posHandler.PosLeftTop.position.y);
            arr[5] = GetTarget().position;
        }
        else
        {
            arr[1] = new Vector2(transform.position.x, posHandler.PosRightBottom.position.y);
            arr[2] = posHandler.PosRightBottom.position;
            arr[3] = posHandler.PosRightTop.position;
            arr[4] = new Vector2(GetTarget().position.x, posHandler.PosRightTop.position.y);
            arr[5] = GetTarget().position;
        }
        return arr;
    }
}
