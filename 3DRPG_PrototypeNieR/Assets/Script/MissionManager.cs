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
    #endregion

    #region ���G�p�H    
    #endregion

    #region �ƥ�
    #endregion

    #region ��k�G���}
    /// <summary>
    /// �N���Ȫ����A�אּ���ȶi�椤
    /// </summary>
    public void ChangeStateToMissionning()
    {
        state = StateMission.Missionning;
    }
    #endregion
}
