using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private int count;

    public Text countText;
    public Text winText;
    public float speed = 10;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        countText.text = "Count: " + count.ToString();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = speed * Input.GetAxis("Horizontal");
        float moveVertical = speed * Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            countText.text = "Count: " + count.ToString();
            if (count >= 8) winText.text = "You win!";
        }
    }
}
