using System;
using UnityEngine;

namespace GlobalGame.UI 
{
    public class PlayerInstructWrapper : MonoBehaviour
    {
        float DelayTimer = 0.2f;
        float timer = Mathf.Infinity;

        Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (timer <= DelayTimer) { timer += Time.deltaTime; }
        }

        public void toggleInstruct() 
        {
            if(timer <= DelayTimer) { return; }
            animator.SetBool("Move",!(animator.GetBool("Move")));
            timer = 0;
        }
    }

}
