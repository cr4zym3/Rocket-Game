using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float fadeDuration = 1f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine fadeCoroutine;
    public Interact interact;
    public Asteroid asteroid;
    private bool canFire = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interact.canInteract && canFire)
        {
            FireLaser();
            canFire = false;
        }
    }

    public void FireLaser()
    {
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a);
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeOut());
        asteroid.ExplodeAsteroid();
    }

    IEnumerator FadeOut()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(originalColor.a, 0, timer / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}
