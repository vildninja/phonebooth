using UnityEngine;
using UnityEditor;
using System.Collections;

public class AudioBatchSettings {

    [MenuItem("Custom/Audio to 2D")]
    public static void AudioTo2D()
    {
        foreach (AudioClip audio in Selection.GetFiltered(typeof(AudioClip), SelectionMode.Assets))
        {
            var path = AssetDatabase.GetAssetPath(audio);
            var importer = AudioImporter.GetAtPath(path) as AudioImporter;
            importer.threeD = false;
            AssetDatabase.ImportAsset(path);
        }
    }
}
