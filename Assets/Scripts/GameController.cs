using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public PlayerMove player;
    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (player.doGameOver)
        {
            anim.SetTrigger("DoGameOver");
        }

        if(Input.GetButton("Quit"))
        {
            Application.Quit();
        }
    }
}
