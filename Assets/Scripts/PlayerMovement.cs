  using UnityEngine;
  using UnityEngine.UI;
  using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

  public float speed = 10f;
  public float jumpHeight = 2f;
  public Rigidbody rb;
  public bool isGrounded = true;
  public ParticleSystem fireworks;
  public Text levelWin;

    void Update()
    {

      gameOver();

      float x = Input.GetAxis("Horizontal");

      Vector3 move = new Vector3(x, 0, 0);
      transform.position += move * speed * Time.deltaTime;

      if(Input.GetButtonDown("Jump") && isGrounded)
      {
        rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        isGrounded = false;
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag == "Platform"){
        isGrounded = true;
      }

      if(collision.gameObject.tag == "Finish")
      {
        fireworks.Play();
        levelWin.text = "You completed level 1!";
      }
    }

    public void gameOver()
    {
      if (rb.position.y <= -3)
      {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
    }
}
