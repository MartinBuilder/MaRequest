using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private List<Level> levels = new List<Level>();

    public void Start() {
        if(levels?.Count > 0) {
            levels[0].Generate();
        }
    }

}
