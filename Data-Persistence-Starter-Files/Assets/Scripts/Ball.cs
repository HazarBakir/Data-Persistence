using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision other)
    {

        /* Unmerged change from project 'Assembly-CSharp.Player'
        Before:
                var velocity = m_Rigidbody.velocity;

                velocity += velocity.normalized * 0.01f;
        After:
                var velocity = m_Rigidbody.velocity;

                velocity += velocity.normalized * 0.01f;
        */
        var velocity = m_Rigidbody.velocity;

        velocity += velocity.normalized * 0.01f;

        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * 0.5f : Vector3.down * 0.5f;
        }

        if (velocity.magnitude > 3.0f)
        {
            velocity = velocity.normalized * 3.0f;
        }

        m_Rigidbody.velocity = velocity;
    }
}
