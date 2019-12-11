using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject {

    public int width = 3;
    public int height = 3;

    private CubeSpawner cubeSpawner;

    private void Awake() {
        Debug.Log("Now");
    }

    public void Generate() {
        //cubeSpawner.SpawnObjects(width, height);
    }
}
