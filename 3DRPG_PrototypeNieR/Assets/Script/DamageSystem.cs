using UnityEngine;

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
    #endregion

    #region ���G�p�H
    private Animator ani;
    #endregion

    #region �ƥ�
    private void Awake()
    {
        ani = GetComponent<Animator>();
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
        hp -= getAttack;
        ani.SetTrigger(parameterDamage);

        if (hp <= 0) Dead();
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
    }
    #endregion
}