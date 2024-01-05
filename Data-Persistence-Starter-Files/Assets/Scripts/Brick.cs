using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{

    /* Unmerged change from project 'Assembly-CSharp.Player'
    Before:
        public UnityEvent<int> onDestroyed;

        public int PointValue;
    After:
        public UnityEvent<int> onDestroyed;

        public int PointValue;
    */
    public UnityEvent<int> onDestroyed;

    public int PointValue;

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1:
                block.SetColor("_BaseColor", Color.green);
                break;
            case 2:
                block.SetColor("_BaseColor", Color.yellow);
                break;
            case 5:
                block.SetColor("_BaseColor", Color.blue);
                break;
            default:
                block.SetColor("_BaseColor", Color.red);
                break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        onDestroyed.Invoke(PointValue);

        Destroy(gameObject, 0.1f);
    }
}
