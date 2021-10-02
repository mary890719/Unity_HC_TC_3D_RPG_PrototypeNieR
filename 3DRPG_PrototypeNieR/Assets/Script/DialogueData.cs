using UnityEngine;

/// <summary>
/// 對話系統
/// 1. 對話者名稱
/// 2. 對話內容 - 多段
/// </summary>
// 繼承類別改為 ScriptableObject 腳本畫物件
// 代表此類別的內容可以建立物件並儲存於專案內
// 需搭配 CreateAssetMenu 建立素材選項來建立此物件
[CreateAssetMenu(menuName ="KID/對話資料",fileName = "對話資料")]
public class DialogueData : ScriptableObject
{
    [Header("對話者名稱")]
    public string diaogueTalerName;
    [Header("對話內容"), TextArea(2, 5)]
    public string[] diaogueContents;
    [Header("此對話任務的需求數量"), Range(0, 100)]
    public int countNeed = 2;
}
