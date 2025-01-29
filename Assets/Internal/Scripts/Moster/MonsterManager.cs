using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public Transform[] points;
    public bool inSycle;
    public float speed;
    public bool resetPosition;
    
    private Monster _monster;
    private readonly Queue<Transform> _pointsQueue = new Queue<Transform>();
    private Coroutine _currentCoroutine;
    private bool _isMovingBetweenPoints = false;

    void Start()
    {
        _monster = Monster.getInstance();
    }

    public void Activate()
    {
        _monster.gameObject.SetActive(true);
        StopCoroutine(_currentCoroutine);
        _isMovingBetweenPoints = false;
    }
    
    public void Disactivate()
    {
        _monster.gameObject.SetActive(false);
        StopCoroutine(_currentCoroutine);
        _isMovingBetweenPoints = false;
    }

    public void MoveBetweenPoints()
    {
        if (_isMovingBetweenPoints)
        {
            StopCoroutine(_currentCoroutine);
        }

        _pointsQueue.Clear();
        foreach (var point in points)
        {
            _pointsQueue.Enqueue(point);
        }

        if (resetPosition && points.Length > 0)
        {
            _monster.gameObject.transform.position = points[0].position;
        }

        _currentCoroutine = StartCoroutine(MoveBetweenPointsCoroutine(speed));
        _isMovingBetweenPoints = true;
    }
    
    private IEnumerator MoveBetweenPointsCoroutine(float speed)
    {
        while (true)
        {
            if (_pointsQueue.Count == 0)
            {
                _isMovingBetweenPoints = false;
                yield break;
            }
            Transform targetPoint = _pointsQueue.Dequeue();

            _monster.MoveToPoint(targetPoint, speed);

            while (Vector3.Distance(_monster.transform.position, targetPoint.position) > 0.1f)
            {
                yield return null;
            }

            if (inSycle)
            {
                _pointsQueue.Enqueue(targetPoint);
            }
        }
    }
}
