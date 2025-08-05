using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private SpriteRenderer _spriteRenderer;
    private int _currentPoint;
    private readonly float _pointReachedThreshold = 0.05f;

    private void Start()
    {
        _points = new Transform[_path.childCount];
        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];
        Vector3 direction = (target.position - transform.position).normalized;

        // Флип по направлению
        if (direction.x != 0)
        {
            _spriteRenderer.flipX = direction.x < 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < _pointReachedThreshold)
        {
            _currentPoint++;
            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}