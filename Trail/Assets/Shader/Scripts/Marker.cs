using UnityEngine;

public class Marker : DraggableObject
{
    [SerializeField]
    private Color color;

    [SerializeField]
    private MeshRenderer[] colouredParts;

    [SerializeField]
    private Painter painter;

    [SerializeField]
    private PaintReceiver paintReceiver;

    protected override void Awake()
    {
        base.Awake();
        GameObject parent = GameObject.FindGameObjectWithTag("Whiteboard");
        paintReceiver = parent.GetComponentInChildren<PaintReceiver>();
        foreach (MeshRenderer renderer in colouredParts)
        {
            renderer.material.color = color;
        }

        painter.Initialize(paintReceiver);
        painter.ChangeColour(color);
    }
}
