using System;
using UnityEngine;

public class CupboardDrawer : SceneItem, IInteractable
{
    [SerializeField]
    private Animator animator;

    private bool isOpen;

    public void Interact()
    {
        isOpen = !isOpen;
        OpenCloseDrawer(isOpen);
    }

    private void OpenCloseDrawer(bool state)
    {
        if(animator == null)
        {
            throw new InvalidOperationException($"OpenCloseDrawer failed: The animator component: {nameof(animator)} is not assigned in the inspector panel");
        }

        animator.SetBool("IsOpen", state);
    }
}
