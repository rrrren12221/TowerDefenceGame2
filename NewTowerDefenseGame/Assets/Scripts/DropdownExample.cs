using UnityEngine;
using UnityEngine.UI;

public class DropdownExample : MonoBehaviour
{
    public Dropdown dropdown; // HierarchyのDropdownをアタッチ

    void Start()
    {
        // 初期項目を設定
        dropdown.ClearOptions(); // 既存の項目をクリア
        dropdown.AddOptions(new System.Collections.Generic.List<string> { "Track 1", "Track 2", "Track 3" });
    }

    public void OnDropdownChanged(int index)
    {
        Debug.Log("Selected: " + dropdown.options[index].text);
    }
}
