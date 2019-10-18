using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    public class PlayerController : MonoBehaviour
    {
        PlayerBody pb;
        [HideInInspector] public bool activated = true;
        Camera cam;

        // Start is called before the first frame update
        void Awake()
        {
            pb = gameObject.GetComponent<PlayerBody>();
            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (activated)
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");
                Vector3 move_dir;
                if (cam != null)
                {
                    Vector3 camForward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up);
                    move_dir = (v * camForward + h * cam.transform.right);
                }
                else
                {
                    cam = Camera.main;
                    move_dir = (v * Vector3.forward + h * Vector3.right);
                }
                if (move_dir.magnitude > 1) move_dir.Normalize();

                bool hold_move = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
                bool move = move_dir.magnitude > 0f;

                bool jump = Input.GetButtonDown("Jump");
                bool hold_jump = Input.GetButton("Jump");

                pb.HandleInput(move, move_dir, hold_move, jump, hold_jump);
            }
        }
    }
}