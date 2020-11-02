using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
    public float forwardVelocity;
    public float sidewaysVelocity;
    bool KeyLeft;
    bool KeyRight;

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) KeyLeft = true;
        else KeyLeft = false;

        if (Input.GetKey(KeyCode.D)) KeyRight = true;
        else KeyRight = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.AddForce(0, 0, forwardVelocity * Time.deltaTime);

        if (KeyLeft)
        {
            player.AddForce(-sidewaysVelocity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (KeyRight)
        {
            player.AddForce(sidewaysVelocity * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (player.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
