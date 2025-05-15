using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float timer;

    void Start()
    {
        // Get the SpriteRenderer component attached to the object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize timer
        timer = 0f;
    }

    void Update()
    {
        // Increase the timer by the time elapsed since the last frame
        timer += Time.deltaTime;

        // When one second has passed, change the color
        if (timer >= 1f)
        {
            // Reset the timer
            timer = 0f;

            // Change the color to a random color
            spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }
    }
}
