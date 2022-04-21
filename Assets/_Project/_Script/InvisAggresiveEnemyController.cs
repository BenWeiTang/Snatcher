using System.Collections;
using Snatcher;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class InvisAggresiveEnemyController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private Transform _playerPosition;
    [SerializeField] private BoolReference _isSneaking;
    [SerializeField] private FloatReference _speed;
    
    private IEnumerator ChasePlayer()
    {
        _agent.speed = _speed.Value;
        while (!_isSneaking.Value)
        {
            _agent.ResetPath();
            _agent.SetDestination(_playerPosition.position);
            Debug.Log("Chasing player");
            yield return null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _playerPosition = other.transform;
            StopCoroutine(ChasePlayer());
            StartCoroutine(ChasePlayer());
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StopCoroutine(ChasePlayer());
            _agent.ResetPath();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
