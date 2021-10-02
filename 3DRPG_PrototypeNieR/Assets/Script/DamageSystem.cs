using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// ���˨t��
/// ��q�B�ʵe�B���`
/// </summary>
public class DamageSystem : MonoBehaviour
{
    #region ���G���}
    [Header("��q"), Range(0, 1000)]
    public float hp = 100;
    [Header("���˰ʵe�ѼƦW��")]
    public string parameterDamage = "����Ĳ�o";
    public string parameterDead = "���`�}��";
    [Header("�����G����A�ݭn�ɽбN�����J")]
    public Image imgHp;
    [Header("���˨ƥ�G���ˤ���n�B�z���欰")]
    public UnityEvent onDamage;
    [Header("���`�ƥ�G���`����n�B�z���欰")]
    public UnityEvent onDead;
    [Header("���`��q�����Ⱥ޲z��")]
    public bool sendToMissionManager;
    #endregion

    #region ���G�p�H
    private Animator ani;
    private float hpMax;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        ani = GetComponent<Animator>();
        hpMax = hp;
    }

    private void Update()
    {
        
    }
    #endregion

    #region ��k�G���}
    /// <summary>
    /// ���ˡA����������O�óB�z��q�P���˦欰
    /// </summary>
    /// <param name="getAttack">�����쪺�����O</param>
    public void Damage(float getAttack)
    {
        if (ani.GetBool(parameterDead)) return;     // �p�G �w�g���` �N ���X ���B�z

        hp -= getAttack;
        ani.SetTrigger(parameterDamage);
        onDamage.Invoke();

        if (hp <= 0) Dead();
    }

    /// <summary>
    /// ��s�������
    /// </summary>
    public void UpdateHpUI()
    {
        imgHp.fillAmount = hp / hpMax;
    }
    #endregion

    #region ��k�G�p�H
    /// <summary>
    /// ���`��k
    /// </summary>
    private void Dead()
    {
        hp = 0;
        ani.SetBool(parameterDead, true);
        onDead.Invoke();

        if (sendToMissionManager) MissionManager.instance.UpdateMissionCount(1);
    }
    #endregion
}