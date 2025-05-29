using UnityEngine;  // Gives access to Unity engine functionality, including MonoBehaviour, Transform, Time, and Vector3.

public class QuoteScript : MonoBehaviour  // Defines a MonoBehaviour script that can be attached to a GameObject in the Unity scene.
{
    public float speed = 200f;    // Controls how fast the object moves horizontally. Higher values mean faster movement.
    public float targetX = 0f;    // The final horizontal (X-axis) position the object should move toward.

    void Update()  // Unity’s built-in method that runs once per frame. Used for checking and updating behavior continuously.
    {
        Vector3 pos = transform.localPosition;  // Gets the object's current position relative to its parent (local space).

        if (pos.x < targetX)  // Checks if the object is still to the left of the target X position.
        {
            // Moves the object to the right by increasing its x-position.
            // 'speed * Time.deltaTime' ensures smooth and frame-rate independent movement.
            pos.x += speed * Time.deltaTime;

            // Ensures the object does not overshoot the target position by clamping the x value.
            // If pos.x exceeds targetX, it is set back to targetX.
            pos.x = Mathf.Min(pos.x, targetX);

            // Applies the new position back to the object.
            transform.localPosition = pos;
        }
    }
}
