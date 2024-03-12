using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody _enemyRb;
    private GameObject _player;

    void Start(){
        _enemyRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update(){
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _enemyRb.AddForce(lookDirection * speed);

        Dead();
    }

    void Dead(){
        if(transform.position.y <= -10f)
            Destroy(gameObject);
    }
}
