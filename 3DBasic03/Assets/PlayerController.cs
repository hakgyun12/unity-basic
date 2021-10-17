using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) )
        {
            animator.SetFloat("moveSpeed", 0.0f);
        }
        else if ( Input.GetKeyDown(KeyCode.R))
        {
            animator.SetFloat("moveSpeed", 5.0f);
        }
    }
}
