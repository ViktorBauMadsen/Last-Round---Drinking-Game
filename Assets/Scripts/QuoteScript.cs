using UnityEngine;

public class QuoteScript : MonoBehaviour
{
    public float speed = 200f;
    public float targetX = 0f;

    void Update()
    {
        Vector3 pos = transform.localPosition;
        if (pos.x < targetX)
        {
            pos.x += speed * Time.deltaTime;
            pos.x = Mathf.Min(pos.x, targetX);
            transform.localPosition = pos;
        }
    }
}
