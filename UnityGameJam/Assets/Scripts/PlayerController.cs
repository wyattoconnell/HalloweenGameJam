// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class PlayerController : MonoBehaviour
// {

//     public float speed;
//     Rigidbody rb;

//     float xInput;
//     float yInput;

//     private void Awake() {
//         rb = GetComponent<Rigidbody>();
//     }

//     private void FixedUpdate() {

//         xInput = Input.GetAxis("Horizontal");
//         yInput = Input.GetAxis("Vertical");

//         rb.AddForce(xInput*speed, 0, yInput*speed);

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (transform.position.y < -5f) {
//             SceneManager.LoadScene("Game");
//         }
//     }

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }
// }
