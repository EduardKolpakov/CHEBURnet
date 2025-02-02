using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CheburnetMove : MonoBehaviour
{
    private Transform obj;
    public Transform PauseImg;
    private Renderer ren;
    private Material mat;
    private float transp = 0f;
    private bool _isPause = false;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveStep;
    void Start()
    {
        obj = GetComponent<Transform>();
        ren = PauseImg.GetComponent<Renderer>();
        ToggleVisibility();
    }

    void Update()
    {

        float moveStepSpeed = _moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            if (obj.position.x > -6.44)
            {
                obj.position = Vector3.MoveTowards(obj.position, new Vector2(obj.position.x - _moveSpeed, obj.position.y), moveStepSpeed);
            }
        if (Input.GetKey(KeyCode.D))
            if (obj.position.x < 6.44)
            {
                obj.position = Vector3.MoveTowards(obj.position, new Vector2(obj.position.x + _moveSpeed, obj.position.y), moveStepSpeed);
            }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPause = !_isPause;
            ToggleVisibility();
            Time.timeScale = _isPause ? 0 : 1;
        }
    }
    void ToggleVisibility()
    {
        ren.enabled = !ren.enabled;
    }

}
