using UnityEngine;

/// <summary>
/// ���Ⱥ޲z��
/// </summary>
public class MissionManager : MonoBehaviour
{
    #region ���G���}
    /// <summary>
    /// �w�q�C�|�A��t�λ����C�|�W�٥H�Υ]�t���ǿﶵ
    /// ���Ȫ��A�G�����ȫe�B���ȶi�椤�B��������
    /// </summary>
    public enum StateMission
    {
        MissionBefore,Missionning,MissionFinish
    }

    [Header("���Ȫ��A")]
    public StateMission state;
    [Header("��e���d��ܸ��")]
    public DialogueData data;

    /// <summary>
    /// ���Ⱥ޲z�����骫��
    /// </summary>
    public static MissionManager instance;
    #endregion

    #region ���G�p�H    
    #endregion

    #region �ƥ�
    private void Awake()
    {
        instance = this;    // ���骫�� ���� �� ����
    }
    #endregion

    #region ��k�G���}
    /// <summary>
    /// �N���Ȫ����A�אּ���ȶi�椤
    /// </summary>
    public void ChangeStateToMissionning()
    {
        state = StateMission.Missionning;
    }

    /// <summary>
    /// ��s���ȻݨD�ƶq
    /// </summary>
    /// <param name="count">�n��s���ƶq</param>
    public void UpdateMissionCount(int count)
    {
        data.countNeed -= count;

        if (data.countNeed == 0) MissionFinish();
    }
    #endregion

    #region ��k�G�p�H
    /// <summary>
    /// ���ȧ���
    /// </summary>
    private void MissionFinish()
    {
        state = StateMission.MissionFinish;
        StartCoroutine(DialogueSystem.instance.ShowEveryDialogue(data.diaogueContentsFinish,false,true));
    }
    #endregion
}
