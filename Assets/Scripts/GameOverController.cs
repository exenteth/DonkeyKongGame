using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

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
    }
}
