using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 6.0F;
    public float ladderSpeed = 1.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
    public bool isDead = false;
    public bool doGameOver = false;

    Vector3 moveDirection = Vector3.zero;

    bool isNearLadder;
    bool isOnLadder;

    Transform ladderTop;
    Transform ladderBottom;
    Vector3 deathPosition;

    Animator anim;
    Quaternion spotLightInitRotation;
    Vector3 spotLightPositionOffset;


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        spotLightInitRotation = GetComponentInChildren<Light>().transform.rotation;
        spotLightPositionOffset =  GetComponentInChildren<Light>().transform.position - transform.position;      
    }

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (!isDead)
        {
            
            if (controller.isGrounded)
            {
                if (isNearLadder)
                {
                    //trigger on ladder mode if player presses up near bottom or down near top
                    if ((transform.position.y > ladderTop.position.y && Input.GetAxisRaw("Vertical") < 0) ||
                        (transform.position.y < ladderBottom.position.y && Input.GetAxisRaw("Vertical") > 0))
                    {
                        isOnLadder = true;
                        isNearLadder = false;
                        Physics.IgnoreLayerCollision(8, 9, true);
                    }
                }
                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            }


            //On ladder mode, only vertical input is allowed and break out when past top or bottom
            if (isOnLadder)
            {
                if ((transform.position.y > ladderTop.position.y && Input.GetAxisRaw("Vertical") > 0) ||
                    (transform.position.y < ladderBottom.position.y && Input.GetAxisRaw("Vertical") < 0))
                {
                    isOnLadder = false;
                    isNearLadder = true;
                }
                else
                {
                    moveDirection = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= ladderSpeed;
                }
            }

            //normal mode, gravity affects us and collisions are enabled
            if (!isOnLadder)
            {
                Physics.IgnoreLayerCollision(8, 9, false);
                moveDirection.y -= gravity * Time.deltaTime;
            }
            controller.Move(moveDirection * Time.deltaTime);

        }

        if (isDead)
        {
            moveDirection = new Vector3(0, 0, 0);
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            GetComponentInChildren<Light>().transform.position = deathPosition + spotLightPositionOffset;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Barrel")
        {
            deathPosition = transform.position;
            if (other.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
            }
            GameObject lightObj = GameObject.FindGameObjectWithTag("MainLight");
            lightObj.SetActive(false);
            Physics.IgnoreLayerCollision(8, 10, true);
            isDead = true;
            anim.SetTrigger("Die");
        }
    }

    void LateUpdate() 
    {
        GetComponentInChildren<Light>().transform.rotation = spotLightInitRotation; 
    }

    public void EnterLadderArea(Transform ladderTop, Transform ladderBottom)
    {
        isNearLadder = true;
        this.ladderTop = ladderTop;
        this.ladderBottom = ladderBottom;
    }

    public void LeaveLadderArea()
    {
        isNearLadder = false;
    }
}
