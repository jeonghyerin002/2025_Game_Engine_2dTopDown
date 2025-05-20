using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movespeed = 2f;
    [SerializeField] Sprite spriteUp;
    [SerializeField] Sprite spriteDown;
    [SerializeField] Sprite spriteLeft;
    [SerializeField] Sprite spriteRight;

    Rigidbody2D rb;
    SpriteRenderer sR;

    Vector2 input;
    Vector2 veloocity;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        veloocity = input.normalized * movespeed;

        if(input.sqrMagnitude > .01f)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                if (input.x > 0)
                    sR.sprite = spriteRight;
                else if (input.x < 0)
                    sR.sprite = spriteLeft;
            }
            else
            {
                if (input.y > 0)
                    sR.sprite = spriteUp;
                else
                    sR.sprite = spriteDown;
            }
        }


        

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + veloocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            score += collision.GetComponent<ItemObject>().GetPoint();
            Destroy(collision.gameObject);

            scoreText.text = score.ToString();
            Debug.Log("Á¡¼öÈ¹µæ");
        }
    }
}
