
using System.Collections.Generic;
using Script;
using UnityEngine;
public class Spawner : MonoBehaviour {

    public GameObject CubePrefab;

    private List<GameObject> _cubeList = new List<GameObject>();
    private string _savedData;

    private void Update() {
        
        if (Input.GetButton("Jump"))
        {
            GameObject instantiate = Instantiate(CubePrefab, transform.position, Quaternion.identity);
            instantiate.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            _cubeList.Add(instantiate);
        }
        if (Input.GetButtonDown("Fire1")) {
            // Serialization process
            FileSave fileSave = new FileSave(_cubeList);
            _savedData = JsonUtility.ToJson(fileSave);
            fileSave.SaveData(_savedData);
        }
        if (Input.GetButtonDown("Fire2")) {
            // Clear state
            foreach (GameObject o in _cubeList) {
                Destroy(o);
            }
            _cubeList.Clear();
            // Deserialization process
            FileSave fileSave = JsonUtility.FromJson<FileSave>(new FileSave().Path());
            foreach (SerializableTransform serializableTransform in fileSave.SerializableTransforms) {
                GameObject instantiate = Instantiate(CubePrefab, transform.position, Quaternion.identity);

                instantiate.transform.position = serializableTransform.Position;
                instantiate.transform.rotation = serializableTransform.Rotation;

                instantiate.GetComponent<MeshRenderer>().material.color = serializableTransform.Color;

                instantiate.GetComponent<Rigidbody>().velocity = serializableTransform.Velocity;
                instantiate.GetComponent<Rigidbody>().angularVelocity = serializableTransform.AngVelocity;

                _cubeList.Add(instantiate);
            }
        }
    }

}