using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool jumpPressed;
    public int movespeed;

    private float horizantalInput;
    private Rigidbody rb;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
        horizantalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizantalInput*movespeed, rb.velocity.y, 0);
        if(!isGrounded)
        {
            return;
        }

        if(jumpPressed)
        {
            rb.AddForce(Vector3.up *10, ForceMode.VelocityChange);
            jumpPressed =false;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        if(collision.gameObject.layer == 8)
        {
            Destroy(this.gameObject);

            UIManager.Instance.ShowGameOverPanel(GameManager.Instance.GetCoinsCount());
            // Scene currentScene = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(currentScene.name);
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            GameManager.Instance.CollectCoin();
        }
    }
}
