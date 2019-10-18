using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    public class MoveHandler : BodyHandler
    {
        Rigidbody rb;
        float speed = 10f;
        float max_speed = 50f;

        float ground_drag = 10f, air_drag = 5f, move_drag = 1f;

        protected override void Start()
        {
            base.Start();
            rb = GetComponent<Rigidbody>();
            priority = 1;
        }

        public void Act(Vector3 dir, bool hold_move)
        {
            if (pb.action_state <= priority)
            {
                if (hold_move)
                {
                    if (pb.jump_checker.Grounded)
                        rb.drag = move_drag;
                    else
                        rb.drag = air_drag;
                    pb.rotator.Face(dir, lockY: false);
                }
                else
                    rb.drag = ground_drag;

                float y_vel = rb.velocity.y;
                Vector3 velocity = dir * speed;
                if (velocity.magnitude > max_speed)
                    velocity = velocity.normalized * max_speed;
                rb.velocity = new Vector3(velocity.x, y_vel, velocity.z);
            }
        }
    }
}
