using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Monster : MonoBehaviour
{
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int IsJump = Animator.StringToHash("isJump");
    public Transform Player;
    public float jumpDistance = 5f;
    public float followDistance = 10f;
    public float killDistance = 1f;
    public float maxSpeed = 5f;
    public float minSpeed = 0.5f;

    private Animator _animator;
    private NavMeshAgent _agent;
    private Transform _pointToMove;
    private float _moveSpeed;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (_agent.hasPath && !_agent.isStopped)
        {
            _animator.SetBool(IsRun, true);
        }
        else
        {
            _animator.SetBool(IsRun, false);
        }

        bool isRun = false;
        bool isJump = false;
        _agent.isStopped = false;
        float plyerDist =  Vector3.Distance(transform.position, Player.position);
        if (Player && plyerDist < killDistance)
        {
            _agent.isStopped = true;
            SceneManager.LoadScene("YouDie");
        }
        else if (Player && plyerDist <= jumpDistance)
        {
            _agent.speed = maxSpeed;
            _agent.SetDestination(Player.position);
            isJump = true;
        }
        else if (Player && plyerDist <= followDistance)
        {
            _agent.speed = minSpeed;
            _agent.SetDestination(Player.position);
            isRun = true;
        }
        else if (_pointToMove)
        {
            _agent.speed = _moveSpeed;
            _agent.SetDestination(_pointToMove.position);
            isRun = true;
        }
        else
        {
            _agent.isStopped = true;
        }
        
        _animator.SetBool(IsRun, isRun);
        _animator.SetBool(IsJump, isJump);
    }

    public void MoveToPoint(Transform point, float speed = 1f)
    {
        _moveSpeed = Mathf.Clamp(speed, 1f, maxSpeed);
        _pointToMove = point;
    }
}
