using UnityEngine;

[System.Serializable]
public class BackgroundElement
{
    public SpriteRenderer backgroundSprite;
    [Range(0f, 1f)] public float scrollSpeed;

    [HideInInspector] public Material spriteMaterial;
}

public class ParallaxBackground : MonoBehaviour
{
    private float startPos;

    [SerializeField] private Transform cameraPos;
    [SerializeField] private float multiplier = 1f;

    //[SerializeField] private bool verticalFollow = true;
    //[SerializeField] private float verticalMultiplier = 1f;
    
    [SerializeField] private BackgroundElement[] backgroundElements;


    private void Start()
    {
        startPos = transform.position.x;
    }

    private void Update()
    {

        foreach (BackgroundElement element in backgroundElements)
        {
            float distance = cameraPos.position.x * element.scrollSpeed * multiplier;
            element.backgroundSprite.transform.position = new Vector3(startPos + distance, element.backgroundSprite.transform.position.y, element.backgroundSprite.transform.position.z);
        }

        // if (verticalFollow)
        // {
        //     float verticalDistance = cameraPos.position.y * verticalMultiplier;
        //     transform.position = new Vector3(transform.position.x, verticalDistance, transform.position.z);
        // }

    }
}
