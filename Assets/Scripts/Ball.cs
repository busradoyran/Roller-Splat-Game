using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private AudioSource source;
    private GameManager gm;
    public Rigidbody rb;

    public Image levelBar;

    private Vector2 firstPos;
    private Vector2 secondPos;
    private Vector2 currentPos;

    public float speed;
    public float currentGroundNum;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        source =GetComponent<AudioSource>();

    }

    void Update()
    {
        Swipe();
        levelBar.fillAmount = currentGroundNum / gm.groundNum;
        if(levelBar.fillAmount == 1)
        {
            gm.LevelUpdate();
        }
    }

    private void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            currentPos = new Vector2(secondPos.x - firstPos.x, secondPos.y - firstPos.y);
        }

        currentPos.Normalize();

        if (currentPos.y < 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            // Back
            rb.velocity = Vector3.back * speed;
        }
        else if(currentPos.y > 0 && currentPos.x > -0.5f && currentPos.x < 0.5f)
        {
            // Forward
            rb.velocity = Vector3.forward * speed;
        }
        else if(currentPos.x < 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            // Left
            rb.velocity = Vector3.left * speed;
        }
        else if(currentPos.x > 0 && currentPos.y > -0.5f && currentPos.y < 0.5f)
        {
            // Right
            rb.velocity = Vector3.right * speed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<MeshRenderer>().material.color != Color.red)
        {
            if (other.gameObject.tag == "Ground")
            {
                source.Play();
                other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                Constraints();
                currentGroundNum++;
            }
        }
    }

    private void Constraints()
    {
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
    }
}
