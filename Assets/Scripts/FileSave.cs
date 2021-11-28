using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script {
    [Serializable]
    public struct FileSave {

        public List<SerializableTransform> SerializableTransforms ;

        public FileSave(List<GameObject> gameObjects) {
            SerializableTransforms = new List<SerializableTransform>();
            foreach (GameObject o in gameObjects) {
                SerializableTransform serializableTransform = new SerializableTransform {
                    Position = o.transform.position,
                    Rotation = o.transform.rotation,
                    Velocity = o.GetComponent<Rigidbody>().velocity,
                    Color = o.GetComponent<Renderer>().material.color,
                    AngVelocity = o.GetComponent<Rigidbody>().angularVelocity,
                };
                SerializableTransforms.Add(serializableTransform);
            }
        }

        public void SaveData(string savedData)
        {
            string path = Application.streamingAssetsPath + "/SavedData.json";
            File.WriteAllText(path, savedData);
        }

        public string Path()
        {
            string path = Application.streamingAssetsPath + "/SavedData.json";
            return File.ReadAllText(path);
        }
    }
}
