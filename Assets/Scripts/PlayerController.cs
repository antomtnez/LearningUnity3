using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody _playerRb;
    private GameObject focalPoint;

    private void Start(){
        _playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    private void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        _playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }
}
