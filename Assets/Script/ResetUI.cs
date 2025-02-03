using UnityEngine;

public class ResetUI : MonoBehaviour
{
    public string tagToReset = "Now";  // ���Z�b�g�Ώۂ̃^�O

    public void ResetObjectsByTag()
    {
        // �w�肵���^�O�̃I�u�W�F�N�g�����ׂĎ擾
        GameObject[] objectsToReset = GameObject.FindGameObjectsWithTag(tagToReset);

        // �擾�����I�u�W�F�N�g���\���ɂ���
        foreach (GameObject obj in objectsToReset)
        {
            obj.SetActive(false);  // �e�I�u�W�F�N�g���\���ɂ���
        }
    }
}
