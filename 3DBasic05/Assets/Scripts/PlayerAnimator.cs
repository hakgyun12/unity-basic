using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnMovement(float horizontal, float vertical)
    {
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);
    }

    public void OnJump()
    {
        animator.SetTrigger("onJump");
    }
}
