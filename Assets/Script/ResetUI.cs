using UnityEngine;

public class ResetUI : MonoBehaviour
{
    public string tagToReset = "Now";  // リセット対象のタグ

    public void ResetObjectsByTag()
    {
        // 指定したタグのオブジェクトをすべて取得
        GameObject[] objectsToReset = GameObject.FindGameObjectsWithTag(tagToReset);

        // 取得したオブジェクトを非表示にする
        foreach (GameObject obj in objectsToReset)
        {
            obj.SetActive(false);  // 各オブジェクトを非表示にする
        }
    }
}
