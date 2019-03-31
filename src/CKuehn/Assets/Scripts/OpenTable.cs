using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTable : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        Animator animator = Panel.GetComponent<Animator>();
        if (animator != null)
        {
            bool isOpen = animator.GetBool("open");

            animator.SetBool("open", !isOpen);

        }
       
    }
}
