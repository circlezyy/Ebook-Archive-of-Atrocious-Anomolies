using UnityEngine;

public class WendigoPageAnimate : MonoBehaviour
{
    public Material material;

    public Texture[] textures;

    public float speed = 0.1f;
    private int index = 0;

    private void Start()
    {
        InvokeRepeating("ChangeTexture", 0, speed);
    }

    private void ChangeTexture()
    {
        if (index == textures.Length - 1)
            index = 0;

        material.SetTexture("_MainTex", textures[index++]);
    }
}
