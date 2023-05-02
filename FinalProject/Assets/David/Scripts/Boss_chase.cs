using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_chase : StateMachineBehaviour
{
    //create a health variable called bossHealth
    public int bosshealth = 10;
    public bool Phase2 = false;
    public bool Phase3 = false;
    public bool isDead = false;
    bossbehavior bossbehavior;
    public float attackrange;
    //a box to store our speed variable 
    public float speed;
    //a box to store the player's transform information
    Transform player;
    //a box to store yhe Bosses rigidbody
    Rigidbody2D rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //set the reference for the player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //set the reference for our boss
        rb = animator.GetComponent<Rigidbody2D>();
        //set the reference for our boss behavior
        bossbehavior = animator.GetComponent<bossbehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossbehavior.LookAtPlayer();
        //declaring and sending the player to target for our boss, locking the y axis
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        //sets a new position for our boss to move towards
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossbehavior.speed * Time.deltaTime);
        //tell out rb to the newPos
        rb.MovePosition(newPos);
        float distance = Vector2.Distance(player.position, rb.position);
        if (distance < bossbehavior.attackrange && !bossbehavior.Phase2 && !bossbehavior.Phase3 && !bossbehavior.isDead)
        {
            animator.SetTrigger("Melee Attack");
        }
        else if (distance < bossbehavior.attackrange && bossbehavior.Phase2 && !bossbehavior.Phase3 && !bossbehavior.isDead)
        {
            animator.SetTrigger("Phase 2 Attack");
        }
        else if (distance < bossbehavior.attackrange && !bossbehavior.Phase2 && bossbehavior.Phase3 && !bossbehavior.isDead)
        {
            animator.SetTrigger("Phase 3 Attack");
        }
        else if (bossbehavior.isDead) 
        { 
}            animator.SetTrigger("Death");
        }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    

}
