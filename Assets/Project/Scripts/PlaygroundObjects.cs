using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class PlaygroundObjects : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private GameObject content;

    private ObjectSpawner objectSpawner;

    
    [SerializeField]
    public List<GameObject> m_ObjectPrefabs = new List<GameObject>();
    public List<GameObject> objectPrefabs
    {
        get => m_ObjectPrefabs;
        set => m_ObjectPrefabs = value;
    }

    [SerializeField]
    public List<Texture> m_SpawnVisualizationPrefab = new List<Texture>();
    public List<Texture> spawnVisualizationPrefab
    {
        get => m_SpawnVisualizationPrefab;
        set => m_SpawnVisualizationPrefab = value;
    }

    private List<ModelObject> playgroundObjects = new List<ModelObject>();


    private void Awake() {
        GameObject objectSpawnerObject = GameObject.Find("Object Spawner");
        objectSpawner = objectSpawnerObject.GetComponent<ObjectSpawner>();
    }

    void Start()
    {
        for (int i = 0; i < m_ObjectPrefabs.Count; i++)
        {
            ModelObject pObject = new ModelObject(
                m_ObjectPrefabs[i].name,
                m_ObjectPrefabs[i],
                m_SpawnVisualizationPrefab[i],
                i
            );
            playgroundObjects.Add(pObject);
            objectSpawner.objectPrefabs.Add(pObject.Prefab);
            CreateButton(pObject);
        }
    }

    private void CreateButton(ModelObject modelObject)
    {
        GameObject newButton = Instantiate(buttonPrefab, content.transform);

        RawImage image = newButton.GetComponentInChildren<RawImage>();
        if (image != null)
        {
            image.texture = modelObject.Sprite;
        }

        Button button = newButton.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => {
                objectSpawner.spawnOptionIndex = modelObject.Order;
                newButton.transform.GetChild(1).gameObject.SetActive(true);

                foreach (Transform child in content.transform)
                {
                    if (child != newButton.transform)
                    {
                        child.GetChild(1).gameObject.SetActive(false);
                    }
                }
            });
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
