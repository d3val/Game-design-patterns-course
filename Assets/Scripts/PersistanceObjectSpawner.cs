using UnityEngine;

/*Esta clase se encarga de asegurarse que los objetos que deban prevalecer entre
 escenas, lo hagan, si bien es casi lo mismo que singleton
de esta forma se le quitan responsabilidades a las clases que hacian singleton
lo que facilita las pruebas*/
public class PersistanceObjectSpawner : MonoBehaviour
{
    //Config data
    [Tooltip("This prefab will only be spawned once and persisted between scenes.")]
    [SerializeField] GameObject persistenceObjectPrefab = null;

    static bool hasSpawned = false;

    private void Awake()
    {
        if(hasSpawned) return;

        SpawnPersistanceObjects();
        hasSpawned = true;
    }
    
    private void SpawnPersistanceObjects()
    {
        GameObject persistentObject = Instantiate(persistenceObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
