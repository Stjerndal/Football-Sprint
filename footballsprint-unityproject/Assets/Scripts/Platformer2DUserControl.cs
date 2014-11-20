using UnityEngine;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class Platformer2DUserControl : MonoBehaviour 
{
	private PlatformerCharacter2D character;
    private bool jump;
	public bool dead = false;


	void Awake()
	{
		character = GetComponent<PlatformerCharacter2D>();
	}

    void Update ()
    {/*
        // Read the jump input in Update so button presses aren't missed.
#if CROSS_PLATFORM_INPUT
        if (CrossPlatformInput.GetButtonDown("Jump")) jump = true;
#else
		if (Input.GetButtonDown("Jump")) jump = true;
#endif
*/
		if(!dead) {
			if (CrossPlatformInput.GetButtonDown("Jump")) 
			{
				jump = true;
			} else if (Input.GetButtonDown("Jump")) {
				jump = true;
			}
			else if (Input.touchCount > 0) {
				int i = 0;
				Debug.Log("len = " + Input.touchCount);
				while(i < Input.touchCount) {
					if (Input.GetTouch(i).phase == TouchPhase.Began) {
						jump = true;
						break;
					}
					i++;
				}
			}
		}
    }

	void FixedUpdate()
	{/*
		#if CROSS_PLATFORM_INPUT
		//float h = CrossPlatformInput.GetAxis("Horizontal");
		#else
		float h = Input.GetAxis("Horizontal");
		#endif
*/
		// Pass all parameters to the character control script.
		if(!dead) {
			character.Move( 1, jump );

	        // Reset the jump input once it has been used.
		    jump = false;
		}
	}
}
