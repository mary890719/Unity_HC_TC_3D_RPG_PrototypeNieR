using UnityEngine;

/// <summary>
/// ��ܨt��
/// 1. ��ܪ̦W��
/// 2. ��ܤ��e - �h�q
/// </summary>
// �~�����O�אּ ScriptableObject �}���e����
// �N�����O�����e�i�H�إߪ�����x�s��M�פ�
// �ݷf�t CreateAssetMenu �إ߯����ﶵ�ӫإߦ�����
[CreateAssetMenu(menuName ="KID/��ܸ��",fileName = "��ܸ��")]
public class DialogueData : ScriptableObject
{
    [Header("��ܪ̦W��")]
    public string diaogueTalerName;
    [Header("��ܤ��e"), TextArea(2, 5)]
    public string[] diaogueContents;
    [Header("����ܥ��Ȫ��ݨD�ƶq"), Range(0, 100)]
    public int countNeed = 2;
}
