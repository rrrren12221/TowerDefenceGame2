using UnityEngine;
using UnityEngine.UI;

public class DropdownExample : MonoBehaviour
{
    public Dropdown dropdown; // Hierarchy��Dropdown���A�^�b�`

    void Start()
    {
        // �������ڂ�ݒ�
        dropdown.ClearOptions(); // �����̍��ڂ��N���A
        dropdown.AddOptions(new System.Collections.Generic.List<string> { "Track 1", "Track 2", "Track 3" });
    }

    public void OnDropdownChanged(int index)
    {
        Debug.Log("Selected: " + dropdown.options[index].text);
    }
}
