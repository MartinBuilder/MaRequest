using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LightBulb : MonoBehaviour
{
    private LineRenderer lineRenderer;

    [SerializeField] private GameObject lightBulb;
    [SerializeField] private int amountOfBulbs;
    [SerializeField] private List<Color> colors;

    private MaterialPropertyBlock materialPropertyBlock;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Start()
    {
        for (int i = 0; i < amountOfBulbs; i++)
        {
            Vector3 pos = Vector3.Lerp(lineRenderer.GetPosition(1), lineRenderer.GetPosition(0), (i + 0.5f) / amountOfBulbs);

            var clone = Instantiate(lightBulb, pos, Quaternion.identity);
            clone.transform.parent = transform;

            var renderer = clone.GetComponent<Renderer>();
            renderer.GetPropertyBlock(materialPropertyBlock);

            Color color = colors[i % colors.Count];

            materialPropertyBlock.SetColor("_Color", color);
            materialPropertyBlock.SetVector("_EmissionColor", color * 5f);

            renderer.SetPropertyBlock(materialPropertyBlock);
        }
    }

}
