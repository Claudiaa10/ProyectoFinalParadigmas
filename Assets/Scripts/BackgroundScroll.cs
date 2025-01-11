using UnityEngine;

public class InfiniteBackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float backgroundWidth = 20f;

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        if (transform.position.x <= -backgroundWidth)
        {
            transform.position = new Vector3(backgroundWidth, transform.position.y, transform.position.z);
        }
    }
}
