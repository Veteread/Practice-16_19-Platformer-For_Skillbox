using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Chest : MonoBehaviour
    {
        
        public Animator animator;       
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                isOpened = value;
                animator.SetBool("IsOpened", isOpened);
            }
        }
        private bool isOpened;

        public void Open()
        {
            IsOpened = true;
        }
        
        public void Close()
        {
            IsOpened = false;
        }
    }
