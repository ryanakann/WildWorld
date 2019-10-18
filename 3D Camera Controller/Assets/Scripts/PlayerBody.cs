using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    public class PlayerBody : Body
    {
        [HideInInspector]
        public MoveHandler move_handler;
        [HideInInspector]
        public JumpChecker jump_checker;

        protected override void Start()
        {
            base.Start();
            rotator.smooth_speed = 0.25f;
            move_handler = GetComponent<MoveHandler>();
            jump_checker = GetComponentInChildren<JumpChecker>();
        }

        protected override void Update()
        {
            base.Update();
        }

        public void HandleInput(bool move, Vector3 move_dir, bool hold_move, 
            bool jump, bool hold_jump)
        {
            if (hold_jump)
            {
                // jump_handler.Act(jump, hold_jump);
            }

            if (move)
            {
                move_handler.Act(move_dir, hold_move);
            }
        }
    }
}