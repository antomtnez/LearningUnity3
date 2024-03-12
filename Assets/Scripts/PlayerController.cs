using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody _playerRb;
    private GameObject focalPoint;

    public bool hasPowerUp;
    private float powerUpStrength = 15f;
    public GameObject powerUpIndicator;
    private Vector3 powerUpIndicatorOffset = new Vector3(0f, -0.5f, 0f);

    private void Start(){
        _playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    private void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + powerUpIndicatorOffset;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }    
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy") && hasPowerUp){
            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }    
    }

    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.SetActive(false);
    }
}
