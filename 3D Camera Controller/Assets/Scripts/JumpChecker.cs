using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW
{
    public delegate void GameEvent();
    public class JumpChecker : MonoBehaviour
    {
        public bool Grounded { get { return grounded; } }
        bool grounded;

        Vector3 ground_checkoffset;
        Vector3 ground_direction = Vector3.down;
        float check_angle = 30f;

        // Start is called before the first frame update
        void Start()
        {
            ground_checkoffset = new Vector3(0, GetComponent<MeshRenderer>().bounds.min.y, 0);
        }

        private void OnCollisionStay(Collision collision)
        {
            grounded = false;
            foreach (ContactPoint c in collision.contacts) {
                Vector3 coll_dir = collision.contacts[0].point - (transform.position);
                if (Vector3.Angle(ground_direction, coll_dir) <= check_angle)
                {
                    grounded = true;
                    break;
                }
            }
        }
    }
}