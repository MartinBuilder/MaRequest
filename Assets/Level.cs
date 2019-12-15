using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject {

    public int width = 3;
    public int height = 3;
    public GenerationType generationType;
    public Vector3 size = Vector3.one;

    public void Generate() {
        CubeSpawner.instance.SpawnObjects(width, height, generationType, size);
    }
}
