using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody2D rb;
	public float strength = 6f;
	bool isJumping = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();	
		isJumping = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isJumping ) 
		{
            rb.velocity = Vector3.up * strength;
			isJumping = true;
			PlayJumpSound();
        }

		if (Input.touchCount > 0) 
		{
			Touch touch = Input.GetTouch(0);

			if ((touch.phase == TouchPhase.Began) && !isJumping )
			{
				rb.velocity = Vector3.up * (strength / 2.0f);
				isJumping = true;
				PlayJumpSound();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isJumping = false;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {       
		switch (other.gameObject.tag)
			{			
				case "Obstacle":
					FindObjectOfType<GameManager>().GameOver();
					break;	

				case "Scoring":
					FindObjectOfType<GameManager>().IncreaseScore();
            		other.gameObject.SetActive(false);
					break;

				case "Potion":
					FindObjectOfType<GameManager>().IncreaseScore();
            		other.gameObject.SetActive(false);
	    			SoundManager.PlaySound("potion");
					break;
			}
    }

	public void Reset()
	{
		rb = GetComponent<Rigidbody2D>();	
		Vector3 position = transform.position; // get the position
        position.y = -2.75f; position.x = -3.36f;
        transform.position = position;
        rb.velocity = Vector3.zero;
	}

	private void PlayJumpSound()
    {
        int i = (int)Random.Range(0,100) % 3;
        SoundManager.PlaySound("jump0"+i);
    }
}
